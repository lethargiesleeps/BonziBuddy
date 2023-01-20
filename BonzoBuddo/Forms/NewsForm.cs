using BonzoBuddo.BonziAI.Speech;
using BonzoBuddo.Helpers;

namespace BonzoBuddo.Forms;

public partial class NewsForm : Form
{
    private readonly Bonzi _bonzi;

    //TODO: Document
    private readonly string[] _explainAnimations =
    {
        "Explain",
        "Explain2",
        "Explain3",
        "Explain4"
    };

    private readonly BonziHelper _helper;


    public NewsForm(BonziHelper helper, Bonzi bonzi)
    {
        InitializeComponent();
        _helper = helper;
        _bonzi = bonzi;

        var categoryList = PersistenceHelper.GetCategories().ToList();
        categoryList.Sort();
        categoryBox.Items.AddRange(categoryList.ToArray());
        countryBox.Items.AddRange(PersistenceHelper.GetCountries());
    }

    private void cancelButton_Click(object sender, EventArgs e)
    {
        PersistenceHelper.ClearData(new[]
        {
            PersistenceType.NewsResults,
            PersistenceType.ArticleDate,
            PersistenceType.ArticleUrl,
            PersistenceType.Country,
            PersistenceType.CountryCode,
            PersistenceType.NewsCategory,
            PersistenceType.NewsKeywords
        });
        Dispose();
        Close();

        RandomNumberHelper.SetIndex(_explainAnimations);
        _helper.Play(_explainAnimations[RandomNumberHelper.CurrentValue]);
        //TODO: Refactor into Phrases.cs
        _helper.Speak("I get it, news is a social contaminator.");
    }

    private void countryBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        var splitItem = countryBox.SelectedItem.ToString()!.Split('(');
        var countryCode = $"{splitItem[1][0]}{splitItem[1][1]}";
        var splitItem2 = splitItem[0].Split(" (");
        PersistenceHelper.SetData(PersistenceType.Country, splitItem2[0]);
        PersistenceHelper.SetData(PersistenceType.CountryCode, countryCode.ToLower());
    }

    private void categoryBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        PersistenceHelper.SetData(PersistenceType.NewsCategory, categoryBox.SelectedItem.ToString()!);
        //Debug.WriteLine(PersistenceHelper.NewsCategory);
    }

    private void submitButton_Click(object sender, EventArgs e)
    {
        _helper.Stop();
        if (countryBox.SelectedItem is null || categoryBox.SelectedItem is null)
        {
            countryBox.SelectedItem ??= countryBox.Items[0];
            categoryBox.SelectedItem ??= categoryBox.Items[9];
        }

        if (categoryBox.SelectedIndex == 0)
        {
            RandomNumberHelper.SetIndex(categoryBox.Items.Count);
            categoryBox.SelectedItem = "General";
        }

        
        if (UiHelper.CheckForCussWords(keywordsBox.Text))
        {
            if (new Random().Next(0, 5001) == 1234)
            {
                var s = keywordsBox.Text;
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
                keywordsBox.Text = string.Empty;
            }
            
        }
        else
        {
            PersistenceHelper.SetData(PersistenceType.NewsKeywords, keywordsBox.Text);
            _helper.Speak(Phrases.Prompts(_bonzi.Data!.Name!)["SearchNews"]);
            _helper.Play("MailRead");
            _bonzi.SetSpeechPattern(SpeechType.News);
            _helper.Play("MailReturn");
            if (_bonzi.Speak()!.GetPhraseDictionary()!.ContainsKey("NoResults"))
                _helper.Speak(_bonzi.Speak()!.GetPhrase("NoResults"));
            else
            {
                _helper.Speak(_bonzi.Speak()!.GetPhrase("Author"));
                _helper.Speak(_bonzi.Speak()!.GetPhrase("Title"));
                _helper.Speak(_bonzi.Speak()!.GetPhrase("Excerpt"));
                var dialogue = MessageBox.Show("Do you want to view more details?", "News", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (dialogue == DialogResult.Yes)
                {
                    var articleForm = new Article(_bonzi.Speak()!.GetPhrase("Title"), _bonzi.Speak()!.GetPhrase("Summary"));
                    articleForm.Show();
                    //TODO: Make bonzi act
                    ClearAndDispose();
                }
                else
                {
                    //TODO: Make bonzi act
                    ClearAndDispose();
                }
            }
        }
    }

    private void ClearAndDispose()
    {
        Dispose(true);
        Close();
    }
}