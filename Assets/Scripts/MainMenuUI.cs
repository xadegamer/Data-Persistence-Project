using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenuUI : MonoBehaviour
{
    public static MainMenuUI Instance { get; private set; }

    public Text higestScoreDisplay;
    public InputField nameInputField;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SetHighScoreDisplay(GameManager.Instance.highestScoreName + " - " + GameManager.Instance.highestScore);
        SetPlayerNameDisplay(GameManager.Instance.playerName);
    }


    public void SetHighScoreDisplay(string info)
    {
        higestScoreDisplay.text = "Highest Score : " + info;
    }

    public void SetPlayerNameDisplay(string name)
    {
        nameInputField.text = name;
    }

    public void SetPlayerName(string name)
    {
        GameManager.Instance.playerName = name;
        GameManager.Instance.SaveStats();
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
