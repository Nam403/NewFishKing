using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI targetText;

    public int fishPrice = 500;
    public int pryPrice = 200;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = GameManager.Coin.ToString();
        targetText.text = "Target: " + GameManager.Target.ToString();
    }

    public void BuyAFish()
    {
        if(GameManager.Coin >= fishPrice)
        {
            GameManager.Coin -= fishPrice;
            ElementManager.instance.AddFish(ElementManager.instance.GetRandomPosition());
        }
    }

    public void BuyAFry()
    {
        if (GameManager.Coin >= pryPrice)
        {
            GameManager.Coin -= pryPrice;
            ElementManager.instance.AddFry(ElementManager.instance.GetRandomPosition());
        }
    }
}
