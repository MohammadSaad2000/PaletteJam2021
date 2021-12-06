using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyfollowPL1 : MonoBehaviour

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
        Transform player1 = PlayerStateManager.mainInstance.player1;
        
        Transform combinedPlayer = PlayerStateManager.mainInstance.combinedPlayer;

        if (PlayerStateManager.isCombined())
        {
            currentTarget = combinedPlayer;
        }
        else
        {           
            currentTarget = player1; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = Vector3.MoveTowards(transform.position, currentTarget.position, followSpeed * Time.deltaTime);


        transform.position = new Vector2(move.x, move.y);
        XVel = (transform.position.x - prevPos.x) / Time.deltaTime;
        prevPos = transform.position;

    }
}