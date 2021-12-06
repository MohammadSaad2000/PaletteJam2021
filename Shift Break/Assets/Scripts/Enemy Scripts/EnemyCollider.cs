using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{

    public float damageAmount = 10.0f;

    ColorManager.GameColor gameColor;

    // Start is called before the first frame update
    void Start()
    {
        gameColor = GetComponent<ColorManager>().gameColor; ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag.Equals("Player"))
        {
            ColorManager.GameColor hitGameColor = collision.GetComponent<ColorManager>().gameColor;

            if (ColorManager.isSame(this.gameColor, hitGameColor) || hitGameColor == ColorManager.GameColor.Purple)
            {
                collision.SendMessage("TakeDamage", damageAmount);
                Debug.Log("Player Hit: Same Color");
            } else if (ColorManager.isOpposite(this.gameColor, hitGameColor))
            {
                collision.SendMessage("TakeDamage", damageAmount * 2.0f);
                Debug.Log("Player Hit: Opposite Color.");
            }
            
            Destroy(this.gameObject);
        }
    }
}
