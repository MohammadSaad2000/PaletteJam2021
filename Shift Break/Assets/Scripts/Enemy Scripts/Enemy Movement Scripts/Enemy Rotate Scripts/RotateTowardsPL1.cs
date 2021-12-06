using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsPL1 : MonoBehaviour
{
    public float rotateSpeed = 20.0f;

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
        if (currentTarget == null)
            return;


        Vector2 direction = (currentTarget.position - transform.position).normalized;

        Quaternion targetLookRotation = Quaternion.LookRotation(Vector3.forward, direction);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetLookRotation, rotateSpeed * Time.deltaTime);
    }
}