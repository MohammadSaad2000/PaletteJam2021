using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyXSimpleMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
    }
}
