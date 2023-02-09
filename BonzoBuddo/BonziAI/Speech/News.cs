using BonzoBuddo.Helpers;

namespace BonzoBuddo.BonziAI.Speech;

/// <summary>
///     Speech pattern used for news articles.
/// </summary>
public class News : Speech
{
    /// <summary>
    ///     Required constructor
    /// </summary>
    /// <param name="keyWords">Search keywords.</param>
    /// <param name="countryCode">Country code.</param>
    /// <param name="category">Article's topic category</param>
    public News(string? keyWords, string? countryCode, string? category)
    {
        if (keyWords != null && countryCode != null && category != null)
            PhraseDictionary = ApiHelper.GetNews(keyWords, countryCode, category);
        else throw new ArgumentNullException(nameof(keyWords) + nameof(countryCode) + nameof(category));
    }

    /// <summary>
    /// Method unsupported by implementation.
    /// </summary>
    /// <param name="index">Not used.</param>
    /// <returns>See exception.</returns>
    /// <exception cref="NotSupportedException">Throws if this method is used with this child class.</exception>
    public override string GetPhrase(int index) => throw new NotSupportedException("Use GetPhrase(string key) instead.");

    /// <summary>
    /// Method unsupported by implementation.
    /// </summary>
    /// <returns>See exception.</returns>
    /// <exception cref="NotSupportedException">Throws if this method is used with this child class.</exception>
    public override string GetRandomPhrase() => throw new NotSupportedException("Use GetPhrase(string key) instead.");

    public override List<string> GetPhraseList() => throw new NotSupportedException("This subclass cannot use this method.");
}