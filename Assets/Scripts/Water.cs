using UnityEngine;

public class Water : MonoBehaviour
{
    private float initPosition;
    private Vector2 position;

    [SerializeField] float speed = 0.005f;
    [SerializeField] float target = 5.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initPosition = GetComponent<Transform>().position.x;
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
