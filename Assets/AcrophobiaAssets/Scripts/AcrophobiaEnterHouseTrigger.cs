using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AcrophobiaEnterHouseTrigger : MonoBehaviour
{
    public Transform teleportTo;
    GameObject player;

    private void Start()
    {
        GetComponent<XRSimpleInteractable>().selectEntered.AddListener(Trigger);
        player = GameObject.FindGameObjectWithTag("Player");

    }

    void Trigger(SelectEnterEventArgs arg0)
    {
        Debug.Log("Triggered");
        player.transform.position = teleportTo.position;
    }
}
