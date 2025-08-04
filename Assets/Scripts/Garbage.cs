using UnityEngine;
using UnityEngine.InputSystem.XR;

public class Garbage : SwimElement
{
    public float cloneTime = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        livingTime = cloneTime;
        price = 50;
        GetComponent<Transform>().localScale = new Vector2(0.2f, 0.2f);
        position = currentPosition = GetComponent<Transform>().position;

        GetComponent<Rigidbody2D>().freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        Swim();
        Countdown();
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fish"))
        {
            Destroy(collision.gameObject);
        }
    }*/

    private void Countdown()
    {
        livingTime -= Time.deltaTime;
        if (livingTime <= 0)
        {
            livingTime = cloneTime;
            ElementManager.instance.AddGarbage(GetComponent<Transform>().position);
        }
    }

    protected override void OnMouseDown()
    {
        Debug.Log("Destroy Garbage");
        ElementManager.GarbageAmount--;
        base.OnMouseDown();
    }
}
