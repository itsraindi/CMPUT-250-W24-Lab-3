using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DVDLogo : MonoBehaviour
{
    // Speed it moves at (✅ faster)
    public float speed = 80f;

    // Bounds of the screen
    public float X_Max = 3, Y_Max = 2;

    // Current direction
    private Vector3 direction;

    // For color change on bounce
    private SpriteRenderer sr;

    void Start()
    {
        // grab SpriteRenderer 
        sr = GetComponent<SpriteRenderer>();

        // Randomly initialize direction
        direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        direction.Normalize();
    }

    private void RandomizeColor()
    {
        // change color if we have a SpriteRenderer
        if (sr != null)
        {
            sr.color = Random.ColorHSV(0f, 1f, 0.8f, 1f, 0.8f, 1f);
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
