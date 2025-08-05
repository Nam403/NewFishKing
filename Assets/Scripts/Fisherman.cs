using UnityEngine;

public class Fisherman : MonoBehaviour
{
    [SerializeField] float maxUpDown = 0.2f;
    [SerializeField] float level = 0.01f;
    private Vector3 initPosition, curPosition;
    private int state = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initPosition = curPosition = GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == 0)
        {
            if (curPosition.y < initPosition.y + maxUpDown)
            {
                curPosition.y += level;
                GetComponent<Transform>().position = curPosition;
            }
            else state = 1;
        }
        else if (state == 1)
        {
            if (curPosition.y > initPosition.y - maxUpDown)
            {
                curPosition.y -= level;
                GetComponent<Transform>().position = curPosition;
            }
            else state = 0;
        }

    }
}
