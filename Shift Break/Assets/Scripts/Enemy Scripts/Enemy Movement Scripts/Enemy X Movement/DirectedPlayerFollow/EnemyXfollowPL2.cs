using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyXfollowPL2 : MonoBehaviour
{
    public float followSpeed = 2.0f;

    private bool missed = false;
    private float XVel;
    private float storedXVel;
    private Vector2 prevPos;
    private Transform currentTarget;
    // Start is called before the first frame update
    void Start()
    {
        Transform player2 = PlayerStateManager.mainInstance.player2;

        Transform combinedPlayer = PlayerStateManager.mainInstance.combinedPlayer;

        if (PlayerStateManager.isCombined())
        {
            currentTarget = combinedPlayer;
        }
        else
        {
            currentTarget = player2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = Vector3.MoveTowards(transform.position, currentTarget.position, followSpeed * Time.deltaTime);


        if (!missed && currentTarget.position.y > transform.position.y)
        {
            storedXVel = XVel;
            missed = true;
        }

        if (missed)
        {
            transform.position = new Vector2(transform.position.x + storedXVel * Time.deltaTime, transform.position.y);
            return;
        }


        transform.position = new Vector2(move.x, transform.position.y);
        XVel = (transform.position.x - prevPos.x) / Time.deltaTime;
        prevPos = transform.position;

    }
}
