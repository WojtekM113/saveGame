 
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Platformer.SaveSystem;
using UnityEngine;
 

public class SerializationManager  
{
    public static bool Save(string saveName, object saveData)
    {
        BinaryFormatter binaryFormatter = GetBinaryFormatter();

        string saveFolderPath = Application.persistentDataPath + "/saves";

        if (!Directory.Exists(saveFolderPath))
        {
            Directory.CreateDirectory(saveFolderPath);
        }

        FileStream fileStream = File.Create($"{saveFolderPath}/{saveName}.save");
        
        binaryFormatter.Serialize(fileStream, saveData);

        fileStream.Close();
        return true;
    }

    public static object Load(string saveName)
    {
        BinaryFormatter binaryFormatter = GetBinaryFormatter();

        string saveFolderPath = Application.persistentDataPath + "/saves";

        if (!File.Exists($"{saveFolderPath}/{saveName}.save"))
        {
            Debug.Log("Nie znaleziono pliku");
            return null;
        }

        FileStream fileStream = File.Open($"{saveFolderPath}/{saveName}.save", FileMode.Open);

        try
        {
            object saveData = binaryFormatter.Deserialize(fileStream);
            fileStream.Close();
            return saveData;
        }
        catch
        {
            Debug.LogError($"Failed to load save file {saveName}");
            return null;
        }

    }

    public static BinaryFormatter GetBinaryFormatter()
    {
        BinaryFormatter binaryFormatter = new();

        SurrogateSelector surrogateSelector = new();

        SerializeVector3Surogate serializeVector3Surogate = new();
        surrogateSelector.AddSurrogate(typeof(Vector3), new StreamingContext(StreamingContextStates.All), serializeVector3Surogate);

        SerializeQuaternionSurogate serializeQuaternionSurogate = new();
        surrogateSelector.AddSurrogate(typeof(Quaternion), new StreamingContext(StreamingContextStates.All), serializeQuaternionSurogate);
        binaryFormatter.SurrogateSelector = surrogateSelector;
        
        return binaryFormatter;
    }
}


