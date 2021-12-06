using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSimpleMovement : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public Vector2 moveDirection = new Vector2(0, 1);
    public bool rotateTowardsMovementDirection = true;

    // Start is called before the first frame update
    void Start()
    {
        moveDirection = moveDirection.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        if (rotateTowardsMovementDirection)
            transform.rotation = Quaternion.LookRotation(Vector3.forward, moveDirection);

        transform.position = new Vector2(transform.position.x, transform.position.y) + (moveDirection * moveSpeed) * Time.deltaTime;
    }

   
}
