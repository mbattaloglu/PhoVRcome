using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Phone : MonoBehaviour
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
        flashLight.SetActive(false);
    }

    private void OpenFlash(SelectEnterEventArgs arg0)
    {
        flashLight.SetActive(true);
    }
}