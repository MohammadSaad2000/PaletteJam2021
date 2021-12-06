using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public float playerHealth = 100.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TakeDamage(float damageAmount)
    {
        playerHealth -= damageAmount;
        if (playerHealth <= 0.0f)
        {
            playerHealth = 0.0f;
            Destroy(this.gameObject);
        }
    }

    void Heal(float healAmount)
    {
        playerHealth += healAmount;
        if (playerHealth > 100.0f)
            playerHealth = 100.0f;
    }
}
