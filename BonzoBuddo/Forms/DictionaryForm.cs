using BonzoBuddo.BonziAI.Speech;
using BonzoBuddo.Helpers;

namespace BonzoBuddo.Forms;

/// <summary>
/// Form for performing Dictionary request.
/// </summary>
public partial class DictionaryForm : Form
{
    private readonly Bonzi _bonzi;
    private readonly BonziHelper _helper;

    /// <summary>
    /// Form constructor.
    /// </summary>
    /// <param name="helper">Global BonziHelper</param>
    /// <param name="bonzi">Global Bonzi</param>
    public DictionaryForm(BonziHelper helper, Bonzi bonzi)
    {
        InitializeComponent();
        _helper = helper;
        _bonzi = bonzi;
    }

    /// <summary>
    /// Validation for sending API request, and logic for displaying response data.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void submitButton_Click(object sender, EventArgs e)
    {
        _helper.Stop();
        _helper.Play("MailRead");
        _helper.Play("MailReturn");
        if (string.IsNullOrEmpty(wordBox.Text))
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
            UiHelper.HasCussWords(_helper, this, wordBox);
        }
        else
        {
            PersistenceHelper.SetData(PersistenceType.Dictionary, wordBox.Text);
            PersistenceHelper.SetData(PersistenceType.Thesaurus, thesaurusBox.Checked.ToString());
            _helper.Play("ReadLookUp");
            _bonzi.SetSpeechPattern(SpeechType.WordDefinition);
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

    /// <summary>
    /// Closes and unallocates resources of form.
    /// </summary>
    /// <param name="sender">Button</param>
    /// <param name="e">Args.</param>
    private void cancelButton_Click(object sender, EventArgs e)
    {
        PersistenceHelper.ClearData(new[]
        {
            PersistenceType.Dictionary,
            PersistenceType.Thesaurus
        });
        Close();
    }
}