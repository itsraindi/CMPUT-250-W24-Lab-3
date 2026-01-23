using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DVDLogo : MonoBehaviour
{
    // Speed it moves at (✅ faster)
    public float speed = 2;

    // Bounds of the screen
    public float X_Max = 6, Y_Max = 5;

    // Current direction
    private Vector3 direction;

    void Start()
    {

        // Randomly initialize direction
        direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        direction.Normalize();
    }

    private void RandomizeColor()
    {
    if (Camera.main != null)
    {
        Camera.main.backgroundColor = Random.ColorHSV(0f, 1f, 0.6f, 1f, 0.6f, 1f);
    }
    }

    private void FlipDirectionX()
    {
        direction.x *= -1;
        direction.x += Random.Range(-0.1f, 0.1f);
        direction.y += Random.Range(-0.1f, 0.1f);
        direction.Normalize();

        // color change on bounce
        RandomizeColor();
    }

    private void FlipDirectionY()
    {
        direction.y *= -1;
        direction.x += Random.Range(-0.1f, 0.1f);
        direction.y += Random.Range(-0.1f, 0.1f);
        direction.Normalize();

        // color change on bounce
        RandomizeColor();
    }

    void Update()
    {
        Vector3 newPosition = transform.position + direction * Time.deltaTime * speed;

        // Bounce check
        if (newPosition.x > X_Max || newPosition.x < -X_Max)
        {
            FlipDirectionX();
        }

        if (newPosition.y > Y_Max || newPosition.y < -Y_Max)
        {
            FlipDirectionY();
        }

        transform.position += direction * Time.deltaTime * speed;
    }
}
