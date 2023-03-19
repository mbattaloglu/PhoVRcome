using UnityEngine;
using UnityEngine.SceneManagement;

public class NyctophobiaUIManager : MonoBehaviour
{
    #region Singleton

    private static NyctophobiaUIManager instance;

    private NyctophobiaUIManager()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public static NyctophobiaUIManager GetInstance()
    {
        return instance;
    }

    #endregion

    [SerializeField] GameObject gameOverPanel;

    private void Start()
    {
        gameOverPanel.SetActive(false);
    }

    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }
    
    public void GoMainMenuOnClick()
    {
        SceneManager.LoadScene("MenuScene");
    }
}