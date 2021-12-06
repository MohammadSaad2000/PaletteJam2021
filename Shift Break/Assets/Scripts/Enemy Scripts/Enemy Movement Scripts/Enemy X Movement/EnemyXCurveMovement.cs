using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyXCurveMovement : MonoBehaviour
{
    public AnimationCurve animationCurve;
    public float movementMultiplier = 1.0f;
    public bool isVelocity = false;


    private float timeSinceSpawn = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeSinceSpawn += Time.deltaTime;
        if (isVelocity)
            transform.position = new Vector2(transform.position.x + (animationCurve.Evaluate(timeSinceSpawn) * movementMultiplier) * Time.deltaTime, transform.position.y);
        else
            transform.position = new Vector2(animationCurve.Evaluate(timeSinceSpawn) * movementMultiplier, transform.position.y);

    }
}
