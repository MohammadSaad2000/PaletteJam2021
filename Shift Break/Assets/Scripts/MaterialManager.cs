using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialManager : MonoBehaviour
{
    public Material effectMaterial;

    SpriteRenderer spriteRenderer;

    private Material startMaterial;
    private IEnumerator hitEffectRoutine;
    private bool hitEffectActive = false;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        startMaterial = spriteRenderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        if (spriteRenderer != null)
            spriteRenderer.material = startMaterial;
    }


    public void InitiateHitEffect(float duration, Color color)
    {
        if (hitEffectActive)
            return;
        hitEffectRoutine = HitEffect(duration, color);
        StartCoroutine(hitEffectRoutine);
    }


    IEnumerator HitEffect(float duration, Color color)
    {
        hitEffectActive = true;
        spriteRenderer.material = effectMaterial;
        effectMaterial.color = color;
        yield return new WaitForSeconds(duration);
        spriteRenderer.material = startMaterial;
        hitEffectActive = false;

    }
}
