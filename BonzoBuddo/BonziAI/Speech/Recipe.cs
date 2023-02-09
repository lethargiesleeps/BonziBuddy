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

    /// <summary>
    /// Method unsupported by implementation.
    /// </summary>
    /// <param name="index">Not used.</param>
    /// <returns>See exception.</returns>
    /// <exception cref="NotSupportedException">Throws if this method is used with this child class.</exception>
    public override string GetPhrase(int index) => throw new NotSupportedException("Use GetPhrase(string key)");

    /// <summary>
    /// Method unsupported by implementation.
    /// </summary>
    /// <returns>See exception.</returns>
    /// <exception cref="NotSupportedException">Throws if this method is used with this child class.</exception>
    public override List<string> GetPhraseList() => throw new NotSupportedException("Use GetPhraseDictionary instead");

    /// <summary>
    /// Method unsupported by implementation.
    /// </summary>
    /// <returns>See exception.</returns>
    /// <exception cref="NotSupportedException">Throws if this method is used with this child class.</exception>
    public override string GetRandomPhrase() => throw new NotSupportedException("This subclass cannot use this method.");
}