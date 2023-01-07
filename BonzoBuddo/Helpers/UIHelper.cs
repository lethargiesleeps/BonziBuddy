namespace BonzoBuddo.Helpers;

/// <summary>
/// Static helper class for managing WinForm elements.
/// </summary>
public static class UIHelper
{

    /// <summary>
    /// Turn a list of WinForms controls either on or off.
    /// </summary>
    /// <param name="controls">Controls to be toggled.</param>
    /// <param name="on">True if controls should be visible, otherwise false</param>
    public static void ToggleControlVisibility (Control[] controls, bool on)
    {
        if (on)
            foreach (var c in controls)
                c.Visible = true;
        else 
            foreach (var c in controls)
                c.Visible = false;
    }

}