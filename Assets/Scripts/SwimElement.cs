using UnityEngine;

public class SwimElement : MonoBehaviour
{
    protected Vector3 position, currentPosition;
    public float speed = 1f;
    protected float livingTime;
    public int price;

    protected void Swim()
    {
        if (GetComponent<Transform>().position == position)
            position = ElementManager.instance.GetRandomPosition();

        if (GetComponent<Transform>().position.x <= position.x)
            GetComponent<SpriteRenderer>().flipX = false;
        else
            GetComponent<SpriteRenderer>().flipX = true;
        currentPosition = Vector3.MoveTowards(currentPosition, position, speed * Time.deltaTime);
        GetComponent<Transform>().position = currentPosition;
    }

    protected virtual void OnMouseDown()
    {
        GameManager.Coin += price;
        Destroy(gameObject);
    }
}
