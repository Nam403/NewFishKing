using UnityEngine;

public class ElementManager : MonoBehaviour
{
    public GameObject fishPrefab;
    public GameObject fryPrefab;
    public GameObject garbagePrefab;

    public int baseFishAmount = 1;

    public static int FishAmount;
    public static int GarbageAmount = 0;

    private Vector2 screenSize;
    private int pollutedTime;
    private bool isPolluted;

    public static ElementManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one ElementManager in scene!");
            return;
        }
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {}

    public void SetUp()
    {
        for (int i = 0; i < baseFishAmount + GameManager.Level / 2; i++)
        {
            AddFry(GetRandomPosition());
        }

        isPolluted = false;
        pollutedTime = (int)Random.Range(4, GameManager.Timer / 5 - 1) * 5; // Polluted time: from 20s to 50s (full game in 60s)
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Timer <= pollutedTime && isPolluted == false)
        {
            AddGarbage(GetRandomPosition());
            isPolluted = true;
        }
    }

    public void CleanAllElement()
    {
        DeleteAllWithTag("Fish");
        DeleteAllWithTag("Garbage");
        FishAmount = 0;
        GarbageAmount = 0;
    }

    void DeleteAllWithTag(string tag)
    {
        GameObject[] objectsToDelete = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject obj in objectsToDelete)
        {
            Destroy(obj);
        }
    }

    public Vector3 GetRandomPosition()
    {
        screenSize = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        return new Vector3(Random.Range(-screenSize.x, screenSize.x), Random.Range(-screenSize.y, screenSize.y - 2f), -1f);
    }

    public void AddFish(Vector2 fishPosition)
    {
        GameObject fish = Instantiate(fishPrefab, fishPosition, Quaternion.identity);
        fish.tag = "Fish";
        FishAmount++;
    }

    public void AddFry(Vector2 fryPosition)
    {
        GameObject fry = Instantiate(fryPrefab, fryPosition, Quaternion.identity);
        fry.tag = "Fish";
        FishAmount++;
    }

    public void AddGarbage(Vector2 garbagePosition)
    {
        GameObject garbage = Instantiate(garbagePrefab, garbagePosition, Quaternion.identity);
        garbage.tag = "Garbage";
        GarbageAmount++;
    }
}
