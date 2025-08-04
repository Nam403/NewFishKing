using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour    
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one GameManager in scene!");
            return;
        }
        instance = this;
    }

    public static int Level = 1;
    public static int Coin = 0;
    public static float Timer = 60;
    public static int Target = 1500;
    public static bool GameIsOver;

    private int OldCoin = 0;

    public TextMeshProUGUI timeText;
    public TextMeshProUGUI levelText;

    public int startCoin = 1000;    
    public float startTime = 60;

    public GameObject gameOverUI;
    public GameObject completeLevelUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetUp(1);
    }

    public void SetUp(int level)
    {
        GameIsOver = false;
        if (level == 1)
        {
            Level = 1;
            Coin = startCoin;
            OldCoin = startCoin;
        }
        else
        {
            if (level > Level)
            {
                Level = level;
                OldCoin = Coin;
            }
            else
            {
                Coin = OldCoin;
            }
        }
        Target = Coin / 100 * 150;
        Timer = startTime;

        ElementManager.instance.SetUp();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameIsOver)
        {
            return;
        }

        if(Timer <= 0)
        {
            GameIsOver = true;
            ElementManager.instance.CleanAllElement();
            if (Coin < Target)
            {
                EndGame();
            }
            else
            {
                WinLevel();
            }
        }

        Timer -= Time.deltaTime;
        Timer = Mathf.Clamp(Timer, 0f, Mathf.Infinity);
        
        timeText.text = "Time: " + string.Format("{0:00.00}", Timer);
        levelText.text = "Level: " + Level.ToString();
    }

    void EndGame()
    { 
        gameOverUI.SetActive(true);
    }

    void WinLevel()
    {
        completeLevelUI.SetActive(true);
    }
}
