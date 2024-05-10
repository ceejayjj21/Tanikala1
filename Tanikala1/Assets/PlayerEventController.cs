using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEventController : MonoBehaviour
{
   public void QuitGame()
    {
        Debug.Log("Game Quitted");
        Application.Quit();
    }
}
