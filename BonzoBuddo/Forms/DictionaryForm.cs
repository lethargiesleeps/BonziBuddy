using System.Diagnostics;
using BonzoBuddo.BonziAI.Speech;
using BonzoBuddo.Helpers;

namespace BonzoBuddo.Forms;

public partial class DictionaryForm : Form
{
    private readonly Bonzi _bonzi;
    private readonly BonziHelper _helper;

    public DictionaryForm(BonziHelper helper, Bonzi bonzi)
    {
        InitializeComponent();
        _helper = helper;
        _bonzi = bonzi;
    }

    private void submitButton_Click(object sender, EventArgs e)
    {
        _helper.Stop();
        _helper.Play("MailRead");
        _helper.Play("MailReturn");
        if (wordBox.Text.Length <= 0)
        {
            _helper.Speak(Phrases.ErrorMessages()["NoWordDictionary"]);
            _helper.Play("Giggle");
            _helper.Speak(Phrases.AuxiliaryPhrases(_bonzi.Data!.Name!)[0]);
        }
        else if (string.IsNullOrWhiteSpace(wordBox.Text))
        {
            _helper.Speak(Phrases.ErrorMessages()["WhitespaceDictionary"]);
            _helper.Play("Giggle");
        }
        else if (wordBox.Text.Split(' ').Length > 1)
        {
            _helper.Play("ScoutAlert");
            _helper.Speak(Phrases.ErrorMessages()["MultipleWordsDictionary"]);
        }
        else if (UiHelper.CheckForCussWords(wordBox.Text))
        {
            if (new Random().Next(0, 5001) == 1234)
            {
                var s = wordBox.Text;
                _helper.Speak($"{s}, {s}, {s}, {s}, {s}, {s}. I'm imitating you, {_bonzi.Data!.Name!}! This is what you sound like you ignorant child!");
                _helper.Play("Giggle");
                _helper.Hide();
                Dispose(true);
                Close();
            }
            else
            {
                _helper.Play("Unbelievable");
                _helper.Speak(Phrases.ErrorMessages()["HasCussWords"]);
                wordBox.Text = string.Empty;
            }
        }
        else
        {
            PersistenceHelper.SetData(PersistenceType.Dictionary, wordBox.Text);
            PersistenceHelper.SetData(PersistenceType.Thesaurus, thesaurusBox.Checked.ToString());
            _helper.Play("ReadLookUp");
            _bonzi.SetSpeechPattern(SpeechType.WordDefinition);
            Debug.WriteLine(PersistenceHelper.Dictionary);
            Debug.WriteLine(PersistenceHelper.Thesaurus);
            _helper.Speak(_bonzi.Speak()!.GetPhrase("Definition"));
            if (PersistenceHelper.Thesaurus)
            {
                if (_bonzi.Speak()!.GetPhraseDictionary()!.ContainsKey("Synonyms"))
                    _helper.Speak(_bonzi.Speak()!.GetPhrase("Synonyms"));
                if (_bonzi.Speak()!.GetPhraseDictionary()!.ContainsKey("Antonyms"))
                    _helper.Speak(_bonzi.Speak()!.GetPhrase("Antonyms"));
            }
            if (_bonzi.Speak()!.GetPhraseDictionary()!.ContainsKey("Post"))
                _helper.Speak(_bonzi.Speak()!.GetPhrase("Post"));
            Dispose(true);
            Close();
        }
    }
}