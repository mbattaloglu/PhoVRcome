using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcrophobiaTaskManager : MonoBehaviour
{
    public static AcrophobiaTaskManager Instance;

    List<string> acrophobiaTasks;
    List<string> acrophobiaTaskUI;

    public List<bool> acrophobiaTasksCompleted;
    AcrophobiaUIManager uIManager;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        acrophobiaTasks = new List<string>() {"enterHouse", "firstBalcony", "secondBalcony", "thirdBalcony",
        "glider","fireEscape", "parachute"};
        acrophobiaTaskUI = new List<string>()
        { "Task1: Enter House", "Task2: Go to one of the second floor balconies and look around.",
            "Task3: Go to one of the third floor balconies and look around.",
            "Task4: Go to one of the fourth floor balconies and look around.",
        "Task5: Go to the backyard and glide with the glider plane.",
        "Task6: Escape from the building using fire escapes.",
        "Task7: Wear a parachute and paraglide."};
        foreach (string task in acrophobiaTasks)
        {
            acrophobiaTasksCompleted.Add(false);
        }

        uIManager = AcrophobiaUIManager.Instance;
    }



    public void SetTaskState(int index)
    {
        acrophobiaTasksCompleted[index] = true;
        uIManager.UpdateTasksText(index + 1, acrophobiaTaskUI);
    }
    
    public bool GetTaskState(int index)
    {
        return acrophobiaTasksCompleted[index];
    }

    public void TaskWarning()
    {
        uIManager.ShowWarning();
    }

}
