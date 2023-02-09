using BonzoBuddo.Helpers;

namespace BonzoBuddo.BonziAI.Speech;

/// <summary>
///     Speech type for Recipes
/// </summary>
public class Recipe : Speech
{
    /// <summary>
    ///     Constructor, set PhraseDictionary
    /// </summary>
    public Recipe()
    {
        PhraseDictionary = ApiHelper.GetRecipe(PersistenceHelper.RecipeSearchTerm!);
    }

    public override string GetPhrase(int index)
    {
        throw new NotSupportedException("Use GetPhrase(string key)");
    }

    public override List<string> GetPhraseList()
    {
        throw new NotSupportedException("Use GetPhraseDictionary instead");
    }

    public override string GetRandomPhrase()
    {
        throw new NotSupportedException("This subclass cannot use this method.");
    }
}