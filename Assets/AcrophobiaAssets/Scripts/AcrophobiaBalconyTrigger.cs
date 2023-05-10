using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AcrophobiaBalconyTrigger : MonoBehaviour
{
    public Transform balconyPoint;
    public Transform housePoint;
    bool isPlayerInHouse = true;
    GameObject player;
    public int balconyId = 1;
    public bool goToBalcony = true;

    private void Start()
    {
        GetComponent<XRSimpleInteractable>().selectEntered.AddListener(Trigger);
        player = GameObject.FindGameObjectWithTag("Player");

    }

    void Trigger(SelectEnterEventArgs arg0)
    {
        
        if (isPlayerInHouse)
        {
            Debug.Log("Beamed to balcony");
            player.transform.position = balconyPoint.position;
            player.transform.rotation = balconyPoint.rotation;
            
            isPlayerInHouse = false;
        }
        else
        {
            Debug.Log("Beamed to house");

            player.transform.position = housePoint.position;
            player.transform.rotation = housePoint.rotation;
            isPlayerInHouse = true;
        }
    }
}
