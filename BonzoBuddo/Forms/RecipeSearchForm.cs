using BonzoBuddo.BonziAI.Speech;
using BonzoBuddo.Forms.RecipeForms;
using BonzoBuddo.Helpers;

namespace BonzoBuddo.Forms;

public partial class RecipeSearchForm : Form
{
    private readonly Bonzi _bonzi;
    private readonly BonziHelper _helper;

    public RecipeSearchForm(BonziHelper helper, Bonzi bonzi)
    {
        InitializeComponent();
        _helper = helper;
        _bonzi = bonzi;
    }

    private void cancelButton_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void searchButton_Click(object sender, EventArgs e)
    {
        _helper.Stop();
        _helper.Play("MailRead");
        _helper.Play("MailReturn");
        if (string.IsNullOrEmpty(searchBox.Text))
        {
            _helper.Speak(Phrases.ErrorMessages()["NoWordRecipe"]);
            _helper.Play("GestureUp");
        }
        else if (string.IsNullOrWhiteSpace(searchBox.Text))
        {
            _helper.Speak(Phrases.ErrorMessages()["WhitespaceRecipe"]);
            _helper.Play("Giggle");
            searchBox.Text = string.Empty;
        }
        else if (UiHelper.CheckForCussWords(searchBox.Text))
        {
            UiHelper.HasCussWords(_helper, this, searchBox);
        }
        else
        {
            PersistenceHelper.SetData(PersistenceType.Recipe, searchBox.Text);
            _bonzi.SetSpeechPattern(SpeechType.Recipe);
            _helper.Play("ReadLookUp");
            if (_bonzi.Speak()!.GetPhraseDictionary()!.ContainsKey("NoRecipe"))
            {
                _helper.Speak(_bonzi.Speak()!.GetPhraseDictionary()!["NoRecipe"]);
                _helper.Play("Sad");
                searchBox.Text = string.Empty;
            }
            else
            {
                _helper.Speak(_bonzi.Speak()!.GetPhraseDictionary()!["HasRecipe"]);
                _helper.Play("Congratulate");
                var recipeList = new RecipeList(_helper, _bonzi);
                recipeList.Show();
                Dispose(true);
                Close();
            }
        }
    }
}