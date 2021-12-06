using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollider : MonoBehaviour
{


    public float damageAmount = 10.0f;

    ColorManager.GameColor gameColor;

    // Start is called before the first frame update
    void Start()
    {
        gameColor = GetComponent<ColorManager>().gameColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        ColorManager.GameColor colliderGameColor = collision.GetComponent<ColorManager>().gameColor;
        MaterialManager colliderMaterialManager = collision.GetComponent<MaterialManager>();
        if (colliderGameColor == ColorManager.GameColor.None)
            return;

        if (this.tag.Equals("PBullet"))
        {
            if (collision.tag.Equals("Enemy"))                
            {
                if (ColorManager.isOpposite(gameColor, colliderGameColor) || gameColor == ColorManager.GameColor.Purple) {
                    collision.SendMessage("TakeDamage", damageAmount);
                    Destroy(this.gameObject);
                } else if (ColorManager.isSame(gameColor, colliderGameColor))
                {
                    collision.SendMessage("TakeDamage", damageAmount / 2);
                    Destroy(this.gameObject);
                } else if (colliderGameColor == ColorManager.GameColor.Purple)
                {
                    collision.SendMessage("TakeDamage", damageAmount / 4);
                    Destroy(this.gameObject);
                }
            }
        } 
        else if (this.tag.Equals("EBullet"))
        {
            if (collision.tag.Equals("Player"))
            {
                if (colliderGameColor == ColorManager.GameColor.Purple)
                {
                    collision.SendMessage("TakeDamage", damageAmount);
                    if (gameColor == ColorManager.GameColor.Purple)
                        PlayerStateManager.mainInstance.depleteMeter(damageAmount);
                    else
                        PlayerStateManager.mainInstance.depleteMeter(damageAmount / 2);
                    Destroy(this.gameObject);

                } else if (ColorManager.isOpposite(gameColor, colliderGameColor) || gameColor == ColorManager.GameColor.Purple)
                {
                    collision.SendMessage("TakeDamage", damageAmount);
                    Destroy(this.gameObject);
                } else if (ColorManager.isSame(gameColor, colliderGameColor))
                {
                    PlayerStateManager.mainInstance.BuildMeter(damageAmount);
                    colliderMaterialManager.InitiateHitEffect(0.1f, ColorManager.getRenderColor(colliderGameColor));
                    Destroy(this.gameObject);
                }

            }
        }

    }

    
}
