namespace BonzoBuddo.Helpers;

/// <summary>
///     This class keeps track of any static information needed for function classes.
/// </summary>
public static class PersistenceHelper
{
    public static string Dictionary { get; private set; }

    /// <summary>
    ///     Sets value to be persisted.
    /// </summary>
    /// <param name="type">Persistence type.</param>
    /// <param name="data">Data to be stored.</param>
    public static void SetData(PersistenceType type, string data)
    {
        switch (type)
        {
            case PersistenceType.Dictionary:
                Dictionary = data;
                break;
        }
    }

    /// <summary>
    ///     Clears data, should be used after every call to this class.
    /// </summary>
    /// <param name="type">Persistence type.</param>
    public static void ClearData(PersistenceType type)
    {
        switch (type)
        {
            case PersistenceType.Dictionary:
                Dictionary = string.Empty;
                break;
        }
    }
}

/// <summary>
///     Type of data to be stored.
/// </summary>
public enum PersistenceType
{
    Dictionary
}