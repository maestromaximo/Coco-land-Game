using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    // The speed at which the cloud will move
    public float speed = 1.0f;

    // The maximum distance that the cloud can move before it wraps around to the other side of the screen
    public float maxDistance = 10.0f;

    // The direction in which the cloud will move
    public Vector3 direction = Vector3.right;

    // The starting position of the cloud
    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        // Save the starting position of the cloud
        startPosition = transform.position;

        // Start the movement coroutine
        StartCoroutine(MoveCloud());
    }

    // Update is called once per frame
    void Update()
    {
        //
    }

    // Coroutine that moves the cloud
    IEnumerator MoveCloud()
    {
        // Loop indefinitely
        while (true)
        {
            // Update the position of the cloud based on the speed and direction
            transform.position += direction * speed * Time.deltaTime;

            // If the cloud has moved beyond the maximum distance, wrap it around to the other side of the screen
            if (Vector3.Distance(transform.position, startPosition) > maxDistance)
            {
                transform.position = startPosition;
            }

            // Wait for the next frame
            yield return null;
        }
    }
}

