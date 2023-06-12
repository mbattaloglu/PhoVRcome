using UnityEngine;
using TMPro;

public class ClaustrophobiaTaskManager : MonoBehaviour
{
    #region Singleton
    private static ClaustrophobiaTaskManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public static ClaustrophobiaTaskManager GetInstance()
    {
        return instance;
    }

    #endregion

    public TextMeshProUGUI taskText;
    public GameObject congratsPanel;
    public GameObject infoPanel;
    public ClaustrophobiaTaskList task;

    private void Start()
    {
        SetTask(ClaustrophobiaTaskList.FindCave);
        congratsPanel.SetActive(false);
        infoPanel.SetActive(true);
    }

    public void SetTask(ClaustrophobiaTaskList task)
    {
        this.task = task;

        switch (task)
        {
            case ClaustrophobiaTaskList.FindCave:
                taskText.text = "Find the Cave in the Forest.";
                break;
            case ClaustrophobiaTaskList.EnterCave:
                taskText.text = "Go and Enter the Cave.";
                break;
            case ClaustrophobiaTaskList.FindElevator:
                taskText.text = "Find the Elevator and Get In.";
                break;
            case ClaustrophobiaTaskList.UseElevator:
                taskText.text = "Use Elevator and Go to the Room.";
                break;
            case ClaustrophobiaTaskList.GoOut:
                taskText.text = "Open the Door and Go Out.";
                break;
            case ClaustrophobiaTaskList.Final:
                congratsPanel.SetActive(true);
                infoPanel.SetActive(false);
                break;
        }
    }
}
