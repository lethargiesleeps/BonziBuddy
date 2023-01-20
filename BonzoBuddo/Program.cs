namespace BonzoBuddo;

/// <summary>
///     Main program execution.
/// </summary>
internal static class Program
{
    /// <summary>
    ///     The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        var bonzi = new BonziBuddyControlPanel();
        Application.Run();
    }
}