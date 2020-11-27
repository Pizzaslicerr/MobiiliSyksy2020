//SaveStreamer.cs by Mikko Kyllönen
//reads from and writes save data to disk. Called upon when needed.

using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveStreamer
{
    //file path for save file.
    public static string path = Path.Combine(Application.persistentDataPath, "saveData.ll");

    //saves referenced SaveData file to disk.
    public static void SaveGame(SaveData saveData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, saveData);
        stream.Close();
    }

    //loads whatever formatted binary save data is on disk.
    public static SaveData LoadSave()
    {
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogWarning("File not found in " + path + ", using default save data values");
            return LoadDefaults();
        }
    }

    //creates dummy SaveData file and provides it as the default save file.
    //also inserts the default values as a brand new, blank save file to prevent errors.
    private static SaveData LoadDefaults()
    {
        SaveData dummyData = new SaveData();
        for (int i = 0; i < dummyData.LevelData.Length; i++)
        {
            dummyData.LevelData[i] = new LevelData();
            dummyData.LevelData[i].BuildIndex = i + 3;
        }

        SaveGame(dummyData);
        return dummyData;
    }
}
