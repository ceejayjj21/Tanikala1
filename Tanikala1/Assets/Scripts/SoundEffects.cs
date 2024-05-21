using UnityEngine;
using UnityEngine.UI;

public class ButtonClickSoundManager : MonoBehaviour
{
    // Reference to the AudioSource component that will play the sound
    public AudioSource clickSound;

    private void Start()
    {
        // Find all Button components in the children of this GameObject
        Button[] buttons = GetComponentsInChildren<Button>();

        // Loop through each button and add the click sound listener
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => PlayClickSound());
        }
    }

    private void PlayClickSound()
    {
        if (clickSound != null && clickSound.clip != null)
        {
            clickSound.Play();
        }
        else
        {
            Debug.LogWarning("Click sound or clip is not assigned.");
        }
    }
}




