using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Candle : MonoBehaviour
{
    private bool isOn;
    private ParticleSystem flame;
    private Light selfLight;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Table"))
        {
            Destroy(GetComponent<XRGrabInteractable>());
            Destroy(GetComponent<Rigidbody>());
            GetComponent<Collider>().isTrigger = true;
            GetComponent<XRSocketInteractor>().enabled = true;
            GetComponent<XRSocketInteractor>().hoverEntered.AddListener(OnHover);
            NyctophobiaGameManager.GetInstance().SetTaskType(NyctophobiaTaskList.CandlePutOnTable);
        }
    }
    private void Start()
    {
        flame = transform.GetChild(0).GetChild(0).GetComponent<ParticleSystem>();
        selfLight = transform.GetChild(0).GetChild(0).GetChild(2).GetComponent<Light>();
        flame.Stop();
        GetComponent<XRGrabInteractable>().selectEntered.AddListener(GrabCandle);
    }

    private void GrabCandle(SelectEnterEventArgs arg0)
    {
        NyctophobiaGameManager.GetInstance().SetTaskType(NyctophobiaTaskList.CandleFound);
    }

    private void OnHover(HoverEnterEventArgs arg0)
    {
        if (isOn) return;
        string lighterName = arg0.interactableObject.ToString();
        if(lighterName.Contains("(U"))
        {
            int index = lighterName.IndexOf(" (Unity");
            lighterName = lighterName.Substring(0, index);
        }

        GameObject lighter = GameObject.Find(lighterName);
        
        if (lighter.GetComponent<Lighter>().isOn)
        {
            this.isOn = true;
            flame.Play();
            selfLight.enabled = true; 
        }
        
        NyctophobiaGameManager.GetInstance().SetTaskType(NyctophobiaTaskList.CandleLighted);
    }
}
