using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyRandomMove : MonoBehaviour
{
    public float timeBetweenMoves = 5.0f;

    private float timeSinceLastMove = 0.0f;
    

    // Update is called once per frame
    void Update()
    {
        timeSinceLastMove += Time.deltaTime;
        
        if (timeSinceLastMove > timeBetweenMoves)
        {
            float spawnY = Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
            float spawnX = Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);

            Vector2 spawnPosition = new Vector2(spawnX, spawnY);

            transform.DOMove(spawnPosition, 1.0f);


            timeSinceLastMove = 0.0f;
        }
    }
}
