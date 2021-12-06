using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
       
    public List<GameObject> enemyGroups;
    public List<float> spawnTimes;
    public List<Transform> spawnTransforms;

    Transform finalEnemy;
    private bool finalEnemySpawned = false;

    private float timeSinceLevelStart = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (finalEnemySpawned)
        {
            if (finalEnemy == null)
            {
                StartCoroutine("waitForSeconds", 3.0f);
            }
            return;
        }


        timeSinceLevelStart += Time.deltaTime;
        if (spawnTimes.Count == 0)
        {
            return;
        }
        if (timeSinceLevelStart > spawnTimes[0])
        {
            spawnTimes.RemoveAt(0);
            SpawnNextEnemyGroup();
        }

    }

    void SpawnNextEnemyGroup()
    {
        GameObject  enemyGroup = enemyGroups[0];
        Transform enemyGroupSpawnTransform = spawnTransforms[0];
        Transform temp = null;
        for (int i = 0; i < enemyGroup.transform.childCount; i++)
        {
            temp = Instantiate(enemyGroup.transform.GetChild(i), enemyGroupSpawnTransform);
            
        }
        enemyGroups.RemoveAt(0);
        spawnTransforms.RemoveAt(0);
        if (enemyGroups.Count == 0)
        {
            finalEnemy = temp;
            finalEnemySpawned = true;
        }

    }

    IEnumerator waitForSeconds(float duration)
    {

        yield return new WaitForSeconds(duration);
        GameStateManager.mainInstance.win();
    }

 
}
