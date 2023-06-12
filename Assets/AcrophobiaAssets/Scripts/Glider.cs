using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using PathCreation.Examples;
using UnityEngine.XR.Interaction.Toolkit;

public class Glider : MonoBehaviour
{

    public static Glider Instance;
    GameObject player;
    GameObject simulator;


    [HideInInspector] public PathFollower follower;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        follower = GetComponent<PathFollower>();
        follower.enabled = false;
        player = GameObject.FindGameObjectWithTag("Player");
        simulator = GameObject.FindGameObjectWithTag("simulator");
    }

    private void Start()
    {
        GetComponent<XRSimpleInteractable>().selectEntered.AddListener(Interact);

    }

    public void EnableGliderFollower()
    {
        follower.enabled = true;

    }

    private void Interact(SelectEnterEventArgs arg0)
    {
        player.transform.SetParent(this.transform);

        player.GetComponent<ContinuousMoveProviderBase>().useGravity = false;
        player.GetComponent<ContinuousMoveProviderBase>().moveSpeed = 0;
        player.GetComponent<ContinuousMoveProviderBase>().enableStrafe = false;

        simulator.SetActive(false);

        player.transform.position = this.transform.position;

        EnableGliderFollower();


        Debug.Log("interacted");

    }


}

