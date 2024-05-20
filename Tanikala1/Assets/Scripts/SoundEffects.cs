using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SoundEffects : MonoBehaviour, IPointerEnterHandler
{
    // Reference to the AudioSource component
    public AudioSource hoverSound;

    // Method called when the pointer enters the UI element
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hoverSound != null)
        {
            hoverSound.Play();
        }
    }
}
