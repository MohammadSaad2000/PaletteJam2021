using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    public List<GameObject> bulletPrefabs;
    public List<Transform> bulletOrigin;
    public Vector2 bulletScale = new Vector2(1, 1);
    public float timeBetweenBullets = 0.1f;
    public Color bulletColor = new Color(0, 0, 0, 1);


    AudioSource shootSound;
    
    ColorManager.GameColor playerGameColor;

    private float timeElapsedSinceLastBullet = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        shootSound = GameObject.Find("Shoot").GetComponent<AudioSource>();
        playerGameColor = this.GetComponent<ColorManager>().gameColor;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsedSinceLastBullet += Time.deltaTime;
        if (timeElapsedSinceLastBullet > timeBetweenBullets)
        {
            Shoot();
            timeElapsedSinceLastBullet = 0.0f;
        }
    }

    void Shoot()
    {
        for(int i = 0; i < bulletPrefabs.Count; i++)
        {
            GameObject bullet = bulletPrefabs[i];
            SpriteRenderer bulletSpriteRenderer = bullet.GetComponent<SpriteRenderer>();
            ColorManager bulletColorManager = bullet.GetComponent<ColorManager>();
            bulletSpriteRenderer.color = bulletColor;
            bulletColorManager.gameColor = this.playerGameColor;

            BulletSimpleMovement simpleBullet = bullet.GetComponent<BulletSimpleMovement>();
            if (bullet.GetComponent<BulletSimpleMovement>() != null)
            {
                simpleBullet.moveDirection = bulletOrigin[i].transform.up;
            }
            bullet.transform.localScale = bulletScale;
            if (this.tag.Equals("Player"))
            {
                bullet.tag = "PBullet";
                AudioSource srcTemp = Instantiate(shootSound, this.transform);
                srcTemp.Play();
                
            }
            else
                bullet.tag = "EBullet";
            Instantiate(bullet, bulletOrigin[i].TransformPoint(Vector2.zero), Quaternion.identity);
        }
        
    }

}
