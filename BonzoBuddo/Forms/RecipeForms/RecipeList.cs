using System.Diagnostics;
using BonzoBuddo.Helpers;

namespace BonzoBuddo.Forms.RecipeForms;

/// <summary>
/// Form for displaying list of recipes obtained from API call.
/// </summary>
public partial class RecipeList : Form
{
    private readonly Bonzi _bonzi;
    private readonly BonziHelper _helper;

    /// <summary>
    /// Form constructor.
    /// </summary>
    /// <param name="helper">Global BonziHelper.</param>
    /// <param name="bonzi">Global Bonzi.</param>
    public RecipeList(BonziHelper helper, Bonzi bonzi)
    {
        InitializeComponent();
        _helper = helper;
        _bonzi = bonzi;
        AddRecipeTitles();
    }

    /// <summary>
    /// Adds titles of recipes obtained from API response to the ListBox.
    /// </summary>
    private void AddRecipeTitles()
    {
        if (RecipeHelper.Titles is null) return;
        foreach (var r in RecipeHelper.Titles)
            recipeListBox.Items.Add(r);
    }

    /// <summary>
    /// Event for list box selection change.
    /// </summary>
    /// <remarks>For debugging purposes, can remove later.</remarks>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void recipeListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        Debug.WriteLine(recipeListBox.SelectedItem);
    }

    /// <summary>
    /// Closes and unallocates resources of form.
    /// </summary>
    /// <param name="sender">Button</param>
    /// <param name="e">Args.</param>
    private void cancelButton_Click(object sender, EventArgs e)
    {
        Close();
        Dispose();
    }

    /// <summary>
    /// Checks if anything is selected from list box, then opens RecipeDisplay form.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <see cref="RecipeDisplay"/>
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