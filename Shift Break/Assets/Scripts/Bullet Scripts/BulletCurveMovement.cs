using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCurveMovement : MonoBehaviour
{

    public AnimationCurve xMovementCurve;
    public float curveMultiplier = 1.0f;
    public float YSpeed = 5.0f;
    public bool isInverted = false;
    public bool isVelocity = false;

    private Vector2 startPos;
    private float timeSinceSpawn = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceSpawn += Time.deltaTime;


        if (isVelocity)
            transform.position = new Vector2(transform.position.x + ((xMovementCurve.Evaluate(timeSinceSpawn)) * curveMultiplier) * Time.deltaTime, transform.position.y + YSpeed * Time.deltaTime);
        else
            transform.position = new Vector2((xMovementCurve.Evaluate(timeSinceSpawn) * curveMultiplier) + startPos.x, transform.position.y + YSpeed * Time.deltaTime);

    }
}
