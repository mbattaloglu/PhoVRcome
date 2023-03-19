using System;
using UnityEngine;
using System.Collections;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections.Generic;

public class Lighter : MonoBehaviour
{
    public bool isOn;
    private ParticleSystem flame;
    private Light selfLight;
    private void Start()
    {
        flame = transform.GetChild(0).GetComponent<ParticleSystem>();
        selfLight = transform.GetChild(0).GetChild(2).GetComponent<Light>();
        flame.Stop();
        GetComponent<XRGrabInteractable>().selectEntered.AddListener(GrabLighter);
        GetComponent<XRGrabInteractable>().activated.AddListener(LightCandle);
    }

    private void GrabLighter(SelectEnterEventArgs arg0)
    {
        NyctophobiaGameManager.GetInstance().SetTaskType(NyctophobiaTaskList.LighterFound);
    }

    private void LightCandle(ActivateEventArgs arg0)
    {
        StartCoroutine(LightCandleAnim());
    }
    IEnumerator LightCandleAnim()
    {
        isOn = true;
        flame.Play();
        selfLight.enabled = true;
        yield return new WaitForSeconds(2f);
        flame.Stop();
        selfLight.enabled = false;
        isOn = false;
    }
}
