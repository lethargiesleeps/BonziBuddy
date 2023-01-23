namespace BonzoBuddo.Helpers;

/// <summary>
///     This class keeps track of any static information needed for function classes.
/// </summary>
public static class PersistenceHelper
{
    public static string? Name { get; private set; }
    public static string? LastSong { get; private set; }
    public static string? Dictionary { get; private set; }
    public static bool Thesaurus { get; private set; }
    public static bool Definition { get; private set; }
    public static string? CountryCode { get; private set; }
    public static string? Country { get; private set; }
    public static string? NewsKeywords { get; private set; }
    public static string? NewsCategory { get; private set; }
    public static int NewsResults { get; private set; }

    public static string? ArticleUrl { get; private set; }
    public static string? ArticlePublishDate { get; private set; }

    /// <summary>
    ///     Object array with all possible news categories. Unsorted.
    /// </summary>
    /// <returns>An object array.</returns>
    public static object[] GetCategories()
    {
        return new object[]
        {
            "None",
            "News",
            "Tech",
            "Sport",
            "World",
            "Finance",
            "Politics",
            "Business",
            "Economics",
            "Beauty",
            "Entertainment",
            "Travel",
            "Music",
            "Food",
            "Science",
            "Gaming",
            "Energy"
        };
    }

    /// <summary>
    ///     Array with all names and country codes of countries.
    /// </summary>
    /// <returns>An object array.</returns>
    public static object[] GetCountries()
    {
        return new object[]
        {
            "None (NN)",
            "United Arab Emirates (AE)",
            "Argentina (AR)",
            "Austria (AT)",
            "Australia (AU)",
            "Belgium (BE)",
            "Bulgaria (BG)",
            "Brazil (BR)",
            "Canada (CA)",
            "Switzerland (CH)",
            "China (CN)",
            "Colombia (CO)",
            "Cuba (CU)",
            "Czechia (CZ)",
            "Germany (DE)",
            "Egypt (EG)",
            "France (FR)",
            "United Kingdom (GB)",
            "Greece (GR)",
            "Hong Kong (HK)",
            "Hungary (HU)",
            "Indonesia (ID)",
            "Ireland (IE)",
            "Israel (IL)",
            "India (IN)",
            "Italy (IT)",
            "Japan (JP)",
            "South Korea (KR)",
            "Lithuania (LT)",
            "Latvia (LV)",
            "Morocco (MA)",
            "Mexico (MX)",
            "Malaysia (MY)",
            "Nigeria (NG)",
            "Netherlands (NL)",
            "Norway (NO)",
            "New Zealand (NZ)",
            "Philippines (PH)",
            "Poland (PL)",
            "Portugal (PT)",
            "Romania (RO)",
            "Serbia (RS)",
            "Russia (RU)",
            "Saudi Arabia (SA)",
            "Sweden (SE)",
            "Singapore (SG)",
            "Slovenia (SI)",
            "Slovakia (SK)",
            "Thailand (TH)",
            "Turkey (TR)",
            "Taiwan (TW)",
            "Ukraine (UA)",
            "United States (US)",
            "Venezuela (VE)",
            "South Africa (ZA)"
        };
    }

    /// <summary>
    ///     Sets value to be persisted.
    /// </summary>
    /// <param name="type">Persistence type.</param>
    /// <param name="data">Data to be stored.</param>
    public static void SetData(PersistenceType type, string data)
    {
        switch (type)
        {
            case PersistenceType.Dictionary:
                Dictionary = data;
                break;
            case PersistenceType.Thesaurus:
                Thesaurus = bool.Parse(data);
                break;
            case PersistenceType.Definition:
                Definition = bool.Parse(data); 
                break;
            case PersistenceType.CountryCode:
                CountryCode = data;
                break;
            case PersistenceType.Country:
                Country = data;
                break;
            case PersistenceType.NewsCategory:
                NewsCategory = data;
                break;
            case PersistenceType.NewsKeywords:
                NewsKeywords = data;
                break;
            case PersistenceType.NewsResults:
                NewsResults = int.Parse(data);
                break;
            case PersistenceType.ArticleUrl:
                ArticleUrl = data;
                break;
            case PersistenceType.ArticleDate:
                ArticlePublishDate = data;
                break;
            case PersistenceType.Name:
                Name = data;
                break;
            case PersistenceType.LastSong:
                LastSong = data;
                break;
        }
    }

    /// <summary>
    ///     Clears data passed by adding a PersistenceType array.
    /// </summary>
    /// <param name="types">Array of persistent data to clear.</param>
    public static void ClearData(PersistenceType[] types)
    {
        foreach (var t in types)
            ClearData(t);
    }

    /// <summary>
    ///     Clears data, should be used after every call to this class.
    /// </summary>
    /// <param name="type">Persistence type.</param>
    public static void ClearData(PersistenceType type)
    {
        switch (type)
        {
            case PersistenceType.Dictionary:
                Dictionary = string.Empty;
                break;
            case PersistenceType.Thesaurus:
                Thesaurus = false;
                break;
            case PersistenceType.Definition:
                Definition = false;
                break;
            case PersistenceType.CountryCode:
                CountryCode = string.Empty;
                break;
            case PersistenceType.Country:
                Country = string.Empty;
                break;
            case PersistenceType.NewsCategory:
                NewsCategory = string.Empty;
                break;
            case PersistenceType.NewsKeywords:
                NewsKeywords = string.Empty;
                break;
            case PersistenceType.NewsResults:
                NewsResults = 0;
                break;
            case PersistenceType.ArticleUrl:
                ArticleUrl = string.Empty;
                break;
            case PersistenceType.ArticleDate:
                ArticlePublishDate = string.Empty;
                break;
            case PersistenceType.Name:
                Name = string.Empty;
                break;
            case PersistenceType.LastSong:
                LastSong = string.Empty;
                break;
        }
    }

    public static void ClearData()
    {
        Dictionary = string.Empty;
        Country = string.Empty;
        NewsCategory = string.Empty;
        CountryCode = string.Empty;
        NewsResults = 0;
        ArticlePublishDate = string.Empty;
        ArticleUrl = string.Empty;
        Definition = false;
        Name = string.Empty;
        LastSong = string.Empty;
    }
}

/// <summary>
///     Type of data to be stored.
/// </summary>
public enum PersistenceType
{
    Dictionary,
    Thesaurus,
    Definition,
    CountryCode,
    Country,
    NewsCategory,
    NewsKeywords,
    NewsResults,
    ArticleDate,
    ArticleUrl,
    Name,
    LastSong
}