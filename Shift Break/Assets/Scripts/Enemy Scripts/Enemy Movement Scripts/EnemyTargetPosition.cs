using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetPosition : MonoBehaviour
{
    public float followSpeed = 2.0f;
    public Transform currentTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = Vector3.MoveTowards(transform.position, currentTarget.position, followSpeed * Time.deltaTime);


        transform.position = new Vector2(move.x, move.y);
     
    }
}
