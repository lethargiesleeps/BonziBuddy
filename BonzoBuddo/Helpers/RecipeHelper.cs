using System.Text;
using System.Text.Json.Nodes;

namespace BonzoBuddo.Helpers;

/// <summary>
///     This static helper class can be used to store recipe information.
///     All public methods must be used first to store relevant information to be displayed after
///     the recipe API query is completed.
/// </summary>
public static class RecipeHelper
{
    public static List<string>? Titles { get; private set; }
    public static List<string>? Ingredients { get; private set; }
    public static List<string>? Servings { get; private set; }
    public static List<string>? Instructions { get; private set; }

    /// <summary>
    ///     Adds all titles from json query result.
    /// </summary>
    /// <param name="jsonArray">JsonArray with all recipes retrieved from API call.</param>
    private static void AddTitles(JsonArray jsonArray)
    {
        if (Titles == null)
            Titles = new List<string>();
        else
            Titles.Clear();

        foreach (var t in jsonArray)
            Titles.Add(t!["title"]!.ToString());
    }

    /// <summary>
    ///     Formats and adds all ingredient lists from json query results.
    /// </summary>
    /// <param name="jsonArray">JsonArray with all recipes retrieved from API call.</param>
    private static void AddIngredients(JsonArray jsonArray)
    {
        if (Ingredients == null)
            Ingredients = new List<string>();
        else
            Ingredients.Clear();

        var tempList = jsonArray.Select(t => t!["ingredients"]!.ToString()).ToList();
        foreach (var replace in tempList.Select(t => t.Replace('|', '\n')))
            Ingredients.Add(replace);
    }

    /// <summary>
    ///     Adds all servings from json query results.
    /// </summary>
    /// <param name="jsonArray">JsonArray with all recipes retrieved from API call.</param>
    private static void AddServings(JsonArray jsonArray)
    {
        if (Servings == null)
            Servings = new List<string>();
        else
            Servings.Clear();

        foreach (var t in jsonArray)
            Servings.Add(t!["servings"]!.ToString());
    }

    /// <summary>
    ///     Adds all instructions from json query results.
    /// </summary>
    /// <param name="jsonArray">JsonArray with all recipes retrieved from API call.</param>
    private static void AddInstructions(JsonArray jsonArray)
    {
        if (Instructions == null)
            Instructions = new List<string>();
        else
            Instructions.Clear();

        foreach (var t in jsonArray)
            Instructions.Add(t!["instructions"]!.ToString());
    }

    /// <summary>
    ///     Stores data retrieved from API call to be used on different forms.
    /// </summary>
    /// <param name="jsonArray">JsonArray with all recipes retrieved from API call.</param>
    public static void StoreResults(JsonArray jsonArray)
    {
        AddTitles(jsonArray);
        AddIngredients(jsonArray);
        AddServings(jsonArray);
        AddInstructions(jsonArray);
    }
}