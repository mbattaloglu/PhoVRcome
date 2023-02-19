using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Linq;

public class InformationPanel : MonoBehaviour
{
    #region Singleton
    private static InformationPanel instance;

    private InformationPanel()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public static InformationPanel GetInstance()
    {
        return instance;
    }
    #endregion

    public GameObject informationText;
    public GameObject informationPanel;
    public GameObject textPrefab;

    public string title = "Visit all rooms";

    public List<Task> tasks = new List<Task>();

    private void Awake()
    {
        tasks = GameObject.FindObjectsOfType<Task>().ToList();
        Initialize();
    }

    public void Initialize()
    {
        if (tasks.Count == 0)
        {
            informationText.GetComponent<TextMeshProUGUI>().text = "You Completed all tasks. Go back to the livingroom.";
            return;
        }

        informationText.GetComponent<TextMeshProUGUI>().text = this.title;
        informationText.GetComponent<TextMeshProUGUI>().fontSize = 30;
        for (int i = 0; i < tasks.Count; i++)
        {
            //informationText = Instantiate(textPrefab, informationPanel.transform);
            informationText.GetComponent<TextMeshProUGUI>().fontSize = 20;
            informationText.GetComponent<TextMeshProUGUI>().text += "\n" + tasks[i].taskDescription;
        }
    }
}