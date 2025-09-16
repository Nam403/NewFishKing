using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour    
{
    public static GameManager Instance;

    public static int Level = 1;  
    public static float Timer = 60;
    public static bool GameIsOver;

    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] float startTime = 60;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] GameObject completeLevelUI;
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("More than one GameManager in scene!");
            return;
        }
        Instance = this;
    }

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
            CoinManager.Instance.SetUp(0);
        }
        else
        {
            if (level > Level)
            {
                Level = level;
                CoinManager.Instance.SetUp(1);
            }
            else
            {
                CoinManager.Instance.SetUp(-1);
            }
        }
        Timer = startTime;

        ElementManager.Instance.SetUp();
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
            ElementManager.Instance.CleanAllElement();
            if (CoinManager.Instance.GetTarget())
            {
                WinLevel();
            }
            else
            {
                EndGame();
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