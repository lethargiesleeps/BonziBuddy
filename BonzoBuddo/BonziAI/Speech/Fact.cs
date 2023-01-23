using System.Text;
using BonzoBuddo.Helpers;

namespace BonzoBuddo.BonziAI.Speech;

/// <summary>
///     Speech pattern for facts.
/// </summary>
public class Fact : Speech
{
    /// <summary>
    ///     Constructor. Sets Phrase List
    /// </summary>
    /// <param name="name">User's name</param>
    public Fact(string name)
    {
        PhraseList = Phrases.PostFact(name);
    }

    /// <summary>
    ///     Uses ApiHelper to get a fact using Ninja APIs.
    /// </summary>
    /// <returns>A fact as a string for Bonzi to say</returns>
    public override string GetPhrase()
    {
        var returnValue = new StringBuilder();
        returnValue.Append("Did you know that ");
        var fact = ApiHelper.GetFact();
        foreach (var c in fact.Where(c => !c.Equals('"')))
            if (fact.IndexOf(c) == 1)
            {
                var lowerChar = char.ToLower(c);
                returnValue.Append(lowerChar);
            }
            else
            {
                returnValue.Append(c);
            }

        return returnValue.ToString();
    }

    public override string GetRandomPhrase()
    {
        RandomNumberHelper.SetIndex(PhraseList);
        return PhraseList![RandomNumberHelper.CurrentValue];
    }

    /// <summary>
    ///     Method unsupported by implementation.
    /// </summary>
    /// <returns>See exception.</returns>
    /// <exception cref="NotSupportedException">Throws if this method is used with this child class.</exception>
    public override Dictionary<string, string> GetPhraseDictionary()
    {
        throw new NotSupportedException("Use GetPhraseList");
    }

    /// <summary>
    ///     Method unsupported by implementation.
    /// </summary>
    /// <param name="key">Not used.</param>
    /// <returns>See exception</returns>
    /// <exception cref="NotSupportedException">Throws if this method is used with this child class.</exception>
    public override string GetPhrase(string key)
    {
        throw new NotSupportedException("Use parameter-less GetPhrase()");
    }

    /// <summary>
    ///     Method unsupported by implementation.
    /// </summary>
    /// <param name="index">Not used.</param>
    /// <returns>See exception</returns>
    /// <exception cref="NotSupportedException">Throws if this method is used with this child class.</exception>
    public override string GetPhrase(int index)
    {
        throw new NotSupportedException("Use parameter-less GetPhrase()");
    }
}