using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    // Start is called before the first frame update

    public string title;
    public string description;
    public bool isCompleted;

    private bool wPressed;
    private bool sPressed;
    private bool aPressed;
    private bool dPressed;


    public Quest(string title, string description)
    {
        this.title = title;
        this.description = description;
        this.isCompleted = false;

        this.wPressed = false;
        this.sPressed = false;
        this.aPressed = false;
        this.dPressed = false;

    }


    public void CheckForCompletion()
    {
        if (wPressed && sPressed && aPressed && dPressed)
        {
            CompleteQuest();
        }
    }
    public void UpdateMovementInput(string key)
    {
        switch (key)
        {
            case "W":
                wPressed = true;
                break;
            case "S":
                sPressed = true;
                break;
            case "A":
                aPressed = true;
                break;
            case "D":
                dPressed = true;
                break;
        }
        CheckForCompletion();
    }

    public void CompleteQuest()
    {
        isCompleted = true;
        Debug.Log("Quest Completed: " + title);
    }
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
