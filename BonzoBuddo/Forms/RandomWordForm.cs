using BonzoBuddo.BonziAI.Speech;
using BonzoBuddo.Helpers;

namespace BonzoBuddo.Forms;

/// <summary>
///     Form for sending API request to retrieve random word, it's definition and synonyms/antonyms.
/// </summary>
public partial class RandomWordForm : Form
{
    private readonly Bonzi _bonzi;
    private readonly BonziHelper _helper;

    /// <summary>
    ///     Default constructor.
    /// </summary>
    /// <param name="helper">Instance of BonziHelper</param>
    /// <param name="bonzi">Instance of Bonzi</param>
    public RandomWordForm(BonziHelper helper, Bonzi bonzi)
    {
        InitializeComponent();
        _helper = helper;
        _bonzi = bonzi;
    }

    private void dictionaryBox_CheckedChanged(object sender, EventArgs e)
    {
        thesaurusBox.Enabled = dictionaryBox.Checked;
    }

    private void submitButton_Click(object sender, EventArgs e)
    {
        _helper.Stop();
        if (thesaurusBox.Checked && !thesaurusBox.Enabled)
        {
            thesaurusBox.Checked = false;
            thesaurusBox.Enabled = false;
            dictionaryBox.Checked = false;
            _helper.Speak(Phrases.ErrorMessages()["RandomWordIllegalBoxCombo"]);
        }
        else
        {
            PersistenceHelper.SetData(PersistenceType.Definition, dictionaryBox.Checked.ToString());
            PersistenceHelper.SetData(PersistenceType.Thesaurus, thesaurusBox.Checked.ToString());
            _helper.Speak(Phrases.Prompts(_bonzi.Data!.Name!)["RandomWord"]);
            _helper.Play("Think");
            _bonzi.SetSpeechPattern(SpeechType.RandomWord);

            RandomNumberHelper.SetIndex(Phrases.PreRandomWord(PersistenceHelper.Dictionary!).Count);
            _helper.Speak(Phrases.PreRandomWord(PersistenceHelper.Dictionary!)[RandomNumberHelper.CurrentValue]);
            if (PersistenceHelper.Definition)
            {
                if (!PersistenceHelper.Definition ||
                    !_bonzi.Speak()!.GetPhraseDictionary()!.ContainsKey("Definition")) return;
                _helper.Play("MailRead");
                _helper.Play("MailReturn");
                _helper.Speak(_bonzi.Speak()!.GetPhraseDictionary()!["Definition"]);
                if (PersistenceHelper.Thesaurus)
                {
                    if (_bonzi.Speak()!.GetPhraseDictionary()!.ContainsKey("Synonyms"))
                        _helper.Speak(_bonzi.Speak()!.GetPhrase("Synonyms"));
                    if (_bonzi.Speak()!.GetPhraseDictionary()!.ContainsKey("Antonyms"))
                        _helper.Speak(_bonzi.Speak()!.GetPhrase("Antonyms"));
                }

                if (_bonzi.Speak()!.GetPhraseDictionary()!.ContainsKey("Post"))
                    _helper.Speak(_bonzi.Speak()!.GetPhrase("Post"));
            }
            else
            {
                _helper.Speak(Phrases.PostDictionary(PersistenceHelper.Dictionary!));
            }

            Dispose(true);
            Close();
        }
    }
}