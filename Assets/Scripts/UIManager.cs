using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject SelectionMenu;
    public void GoSelectionMenuOnClick()
    {
        MainMenu.SetActive(false);
        SelectionMenu.SetActive(true);
    }

    public void GoPhobia1SceneOnClick()
    {
        SceneManager.LoadScene("Phobia1Scene");
    }

    public void GoPhobia2SceneOnClick()
    {
        SceneManager.LoadScene("Phobia2Scene");
    }

    public void GoPhobia3SceneOnClick()
    {
        SceneManager.LoadScene("Phobia3Scene");
    }

    public void QuitGameOnClick()
    {
        Application.Quit();
    }
}
