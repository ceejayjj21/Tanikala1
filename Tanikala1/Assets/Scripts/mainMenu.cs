using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // References to the Canvases you want to toggle
    public Canvas mainMenuCanvas, settingsCanvas;
    // References to the Buttons that will trigger the Canvas visibility toggle
    public Button backButton, settingsButton;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void Start()
    {
        // Ensure the buttons have their listeners attached
        if (settingsButton != null)
        {
            settingsButton.onClick.AddListener(ShowSettingsCanvas);
        }

        if (backButton != null)
        {
            backButton.onClick.AddListener(ShowMainMenuCanvas);
        }

        // Initialize canvases' states
        mainMenuCanvas.enabled = true;
        settingsCanvas.enabled = false;
    }

    public void ShowMainMenuCanvas()
    {
        DisableSettingsCanvas();
        mainMenuCanvas.enabled = true;
    }

    public void ShowSettingsCanvas()
    {
        DisableMainMenuCanvas();
        settingsCanvas.enabled = true;
    }

    void DisableMainMenuCanvas()
    {
        mainMenuCanvas.enabled = false;
    }

    void DisableSettingsCanvas()
    {
        settingsCanvas.enabled = false;
    }
}

