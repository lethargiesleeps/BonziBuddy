using BonzoBuddo.Helpers;

namespace BonzoBuddo.BonziAI.Speech;

/// <summary>
///     Primary concrete implementation of ISpeakable interface. Contains default methods for retrieving Bonzi's speech.
///     <see cref="ISpeakable" />
/// </summary>
public class Speech : ISpeakable
{
    /// <summary>
    ///     Default constructor, used to override default behaviour.
    /// </summary>
    public Speech()
    {
    }

    /// <summary>
    ///     Constructor, sets the phrase list and defaults the phrase dictionary.
    /// </summary>
    /// <param name="phrases">List of phrases to be used in child class.</param>
    /// <see cref="Phrases" />
    public Speech(List<string> phrases)
    {
        PhraseList = phrases;
        PhraseDictionary = new Dictionary<string, string>();
    }

    /// <summary>
    ///     Constructor, sets the phrase dictionary and defaults the phrase list.
    /// </summary>
    /// <param name="phrases">Dictionary of phrases to be used in child class.</param>
    /// <see cref="Phrases" />
    public Speech(Dictionary<string, string> phrases)
    {
        PhraseDictionary = phrases;
        PhraseList = new List<string>();
    }

    protected List<string> PhraseList { get; set; }
    protected Dictionary<string, string> PhraseDictionary { get; set; }

    /// <summary>
    ///     Generates a random index and uses it to return a phrase.
    /// </summary>
    /// <returns>A random phrase based on the size of the phrase list passed.</returns>
    /// <see cref="RandomNumberHelper" />
    public virtual string GetRandomPhrase()
    {
        RandomNumberHelper.SetIndex(PhraseList);
        return PhraseList[RandomNumberHelper.CurrentValue];
    }

    /// <summary>
    ///     Gets a phrase from phrase list at specified index.
    /// </summary>
    /// <param name="index">Index of phrase within a list.</param>
    /// <returns>The phrase at provided position within the phrase list.</returns>
    public virtual string GetPhrase(int index)
    {
        return PhraseList[index];
    }

    /// <summary>
    ///     Gets a phrase from dictionary with the key passed as an argument.
    /// </summary>
    /// <param name="key">TKey to retrieve TValue</param>
    /// <returns>TValue from TKey within phrase dictionary.</returns>
    public virtual string GetPhrase(string key)
    {
        return PhraseDictionary[key];
    }

    /// <summary>
    ///     Returns a specific phrase, phrase is set in child class.
    /// </summary>
    /// <returns>The specific phrase, otherwise defaults.</returns>
    public virtual string GetPhrase()
    {
        return "Hi there!";
    }

    /// <summary>
    ///     Returns phrase list outside of a child class, as it is protected by default.
    /// </summary>
    /// <returns>A list of set phrases.</returns>
    public virtual List<string> GetPhraseList()
    {
        return PhraseList;
    }

    /// <summary>
    ///     Returns phrase dictionary outside of a child class, as it is protected by default.
    /// </summary>
    /// <returns>A key/value pair of phrases.</returns>
    public virtual Dictionary<string, string> GetPhraseDictionary()
    {
        return PhraseDictionary;
    }

    /// <summary>
    ///     Overrides the dictionary if it contains one or more entries.
    /// </summary>
    /// <param name="dictionary">The dictionary to set.</param>
    /// <exception cref="ArgumentNullException">Throws if dictionary is empty.</exception>
    public virtual void SetDictionary(Dictionary<string, string> dictionary)
    {
        if (dictionary is {Count: > 0})
            PhraseDictionary = dictionary;
        else
            throw new ArgumentNullException("dictionary is null or empty");
    }

    /// <summary>
    ///     Overrides the list if it contains one or more entries.
    /// </summary>
    /// <param name="list">The list to set.</param>
    /// <exception cref="ArgumentNullException">Throw if list is empty.</exception>
    public virtual void SetList(List<string> list)
    {
        if (list is {Count: > 0})
            PhraseList = list;
        else
            throw new ArgumentNullException("list is null or empty");
    }
}