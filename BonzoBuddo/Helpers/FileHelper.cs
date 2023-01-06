using System.Diagnostics;
using BonzoBuddo.BonziAI;

namespace BonzoBuddo.Helpers;

public class FileHelper
{
    private readonly string _dataPath;
    private readonly string _folderPath;


    public FileHelper()
    {
        _folderPath =
            $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\BonziBuddy\\";
        _dataPath = _folderPath + "bonzidata.txt";
    }

    public bool CheckFolder()
    {
        return Directory.Exists(_folderPath);
    }

    public bool CheckDataFile()
    {
        return File.Exists(_dataPath);
    }

    public BonziData LoadData()
    {
        string[] values;
        var parsedValues = new List<string>();
        if (File.Exists(_dataPath))
            try
            {
                values = File.ReadAllLines(_dataPath);
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

    public void CreateDirectory()
    {
        Directory.CreateDirectory(_folderPath);
    }
}