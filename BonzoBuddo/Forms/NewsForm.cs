using System.Diagnostics;
using System.Text;
using BonzoBuddo.Helpers;

namespace BonzoBuddo.Forms;

public partial class NewsForm : Form
{
    private readonly BonziHelper _helper;

    

    private readonly string[] _explainAnimations =
    {
        "Explain",
        "Explain2",
        "Explain3",
        "Explain4"
    };


    public NewsForm(BonziHelper helper)
    {
        InitializeComponent();
        _helper = helper;
        categoryBox.Items.AddRange(PersistenceHelper.GetCategories());
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
        Debug.WriteLine(PersistenceHelper.CountryCode + " " + PersistenceHelper.Country);
    }

    private void categoryBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        PersistenceHelper.SetData(PersistenceType.NewsCategory, categoryBox.SelectedItem.ToString());
        Debug.WriteLine(PersistenceHelper.NewsCategory);
    }
}