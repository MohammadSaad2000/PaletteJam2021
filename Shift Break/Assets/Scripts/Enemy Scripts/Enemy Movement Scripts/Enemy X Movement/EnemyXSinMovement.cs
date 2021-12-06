using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyXSinMovement : MonoBehaviour
{
    public float frequency = 2.0f;
    public float amplitude = 2.0f;
    public bool isInverted = false;

    private Vector2 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float sinMovement = Mathf.Sin(Time.time * frequency) * amplitude;
        if (isInverted)
        {
            sinMovement *= -1;
        }

        transform.position = new Vector2(sinMovement + startPosition.x, transform.position.y);
    }
}
