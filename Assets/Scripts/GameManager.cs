using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Init();
            return;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public bool Isinitialized { get; set; }
    public int CurrentScore { get; set; }
    private const string highScoreKey = "HighScore";

    public int HighScore
    {
        get
        {
            return PlayerPrefs.GetInt(highScoreKey, 0);
        }
        set
        {
            PlayerPrefs.SetInt(highScoreKey, value);
        }
    }

    private void Init()
    {
        Isinitialized = false;
        CurrentScore = 0;
    }
    private string MainMenu = "MainMenu";
    private string Gameplay = "GamePlayScene";

    public void GotoMainMenu()
    {
        SceneManager.LoadScene(MainMenu);
    }
    public void GotoGameplay()
    {
        Debug.Log("called");
        SceneManager.LoadScene(1);
        Debug.Log("ended");
    }

}
