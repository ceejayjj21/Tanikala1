using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    public GameObject panel; // Reference to the panel GameObject
    public Button openButton; // Reference to the button that opens the panel
    public Button closeButton; // Reference to the button that closes the panel
    public Button mainMenuButton; // Reference to the button that goes to the main menu

    private void Start()
    {
        if (panel == null || openButton == null || closeButton == null || mainMenuButton == null)
        {
            Debug.LogWarning("Some references are not assigned in the Inspector.");
            return;
        }

        // Ensure the panel is initially hidden
        panel.SetActive(false);

        // Add listeners to the buttons
        openButton.onClick.AddListener(ShowPanel);
        closeButton.onClick.AddListener(HidePanel);
        mainMenuButton.onClick.AddListener(GoToMainMenu);
    }

    // Method to show the panel
    private void ShowPanel()
    {
        Debug.Log("OpenButton clicked. Showing panel and pausing game.");
        panel.SetActive(true);
        Time.timeScale = 0f; // Pause the game
    }

    // Method to hide the panel
    private void HidePanel()
    {
        Debug.Log("CloseButton clicked. Hiding panel and resuming game.");
        panel.SetActive(false);
        Time.timeScale = 1f; // Resume the game
    }

    // Method to go to the main menu
    private void GoToMainMenu()
    {
        Debug.Log("MainMenuButton clicked. Transitioning to Menu scene.");
        Time.timeScale = 1f; // Ensure the game is not paused when transitioning
        SceneManager.LoadScene("Menu");
    }
}



