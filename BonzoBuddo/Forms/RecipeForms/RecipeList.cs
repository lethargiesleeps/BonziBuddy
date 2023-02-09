using System.Diagnostics;
using BonzoBuddo.Helpers;

namespace BonzoBuddo.Forms.RecipeForms;

public partial class RecipeList : Form
{
    private readonly Bonzi _bonzi;
    private readonly BonziHelper _helper;

    public RecipeList(BonziHelper helper, Bonzi bonzi)
    {
        InitializeComponent();
        _helper = helper;
        _bonzi = bonzi;
        AddRecipeTitles();
    }

    private void AddRecipeTitles()
    {
        if (RecipeHelper.Titles is null) return;
        foreach (var r in RecipeHelper.Titles)
            recipeListBox.Items.Add(r);
    }

    private void recipeListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        Debug.WriteLine(recipeListBox.SelectedItem);
    }

    private void cancelButton_Click(object sender, EventArgs e)
    {
        Close();
        Dispose();
    }

    private void viewButton_Click(object sender, EventArgs e)
    {
        var index = recipeListBox.SelectedIndex;
        if (index <= 0)
        {
            //TODO: Bonzi stuff for not having anything selected
        }

        else
        {
            var recipeDisplay = new RecipeDisplay(
                RecipeHelper.Titles![index],
                RecipeHelper.Ingredients![index],
                RecipeHelper.Servings![index],
                RecipeHelper.Instructions![index],
                _helper,
                _bonzi);
            recipeDisplay.Show();
        }
    }
}