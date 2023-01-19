using System.Diagnostics;
using BonzoBuddo.Helpers;

namespace BonzoBuddo.BonziAI.Speech;

/// <summary>
/// Speech pattern used for news articles.
/// </summary>
public class News : Speech
{
   
    /// <summary>
    /// Required constructor
    /// </summary>
    /// <param name="keyWords">Search keywords.</param>
    /// <param name="countryCode">Country code.</param>
    /// <param name="category">Article's topic category</param>
    public News(string keyWords, string countryCode, string category)
    {
        PhraseDictionary = ApiHelper.GetNews(keyWords, countryCode, category);
    }

    

   

    
}