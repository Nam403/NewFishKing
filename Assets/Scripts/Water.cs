using UnityEngine;

public class Water : MonoBehaviour
{
    private float initPosition;
    private Vector2 position;
    public float speed = 0.005f, speedH = 0.001f;
    public float target = 5.6f;
    private float minHeight, maxHeight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initPosition = GetComponent<Transform>().position.x;
        minHeight = GetComponent<Transform>().position.y;
        maxHeight = minHeight + 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Transform>().position.x + target >= initPosition)
        {
            position = GetComponent<Transform>().position;
            position.x -= speed;
            GetComponent<Transform>().position = position;
        }
        else
        {
            position = GetComponent<Transform>().position;
            position.x = initPosition;
            GetComponent<Transform>().position = position;
        }
    }
}
