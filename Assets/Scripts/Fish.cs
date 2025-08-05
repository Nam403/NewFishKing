using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class Fish : SwimElement
{
    [SerializeField] float startLivingTime = 20f;
    [SerializeField] int minPrice = 200;
    [SerializeField] int maxPrice = 500;

    private float grownTime = 15f;
    private float birthTime = 10f;
    private float oldTime = 5f;
    private float deathTime = 0f;

    private bool isGrown = false;
    private int childCount = 0;
    private bool changeColor = false;

    private Vector2 child = new Vector2(1f, 1f);
    private Vector2 mature = new Vector2(2f, 2f);

    private Color oldFish = new Color(0, 255, 15), fishColor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        livingTime = startLivingTime;
        if(livingTime > grownTime)
        {
            GetComponent<Transform>().localScale = child;
            price = minPrice;
        }
        else
        {
            GetComponent<Transform>().localScale = mature;
            price = maxPrice;
        }
        fishColor = GetComponent<SpriteRenderer>().color;
        position = currentPosition = GetComponent<Transform>().position;

        GetComponent<Rigidbody2D>().freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        Swim();
        CountDown();
    }

    private void CountDown()
    {
        if(ElementManager.GarbageAmount > 0)
        {
            livingTime -= Time.deltaTime * ElementManager.GarbageAmount;
        }
        else
        {
            livingTime -= Time.deltaTime;
        }
            
        if (livingTime <= grownTime && !isGrown)
        {
            GetComponent<Transform>().localScale = mature;
            price = maxPrice;
            isGrown = true;
        }

        if(livingTime <= birthTime && livingTime > oldTime &&  childCount == 0 && ElementManager.GarbageAmount == 0) 
        {
            ElementManager.instance.AddFry(GetComponent<Transform>().position);
            childCount++; 
        }

        if (livingTime <= oldTime)
        {
            if ((int)livingTime % 2 == 0 && !changeColor)
            {
                GetComponent<SpriteRenderer>().color = oldFish;
                changeColor = true;
            }
            else
                if ((int)livingTime % 2 == 0)
            {
                GetComponent<SpriteRenderer>().color = fishColor;
                changeColor = false;
            }
            price = (minPrice + maxPrice) / 2;
        }
        if (livingTime <= deathTime) Destroy(gameObject);
    }

    protected override void OnMouseDown()
    {
        Debug.Log("Sell fish");
        ElementManager.FishAmount--;
        base.OnMouseDown();
    }
}
