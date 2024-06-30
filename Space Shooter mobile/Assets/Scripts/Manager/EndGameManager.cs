using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;
using System.Net.Sockets;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    public static EndGameManager endManager;
    public bool gameOver;

    private PanelController panelController;
    private TextMeshProUGUI scoreTextComponent;

    [HideInInspector]
    public string lvUnlock = "LevelUnlock";
    private int score;
    // Start is called before the first frame update
    private void Awake()
    {
        if(endManager == null)
        {
            endManager = this;
            DontDestroyOnLoad(gameObject);
        }
        
        else
            Destroy(gameObject);
    }
    void Start()
    {
        
    }
    public void UpdateScore(int addScore)
    {
        score += addScore;
        scoreTextComponent.text = "Score: " + score.ToString();
        }
    public void StartResolveSequence()
    {
        StopCoroutine(nameof(ResolveSequence));
        StartCoroutine(ResolveSequence());
    }
    private IEnumerator ResolveSequence()
    {
        yield return new WaitForSeconds(2);
        GameResult();
    }
    public void GameResult()
    {
        if(gameOver == false)
        {
            WinGame();
        }   
        else
            LoseGame();
    }
    public void WinGame()
    {
        ScoreSet();
        panelController.ActivateWin();
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        if(nextLevel > PlayerPrefs.GetInt(lvUnlock, 0))
        {
            PlayerPrefs.SetInt(lvUnlock, nextLevel);

        }
    }
    public void LoseGame()
    {
        ScoreSet();
        panelController.ActivateLose();
    }
    private void ScoreSet()
    {
        PlayerPrefs.SetInt("Score" + SceneManager.GetActiveScene().name,score);
        int highScore = PlayerPrefs.GetInt("HighScore" + SceneManager.GetActiveScene().name, 0);
        if(score > highScore)
        {
            PlayerPrefs.SetInt("HighScore" + SceneManager.GetActiveScene().name,score);
        }
        score = 0;
    }
    public void RegisterPanelController(PanelController pC)
    {
        panelController = pC;
    }
    public void RegistorScoreText(TextMeshProUGUI scoreText)
    {
        scoreTextComponent = scoreText;
    }
}
