using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Torch : MonoBehaviour
{
    private GameObject flashLight;
    
    private void Start()
    {
        flashLight = transform.GetChild(0).gameObject;
        GetComponent<XRGrabInteractable>().selectEntered.AddListener(OpenFlash);
        GetComponent<XRGrabInteractable>().selectExited.AddListener(CloseFlash);
    }

    private void CloseFlash(SelectExitEventArgs arg0)
    {
        if (NyctophobiaGameManager.GetInstance().isElectricCut)
        {
            //NyctophobiaGameManager.GetInstance().SetTaskType(NyctophobiaTaskList.TorchDropped);
        }
        flashLight.SetActive(false);
    }

    private void OpenFlash(SelectEnterEventArgs arg0)
    {
        if (NyctophobiaGameManager.GetInstance().isElectricCut)
        {
            //NyctophobiaGameManager.GetInstance().SetTaskType(NyctophobiaTaskList.TorchFound);
            flashLight.SetActive(true);
            //StartCoroutine(FindObjectOfType<Phone>().BatteryDead());
        } 
    }
}
