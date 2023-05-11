using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcrophobiaTaskManager : MonoBehaviour
{
    public static AcrophobiaTaskManager Instance;

    List<string> acrophobiaTasks;
    public List<bool> acrophobiaTasksCompleted;

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
        foreach (string task in acrophobiaTasks)
        {
            acrophobiaTasksCompleted.Add(false);
        }
    }

}
