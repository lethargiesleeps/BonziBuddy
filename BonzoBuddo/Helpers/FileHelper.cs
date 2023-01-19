using System.Diagnostics;
using BonzoBuddo.BonziAI;

namespace BonzoBuddo.Helpers;

/// <summary>
///     Instantiable helper class to write and load data for application persistence.
/// </summary>
public class FileHelper
{
    private readonly string _dataPath;
    private readonly string _folderPath;

    /// <summary>
    ///     Default constructor, sets folder and file path internally.
    /// </summary>
    public FileHelper()
    {
        _folderPath =
            $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\BonziBuddy\\";
        _dataPath = _folderPath + "bonzidata.txt";
    }

    /// <summary>
    ///     Checks if BonziBuddy folder exists.
    /// </summary>
    /// <returns>True if it exists, otherwise false.</returns>
    public bool CheckFolder()
    {
        return Directory.Exists(_folderPath);
    }

    /// <summary>
    ///     Check if bonzidata.txt file exists.
    /// </summary>
    /// <returns>True if it exists, otherwise false.</returns>
    public bool CheckDataFile()
    {
        return File.Exists(_dataPath);
    }

    /// <summary>
    ///     Opens and deserializes bonzidata.txt
    /// </summary>
    /// <returns>BonziData deserialized from file.</returns>
    /// <exception cref="Exception">Throws exception if program cannot open file.</exception>
    /// <see cref="BonziData" />
    public BonziData LoadData()
    {
        var parsedValues = new List<string>();
        if (!File.Exists(_dataPath)) throw new Exception("Could not load data!");
        try
        {
            var values = File.ReadAllLines(_dataPath);
            foreach (var v in values)
            {
                var p = v.Split(": ");
                parsedValues.Add(p[1]);
            }

            return new BonziData
            {
                Name = parsedValues[0],
                City = parsedValues[1],
                LastAccessed = DateTime.Now,
                DateCreated = DateTime.Parse(parsedValues[3])
            };
        }
        catch (IOException e)
        {
            Debug.WriteLine(e.Message);
        }

        throw new Exception("Could not load data!");
    }

    /// <summary>
    ///     Saves overwritten data to the file. Deletes file and creates a new one based on BonziData values.
    /// </summary>
    /// <param name="data">Data model to serialize.</param>
    public void SaveData(BonziData data)
    {
        string[] values =
        {
            $"name: {data.Name}",
            $"city: {data.City}",
            $"lastAccessed: {data.LastAccessed}",
            $"dateCreated: {data.DateCreated}"
        };

        try
        {
            File.WriteAllLines(_dataPath, values);
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            Debug.WriteLine(e.StackTrace);
        }
    }

    /// <summary>
    ///     Creates directories needed to save data.
    /// </summary>
    public void CreateDirectory()
    {
        Directory.CreateDirectory(_folderPath);
    }
}