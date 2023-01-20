using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace BonzoBuddo.Helpers;

/// <summary>
///     Static helper class for managing WinForm elements.
/// </summary>
public static class UiHelper
{
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