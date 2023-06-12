using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaustrophobiaTask : MonoBehaviour
{
    public ClaustrophobiaTaskList task;

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            ClaustrophobiaTaskManager.GetInstance().SetTask(task);
        }
    }
}
