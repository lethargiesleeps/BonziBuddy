namespace BonzoBuddo.Helpers;

public static class UIHelper
{
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