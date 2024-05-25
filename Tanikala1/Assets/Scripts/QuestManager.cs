using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    // Start is called before the first frame update

    public List<Quest> quests = new List<Quest>();

    public void AddQuest(string title, string description)
    {
        Quest newQuest = new Quest(title, description);
        quests.Add(newQuest);
        Debug.Log("Quest Added: " + title);
    }

    public void UpdateQuestMovementInput(string key) // Character Movement
    {
        foreach (Quest quest in quests)
        {
            if (!quest.isCompleted)
            {
                quest.UpdateMovementInput(key);
            }
        }
    }

    public void CompleteQuest(string title)
    {
        Quest quest = quests.Find(q => q.title == title);
        if (quest != null)
        {
            quest.CompleteQuest();
        }
        else
        {
            Debug.LogWarning("Quest not found: " + title);
        }
    }

    public void ShowQuests()
    {
        foreach (Quest quest in quests)
        {
            Debug.Log(quest.title + ": " + (quest.isCompleted ? "Completed" : "Not Completed"));
        }
    }
    void Start()
    {
        AddQuest("Character Movement", "Press WSAD to make the character move.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
