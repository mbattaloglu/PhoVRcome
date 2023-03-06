using System;
using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Phone : MonoBehaviour
{
    private GameObject flashLight;
    private bool isBatteryDead;

    private void Start()
    {
        flashLight = transform.GetChild(0).gameObject;
        GetComponent<XRGrabInteractable>().selectEntered.AddListener(OpenFlash);
        GetComponent<XRGrabInteractable>().selectExited.AddListener(CloseFlash);
        GetComponent<XRGrabInteractable>().activated.AddListener(PutPocket);
    }

    private void PutPocket(ActivateEventArgs arg0)
    {
        if (NyctophobiaGameManager.GetInstance().isElectricCut && isBatteryDead)
        {
            NyctophobiaGameManager.GetInstance().SetTaskType(NyctophobiaTaskList.TorchFound);
            Destroy(gameObject);
        }
    }

    private void CloseFlash(SelectExitEventArgs arg0)
    {
        if (NyctophobiaGameManager.GetInstance().isElectricCut && !isBatteryDead)
        {
            NyctophobiaGameManager.GetInstance().SetTaskType(NyctophobiaTaskList.PhoneDropped);
        }
        flashLight.SetActive(false);
    }

    private void OpenFlash(SelectEnterEventArgs arg0)
    {
        if (NyctophobiaGameManager.GetInstance().isElectricCut && !isBatteryDead)
        {
            NyctophobiaGameManager.GetInstance().SetTaskType(NyctophobiaTaskList.PhoneFound);
            flashLight.SetActive(true);
        }
    }

    public IEnumerator BatteryDead()
    {
        yield return new WaitForSeconds(8f);
        isBatteryDead = true;
        flashLight.SetActive(false);
        NyctophobiaGameManager.GetInstance().SetTaskType(NyctophobiaTaskList.PhoneBatteryDead);
    }
}
