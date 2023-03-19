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
                titleText.text = "Oturma odas�na geri d�n.";
                break;
            case NyctophobiaTaskList.ElectricityCut:
                informationPanel.SetActive(false);
                titleText.text = "";
                informationText.text = "";
                break;
            case NyctophobiaTaskList.SearchForKeys:
                informationPanel.SetActive(true);
                titleText.text = "Anahtarlar� bul.";
                informationText.text = "Bodrum kata inen anahtarlar� bul. Koltu�un yan�ndaki �ekmecelerden birinde olmal�.";
                break;
            case NyctophobiaTaskList.SearchForPhone:
                informationPanel.SetActive(true);
                titleText.text = "Telefonu Bul";
                informationText.text = "Masan�n �st�nden telefonu bul ve al. Fla�� otomatik olarak a��lacakt�r.";
                break;
            case NyctophobiaTaskList.PhoneDropped:
                titleText.text = "Telefonu al";
                informationText.text = "Telefonu d���rd�n. Tekrar al ve fla�� a�.";
                break;
            case NyctophobiaTaskList.PhoneFound:
                titleText.text = "Bodrum kata in";
                informationText.text = "Bodrum kata in ve mumu al. Acele et, telefonunun �arj� bitmek �zere!";
                break;
            case NyctophobiaTaskList.CandleFound:
                titleText.text = "Mumlar� b�rak";
                informationText.text = "Mumlar� salondaki orta sehpan�n �st�ne";
                break;
            case NyctophobiaTaskList.CandlePutOnTable:
                titleText.text = "�akma�� al";
                informationText.text = "Mutfaktan �akma�� al.";
                break;
            case NyctophobiaTaskList.LighterFound:
                titleText.text = "Salona d�n";
                informationText.text = "�akmakla mumu yak.";
                break;
            case NyctophobiaTaskList.PhoneBatteryDead:
                titleText.text = "Telefonunun �arj� Bitti";
                informationText.text = "Telefonunu cebine koy.";
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