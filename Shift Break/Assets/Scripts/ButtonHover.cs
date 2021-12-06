using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public AudioSource hoverSound;


    private bool mouse_over = false;
    void Update()
    {
        if (mouse_over)
        {
            
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hoverSound.Play();
        mouse_over = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouse_over = false;
    }




}
