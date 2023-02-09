using System.Diagnostics;
using BonzoBuddo.Helpers;

namespace BonzoBuddo.Forms.RecipeForms;

public partial class RecipeDisplay : Form
{
    private readonly Bonzi _bonzi;

    private readonly BonziHelper _helper;

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

    public sealed override string Text
    {
        get => base.Text;
        set => base.Text = value;
    }

    private void cancelButton_Click(object sender, EventArgs e)
    {
        Close();
        Dispose();
    }
}