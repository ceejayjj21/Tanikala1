using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    public GameObject panel; // Reference to the panel GameObject
    public Button openButton; // Reference to the button that opens the panel
    public Button closeButton; // Reference to the button that closes the panel

    private void Start()
    {
        if (panel == null || openButton == null || closeButton == null)
        {
            Debug.LogWarning("Some references are not assigned in the Inspector.");
            return;
        }

        // Ensure the panel is initially hidden
        panel.SetActive(false);

        // Add listeners to the buttons
        openButton.onClick.AddListener(ShowPanel);
        closeButton.onClick.AddListener(HidePanel);
    }

    // Method to show the panel
    private void ShowPanel()
    {
        Debug.Log("OpenButton clicked. Showing panel.");
        panel.SetActive(true);
    }

    // Method to hide the panel
    private void HidePanel()
    {
        Debug.Log("CloseButton clicked. Hiding panel.");
        panel.SetActive(false);
    }
}

