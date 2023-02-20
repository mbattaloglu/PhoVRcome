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
                titleText.text = "Oturma odasýna geri dön.";
                break;
            case NyctophobiaTaskList.ElectricityCut:
                informationPanel.SetActive(false);
                titleText.text = "";
                informationText.text = "";
                break;
            case NyctophobiaTaskList.SearchForPhone:
                informationPanel.SetActive(true);
                titleText.text = "Telefonu Bul";
                informationText.text = "Masanýn üstünden telefonu bul ve al. Flaþý otomatik olarak açýlacaktýr.";
                break;
            case NyctophobiaTaskList.PhoneFound:
                titleText.text = "Anahtarlarý bul";
                informationText.text = "Bodrum kata inen anahtarlarý bul. Genç odasý kapýsýnýn yanýndaki raflardan birinde olmalý.";
                break;
            case NyctophobiaTaskList.PhoneDropped:
                titleText.text = "Telefonu al";
                informationText.text = "Telefonu düþürdün. Tekrar al ve flaþý aç.";
                break;
            case NyctophobiaTaskList.KeyFound:
                titleText.text = "Bodrum kata in";
                informationText.text = "Bodrum kata in ve feneri al. Acele et, telefonunun þarjý bitmek üzere!";
                break;
            case NyctophobiaTaskList.TorchFound:
                titleText.text = "Salona geri dön";
                informationText.text = "Salona geri dön ve feneri kullanarak odalarý aydýnlat.";
                break;
            default:
                break;
        } 
    }
}