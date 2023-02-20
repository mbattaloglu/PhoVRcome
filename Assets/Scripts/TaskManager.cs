using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Linq;

public class TaskManager : MonoBehaviour
{
    #region Singleton
    private static TaskManager instance;

    private TaskManager()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public static TaskManager GetInstance()
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

        switch (NyctophobiaGameManager.GetInstance().taskType)
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
                titleText.text = "Oturma odas�na geri d�n.";
                break;
            case NyctophobiaTaskList.ElectricityCut:
                informationPanel.SetActive(false);
                titleText.text = "";
                informationText.text = "";
                break;
            case NyctophobiaTaskList.SearchForPhone:
                informationPanel.SetActive(true);
                titleText.text = "Telefonu Bul";
                informationText.text = "Masan�n �st�nden telefonu bul ve al. Fla�� otomatik olarak a��lacakt�r.";
                break;
            case NyctophobiaTaskList.PhoneFound:
                titleText.text = "Anahtarlar� bul";
                informationText.text = "Bodrum kata inen anahtarlar� bul. Gen� odas� kap�s�n�n yan�ndaki raflardan birinde olmal�.";
                break;
            case NyctophobiaTaskList.PhoneDropped:
                titleText.text = "Telefonu al";
                informationText.text = "Telefonu d���rd�n. Tekrar al ve fla�� a�.";
                break;
            case NyctophobiaTaskList.KeyFound:
                titleText.text = "Bodrum kata in";
                informationText.text = "Bodrum kata in ve feneri al. Acele et, telefonunun �arj� bitmek �zere!";
                break;
            case NyctophobiaTaskList.TorchFound:
                titleText.text = "Salona geri d�n";
                informationText.text = "Salona geri d�n ve feneri kullanarak odalar� ayd�nlat.";
                break;
            default:
                break;
        } 
    }
}