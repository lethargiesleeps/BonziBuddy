using System.Diagnostics;
using BonzoBuddo.Helpers;

namespace BonzoBuddo.Forms.RecipeForms;

/// <summary>
/// Form that displays selected recipe information.
/// </summary>
public partial class RecipeDisplay : Form
{
    private readonly Bonzi _bonzi;

    private readonly BonziHelper _helper;

    /// <summary>
    /// Logic for form functionality
    /// </summary>
    /// <param name="title">Title of recipe.</param>
    /// <param name="ingredients">Ingredients of recipe.</param>
    /// <param name="servings"># of servings of recipe.</param>
    /// <param name="instructions">Instructions of recipe.</param>
    /// <param name="helper">Global bonzi helper.</param>
    /// <param name="bonzi">Global bonzi object.</param>
    public RecipeDisplay(string title, string ingredients, string servings, string instructions, BonziHelper helper,
        Bonzi bonzi)
    {
        InitializeComponent();
        _helper = helper;
        _bonzi = bonzi;
        Text = title;

        _helper.Stop();
        //TODO: Put into phrases.cs
        _helper.Speak($"Here is how you make {title}.");
        ingredientInstructionTab.TabPages[0].Text = "Ingredients";
        ingredientInstructionTab.TabPages[1].Text = "Instructions";
        titleLabel.Text = title;
        servingLabel.Text = servings;
        ingredientText.Text = UiHelper.ParseIngredients(ingredients);
        instructionText.Text = instructions;
        Debug.WriteLine($"{ingredients}\n{instructions}");
    }

    /// <summary>
    /// Sets text of window to name of recipe.
    /// </summary>
    public sealed override string Text
    {
        get => base.Text;
        set => base.Text = value;
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
}