using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Linq;

public class NyctophobiaTaskManager : MonoBehaviour
{
    #region Singleton
    private static NyctophobiaTaskManager instance;

    private NyctophobiaTaskManager()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public static NyctophobiaTaskManager GetInstance()
    {
        return instance;
    }
    #endregion

    public TextMeshProUGUI informationText;
    public TextMeshProUGUI titleText;
    public GameObject informationPanel;

    public string title;
    
    private List<Task> tasks = new List<Task>();

    private void Awake()
    {
        tasks = FindObjectsOfType<Task>().ToList();
        Initialize();
    }

    public void Initialize()
    {
        informationText.text = "";

        switch (NyctophobiaGameManager.GetInstance().GetTaskType())
        {
            case NyctophobiaTaskList.GoAllCheckpoints:
                titleText.text = this.title;
                titleText.fontSize = 30;
                for (int i = 0; i < tasks.Count; i++)
                {
                    switch (tasks[i].isCompleted)
                    {
                        case true:
                            informationText.text += "<s>" + tasks[i].taskDescription + "</s>" + "\n";
                            break;
                        case false:
                            informationText.text += tasks[i].taskDescription + "\n";
                            break;
                    }
                    informationText.fontSize = 24;
                }
                break;
            case NyctophobiaTaskList.CheckpointsReached:
                informationText.text = "";
                titleText.text = "Go back to the living room.";
                break;
            case NyctophobiaTaskList.ElectricityCut:
                informationPanel.SetActive(false);
                titleText.text = "";
                informationText.text = "";
                break;
            case NyctophobiaTaskList.SearchForKeys:
                informationPanel.SetActive(true);
                titleText.text = "Find the Keys";
                informationText.text = "Find the keys of the basement. It is in the drawer under the emergency light.";
                break;
            case NyctophobiaTaskList.SearchForPhone:
                informationPanel.SetActive(true);
                titleText.text = "Get the Phone";
                informationText.text = "Get the phone. The flashlight will automatically open.";
                break;
            case NyctophobiaTaskList.PhoneDropped:
                titleText.text = "Get the phone";
                informationText.text = "You dropped the phone. Get back it!";
                break;
            case NyctophobiaTaskList.PhoneFound:
                titleText.text = "Go to the basement";
                informationText.text = "Go basement and take candles. Hurry up, your battery is about to die!";
                break;
            case NyctophobiaTaskList.CandleFound:
                titleText.text = "Drop the Candles";
                informationText.text = "Drop to candles to the coffee table";
                break;
            case NyctophobiaTaskList.CandlePutOnTable:
                titleText.text = "Get Lighter";
                informationText.text = "Go kitchen and take lighter on the dinner table.";
                break;
            case NyctophobiaTaskList.LighterFound:
                titleText.text = "Go Back to the Living Room ";
                informationText.text = "Light the Candles.";
                break;
            case NyctophobiaTaskList.PhoneBatteryDead:
                titleText.text = "Battery is dead.";
                informationText.text = "Put your phone to your pocket.";
                break;
            case NyctophobiaTaskList.CandleLighted:
                informationPanel.SetActive(false);
                titleText.text = "";
                informationText.text = "";
                StartCoroutine(NyctophobiaGameLoop.GetInstance().GiveElectricity());
                break;
            case NyctophobiaTaskList.GameOver:
                NyctophobiaGameLoop.GetInstance().GameOver();
                break;
            default:
                break;
        } 
    }
}