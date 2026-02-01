using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 pointA;
    public Vector3 pointB;
    public float speed = 2f;

    private bool goingToB = true;

    void Update()
    {
        if (goingToB)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointB, speed * Time.deltaTime);
            if (transform.position == pointB) goingToB = false;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, pointA, speed * Time.deltaTime);
            if (transform.position == pointA) goingToB = true;
        }
    }
}
