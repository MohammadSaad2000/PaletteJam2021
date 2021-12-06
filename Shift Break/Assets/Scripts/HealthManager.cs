using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    

    public float maxHealth = 100.0f;
    public Slider sliderUI;
    public Color hitColor = new Color(1, 1, 1, 1);
    AudioSource bugDeathSound;
    AudioSource playerDeathSound;

    MaterialManager materialManager;
    ColorManager colorManager;

    private float currentHealth;


    // Start is called before the first frame update
    void Start()
    {
        bugDeathSound = GameObject.Find("Bug Death").GetComponent<AudioSource>();
        playerDeathSound = GameObject.Find("Player Death").GetComponent<AudioSource>();
        materialManager = GetComponent<MaterialManager>();
        colorManager = GetComponent<ColorManager>();
        currentHealth = maxHealth;
        if (sliderUI != null)
            sliderUI.value = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {

    }


    void TakeDamage(float damageAmount)
    {
        materialManager.InitiateHitEffect(0.1f, hitColor);

        if (tag.Equals("Player") && colorManager.gameColor == ColorManager.GameColor.Purple)
            return;

        currentHealth -= damageAmount;
        if (currentHealth <= 0.0f)
        {
            currentHealth = 0.0f;
            if (this.tag.Contains("Player"))
            {
                
                playerDeathSound.Play();
                GameStateManager.mainInstance.lose();
                Destroy(this.gameObject);
            } else
            {
                bugDeathSound.Play();
                Destroy(this.gameObject);
            }
        }
        if (sliderUI != null)
        {
            sliderUI.value = currentHealth;
        }

        
    }

    void Heal(float healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (sliderUI != null)
        {
            sliderUI.value = currentHealth;
        }
    }


}
