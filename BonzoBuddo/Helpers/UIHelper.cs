using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using BonzoBuddo.BonziAI.Songs;
using BonzoBuddo.BonziAI.Speech;
using DoubleAgent.Control;
using Control = System.Windows.Forms.Control;

namespace BonzoBuddo.Helpers;

/// <summary>
///     Static helper class for managing WinForm elements.
/// </summary>
public static class UiHelper
{
    
    public static bool CheckForCussWords(string text)
    {
        return IllegalPhrases.CussWords().Any(c => text.Contains(c) || text.Equals(c));
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
        helper.Agent.Characters[helper.AgentName].Commands.Add("Show Panel", "Show Control Panel", null, true, true);

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
}