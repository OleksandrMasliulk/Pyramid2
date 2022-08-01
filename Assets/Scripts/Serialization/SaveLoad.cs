using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoad {
    public const string settingsProfilePath = "/SettingsProfile.bin";
    public const string playerDataPath = "/PlayerData.bin";

    public static void Save<T>(T dataToSave, string savePath) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + savePath;
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, dataToSave);
        stream.Close();
        Debug.Log("Data of " + dataToSave.GetType().ToString() + " type is saved!");
    }

    public static T Load<T>(string loadPath) {
        string path = Application.persistentDataPath + loadPath;
        Debug.Log(path);

        if (File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            T data = (T)formatter.Deserialize(stream);
            stream.Close();
            Debug.Log("Data of " + data.GetType().ToString() + " type is loaded!");

            return data;
        }
        else {
            Debug.Log("No data found at " + path + " path!");
            
            return default(T);
        }
    }
}
