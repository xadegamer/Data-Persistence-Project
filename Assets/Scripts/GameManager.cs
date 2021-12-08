using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [System.Serializable]
    public class SaveData
    {
        public string Saved_playerName;
        public string Saved_highestScoreName;
        public int Saved_highestScore;
    }

    public string playerName;
    public string highestScoreName;
    public int highestScore;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);

        LoadStats();
    }

    public void SaveStats()
    {
        SaveData currentSaveData = new SaveData();
        currentSaveData.Saved_playerName = playerName;
        currentSaveData.Saved_highestScore = highestScore;
        currentSaveData.Saved_highestScoreName = highestScoreName;

        SaveManager.SavedData<SaveData>("Player Stats", currentSaveData);
    }

    public void LoadStats()
    {
        SaveData loadedSaveData = SaveManager.LoadData<SaveData>("Player Stats");

        if(loadedSaveData != null)
        {
            playerName = loadedSaveData.Saved_playerName;
            highestScore = loadedSaveData.Saved_highestScore;
            highestScoreName = loadedSaveData.Saved_highestScoreName;
        }
    }
}
