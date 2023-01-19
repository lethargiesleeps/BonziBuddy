using System.Diagnostics;
using System.Text;
using System.Text.Json;
using BonzoBuddo.BonziAI.Speech;
using BonzoBuddo.Helpers;

namespace BonzoBuddo.Forms;

public partial class NewsForm : Form
{
    private readonly BonziHelper _helper;
    private Bonzi _bonzi;

    
    //TODO: Document
    private readonly string[] _explainAnimations =
    {
        "Explain",
        "Explain2",
        "Explain3",
        "Explain4"
    };


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
        this.Dispose();
        this.Close();
        
        RandomNumberHelper.SetIndex(_explainAnimations);
        _helper.Play(_explainAnimations[RandomNumberHelper.CurrentValue]);
        _helper.Speak("I get it, news is a social contaminator.");
    }

    private void countryBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        var splitItem = countryBox.SelectedItem.ToString().Split('(');
        var countryCode = $"{splitItem[1][0]}{splitItem[1][1]}";
        var splitItem2 = splitItem[0].Split(" (");
        PersistenceHelper.SetData(PersistenceType.Country, splitItem2[0]);
        PersistenceHelper.SetData(PersistenceType.CountryCode, countryCode.ToLower());
        
    }

    private void categoryBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        PersistenceHelper.SetData(PersistenceType.NewsCategory, categoryBox.SelectedItem.ToString());
        //Debug.WriteLine(PersistenceHelper.NewsCategory);
    }

    private void submitButton_Click(object sender, EventArgs e)
    {
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

        PersistenceHelper.SetData(PersistenceType.NewsKeywords, keywordsBox.Text);
        _helper.Speak(Phrases.Prompts(_bonzi.Data.Name)["SearchNews"]);
        _helper.Play("ReadLookUp");
        _bonzi.SetSpeechPattern(SpeechType.News);
        _helper.Play("ReadReturn");
        _helper.Speak(_bonzi.Speak().GetPhrase("Author"));
        _helper.Speak(_bonzi.Speak().GetPhrase("Title"));
        _helper.Speak(_bonzi.Speak().GetPhrase("Excerpt"));
        var articleForm = new Article(_bonzi.Speak().GetPhrase("Title"), _bonzi.Speak().GetPhrase("Summary"));
        //TODO: Dialogue to show if user wants to open article and link
        articleForm.Show();
        this.Close();
        this.Dispose();
        







    }
}