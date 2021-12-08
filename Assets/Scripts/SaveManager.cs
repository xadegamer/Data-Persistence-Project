using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    public static readonly string SAVE_FOLDER = Application.persistentDataPath + "/";
    public static string SAVE_EXTENSION = ".txt";


    public static void SavedData<T>(string fileName, T t)
    {
        string json = JsonUtility.ToJson(t);
        Save(fileName, json);
    }

    public static T LoadData<T>(string fileName)
    {
        string saveString = Load(fileName);
        if (saveString != null)
        {
            T t = JsonUtility.FromJson<T>(saveString);
            return t;
        }
        else return default(T);
    }

    public static void Save(string fileName, string saveString)
    {
        File.WriteAllText(string.Concat(SAVE_FOLDER, fileName, SAVE_EXTENSION), saveString);
    }

    public static string Load(string fileName)
    {
        if (File.Exists(SAVE_FOLDER + fileName + SAVE_EXTENSION))
        {
            string saveString = File.ReadAllText(string.Concat(SAVE_FOLDER, fileName, SAVE_EXTENSION));
            return saveString;
        }
        else return null;
    }
}
