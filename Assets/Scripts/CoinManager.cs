using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("More than one CoinManager in scene!");
            return;
        }
        Instance = this;
    }

    [SerializeField] TextMeshProUGUI coinText;
    [SerializeField] TextMeshProUGUI targetText;

    [SerializeField] int fishPrice = 500;
    [SerializeField] int pryPrice = 200;
    [SerializeField] int startCoin = 1000;

    public static int Coin = 0;
    public static int Target = 1500;
    
    private int OldCoin = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {}

    // Update is called once per frame
    void Update()
    {
        coinText.text = Coin.ToString();
        targetText.text = "Target: " + Target.ToString();
    }

    public void SetUp(int code)
    {
        if(code == 0) // Init game
        {
            Coin = startCoin;
            OldCoin = startCoin;
        }
        else if(code == -1) // Retry
        {
            Coin = OldCoin;
        }
        else if(code == 1) // Next level
        {
            OldCoin = Coin;
        }
        Target = Coin / 100 * 150;
    }

    public bool GetTarget()
    {
        return Coin >= Target;
    }

    public void BuyAFish()
    {
        if(Coin >= fishPrice)
        {
            Coin -= fishPrice;
            ElementManager.Instance.AddFish(ElementManager.Instance.GetRandomPosition());
        }
    }

    public void BuyAFry()
    {
        if (Coin >= pryPrice)
        {
            Coin -= pryPrice;
            ElementManager.Instance.AddFry(ElementManager.Instance.GetRandomPosition());
        }
    }
}
