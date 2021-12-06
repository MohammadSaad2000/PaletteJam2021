using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemySpitter : MonoBehaviour
{

    public List<GameObject> enemiesToSpit;
    public Transform enemyOrigin;
    public float timeBetweenSpits = 1.0f;
    public int maxSpits = 5;

    private int currentSpits = 0;
    private float timeSinceLastSpit = 0.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (currentSpits > maxSpits)
            return;
        
        timeSinceLastSpit += Time.deltaTime;

        if (timeSinceLastSpit > timeBetweenSpits)
        {
            SpitEnemy();
            timeSinceLastSpit = 0.0f;
        }
    }

    void SpitEnemy()
    {
        Debug.Log("Spit");
        currentSpits++;
        GameObject randomEnemy = enemiesToSpit[Random.Range(0, enemiesToSpit.Count)];
        GameObject newEnemy = Instantiate(randomEnemy, enemyOrigin.position, Quaternion.identity);
        newEnemy.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        newEnemy.transform.DOScale(0.5f, 0.2f);

    }
}
