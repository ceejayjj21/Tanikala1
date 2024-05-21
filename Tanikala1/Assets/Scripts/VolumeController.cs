using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    // References to the AudioSource components whose volumes we want to control
    public AudioSource backgroundMusic;
    public AudioSource soundEffects;

    // References to the UI Slider components
    public Slider backgroundMusicSlider;
    public Slider soundEffectsSlider;

    // PlayerPrefs keys
    private const string BackgroundMusicPref = "BackgroundMusicVolume";
    private const string SoundEffectsPref = "SoundEffectsVolume";

    private void Start()
    {
        if (backgroundMusic == null)
        {
            Debug.LogWarning("Background music AudioSource is not assigned.");
        }

        if (soundEffects == null)
        {
            Debug.LogWarning("Sound effects AudioSource is not assigned.");
        }

        if (backgroundMusicSlider == null)
        {
            Debug.LogWarning("Background music volume slider is not assigned.");
        }
        else
        {
            // Load saved background music volume
            float savedBackgroundMusicVolume = PlayerPrefs.GetFloat(BackgroundMusicPref, backgroundMusic.volume);
            backgroundMusic.volume = savedBackgroundMusicVolume;
            backgroundMusicSlider.value = savedBackgroundMusicVolume;
            // Add listener to handle background music volume change events
            backgroundMusicSlider.onValueChanged.AddListener(OnBackgroundMusicVolumeChanged);
        }

        if (soundEffectsSlider == null)
        {
            Debug.LogWarning("Sound effects volume slider is not assigned.");
        }
        else
        {
            // Load saved sound effects volume
            float savedSoundEffectsVolume = PlayerPrefs.GetFloat(SoundEffectsPref, soundEffects.volume);
            soundEffects.volume = savedSoundEffectsVolume;
            soundEffectsSlider.value = savedSoundEffectsVolume;
            // Add listener to handle sound effects volume change events
            soundEffectsSlider.onValueChanged.AddListener(OnSoundEffectsVolumeChanged);
        }
    }

    // Method to be called when the background music slider value changes
    private void OnBackgroundMusicVolumeChanged(float value)
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.volume = value;
            PlayerPrefs.SetFloat(BackgroundMusicPref, value);
            PlayerPrefs.Save();
        }
    }

    // Method to be called when the sound effects slider value changes
    private void OnSoundEffectsVolumeChanged(float value)
    {
        if (soundEffects != null)
        {
            soundEffects.volume = value;
            PlayerPrefs.SetFloat(SoundEffectsPref, value);
            PlayerPrefs.Save();
        }
    }
}


