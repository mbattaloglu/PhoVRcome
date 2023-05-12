using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AcrophobiaUIManager : MonoBehaviour
{
    public static AcrophobiaUIManager Instance;
    public TMP_Text tasksText;
    public GameObject tasksWarningText;

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

    public void UpdateTasksText(int index, List<string> tasks)
    {
        tasksText.text = tasks[index];
    }

    //coroutine
    public void ShowWarning()
    {
        StartCoroutine(nameof(warning));
    }
    IEnumerator warning()
    {
        tasksWarningText.SetActive(true);
        yield return new WaitForSeconds(5);
        tasksWarningText.SetActive(false);

    }
}
