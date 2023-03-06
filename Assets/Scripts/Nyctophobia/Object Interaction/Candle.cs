using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Candle : MonoBehaviour
{
    private bool isOn;
    private ParticleSystem flame;
    private Light selfLight;
    private void Start()
    {
        flame = transform.GetChild(0).GetChild(0).GetComponent<ParticleSystem>();
        selfLight = transform.GetChild(0).GetChild(0).GetChild(2).GetComponent<Light>();
        flame.Stop();
        gameObject.GetComponent<XRSocketInteractor>().hoverEntered.AddListener(OnHover);
    }

    private void OnHover(HoverEnterEventArgs arg0)
    {
        if (isOn) return;
        string lighterName = arg0.interactableObject.ToString();
        Debug.Log("Before Lighter Name : \"" + lighterName + "\"");
        if(lighterName.Contains("(U"))
        {
            int index = lighterName.IndexOf("(Unity");
            lighterName = lighterName.Substring(0, index);
            lighterName = lighterName.Replace(" ", "");
        }
        Debug.Log("After Lighter Name : \"" + lighterName + "\"");

        GameObject lighter = GameObject.Find(lighterName);
        
        if (lighter.GetComponent<Lighter>().isOn)
        {
            this.isOn = true;
            flame.Play();
            selfLight.enabled = true; 
        }
    }

    private void LightCandle(SelectEnterEventArgs arg0)
    {
        gameObject.GetComponent<XRSocketInteractor>().enabled = false;
    }
}
