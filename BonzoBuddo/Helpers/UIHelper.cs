using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using BonzoBuddo.BonziAI.Speech;

namespace BonzoBuddo.Helpers;

/// <summary>
///     Static helper class for managing WinForm elements.
/// </summary>
public static class UiHelper
{
    public static bool RefreshCheckConnection(DateTime initDt)
    {
        bool returnValue = false;
        var timeDifference = DateTime.Now - initDt;
        if (timeDifference.Seconds > 45)
            returnValue = true;
        return returnValue;

    }
    public static bool CheckInternetConnection()
    {
        try
        {
            using var client = new WebClient();
            using var stream = client.OpenRead("http://google.com");
            return true;
        }
        catch
        {
            return false;
        }
    }
    public static string ParseIngredients(string ingredients)
    {
        var sb = new StringBuilder();
        for (var i = 0; i < ingredients.Length; i++)
        {
            if ( i != 0)
                if (char.IsNumber(ingredients[i - 1]))
                    sb.Append('\n');
            sb.Append(ingredients[i]);
        }
        return sb.ToString();
    }
    /// <summary>
    /// Checks if any word or phrase passed for API queries contains bad language.
    /// </summary>
    /// <param name="text">The text to be searched.</param>
    /// <returns>True if it has bad language, otherwise false.</returns>
    public static bool CheckForCussWords(string text)
    {
        var value = false;
        foreach (var cussWord in IllegalPhrases.CussWords())
        {
            if (!text.ToLower().Equals(cussWord.ToLower())) continue;
            value = true;
            break;
        }

        return value;
    }

    /// <summary>
    ///     Turn a list of WinForms controls either on or off.
    /// </summary>
    /// <param name="controls">Controls to be toggled.</param>
    /// <param name="on">True if controls should be visible, otherwise false</param>
    public static void ToggleControlVisibility(Control[] controls, bool on)
    {
        if (on)
            foreach (var c in controls)
                c.Visible = true;
        else
            foreach (var c in controls)
                c.Visible = false;
    }

    public static BonziHelper CreateCommandMenu(BonziHelper helper)
    {
        helper.Agent.Characters[helper.AgentName].Commands.Add("Joke", "Joke", null, true, true);
        helper.Agent.Characters[helper.AgentName].Commands.Add("Weather", "Weather", null, true, true);
        helper.Agent.Characters[helper.AgentName].Commands.Add("Fact", "Fact", null, true, true);
        helper.Agent.Characters[helper.AgentName].Commands.Add("Trivia", "Trivia", null, true, true);
        helper.Agent.Characters[helper.AgentName].Commands.Add("News", "News", null, true, true);
        helper.Agent.Characters[helper.AgentName].Commands.Add("Song", "Song", null, true, true);
        helper.Agent.Characters[helper.AgentName].Commands.Add("Riddle", "Riddle", null, true, true);
        helper.Agent.Characters[helper.AgentName].Commands.Add("Recipe", "Recipe", null, true, true);
        helper.Agent.Characters[helper.AgentName].Commands.Add("Dictionary", "Dictionary", null, true, true);
        helper.Agent.Characters[helper.AgentName].Commands.Add("Random Word", "Random Word", null, true, true);
        helper.Agent.Characters[helper.AgentName].Commands.Add("Information", "Information", null, true, true);
        helper.Agent.Characters[helper.AgentName].Commands.Add("Insult", "Insult", null, true, true);
        //helper.Agent.Characters[helper.AgentName].Commands.Add("Show Panel", "Show Control Panel", null, true, true);
        //helper.Agent.Characters[helper.AgentName].Commands.Add("Roll Dice", "Roll Dice", null, true, true);

        return helper;
    }

    /// <summary>
    ///     Opens a hyperlink using default browser.
    /// </summary>
    /// <param name="url">URL to be opened</param>
    public static void OpenUrl(string url)
    {
        try
        {
            Process.Start(url);
        }
        catch (Win32Exception ex)
        {
            Debug.WriteLine(ex.Message);
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                url = url.Replace("&", "^&");
                Process.Start(new ProcessStartInfo(url) {UseShellExecute = true});
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Process.Start("xdg-open", url);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Process.Start("open", url);
            }
            else
            {
                throw;
            }
        }
    }


    /// <summary>
    ///     Sequence of actions if user provides illegal words as a text parameter.
    /// </summary>
    /// <param name="helper">The form's BonziHelper.</param>
    /// <param name="form">The form to dispose of.</param>
    /// <param name="text">The illegal text in question</param>
    public static void HasCussWords(BonziHelper helper, Form form, TextBox text)
    {
        //TODO: Maybe refactor this into one method with HasCussWords
        var s = text.Text;
        if (new Random().Next(0, 5001) == 1234)
        {
            helper.Speak(
                $"{s}, {s}, {s}, {s}, {s}, {s}. I'm imitating you, {PersistenceHelper.Name!}! This is what you sound like you ignorant child!");
            helper.Play("Giggle");
            helper.Hide();
            form.Dispose();
            form.Close();
        }
        else
        {
            helper.Play("Unbelievable");
            helper.Speak(Phrases.ErrorMessages()["HasCussWords"]);
            text.Text = string.Empty;
        }
    }
}