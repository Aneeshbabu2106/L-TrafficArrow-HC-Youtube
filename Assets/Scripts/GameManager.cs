using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private const string MainMenu = "MainMenu";
    private const string Gameplay = "GamePlayScene";

    public void GotoMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(MainMenu);
    }
    public void GotoGameplay()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(Gameplay);
    }

}
