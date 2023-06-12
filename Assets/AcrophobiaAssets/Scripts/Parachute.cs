using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using PathCreation.Examples;
using UnityEngine.XR.Interaction.Toolkit;

public class Parachute : MonoBehaviour
{
    public static Parachute Instance;
    GameObject player;

    [HideInInspector] public PathFollower follower;
    TeleportationAnchor teleportationAnchor;
    AcrophobiaTaskManager taskManager;



    private void Awake()
    {
        if (Instance == null)
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
    }

    private void Start()
    {
        teleportationAnchor = GetComponent<TeleportationAnchor>();
        teleportationAnchor.selectEntered.AddListener(Trigger);
        taskManager = AcrophobiaTaskManager.Instance;

    }

    public void EnableFollower()
    {
        follower.enabled = true;

    }
    public void DisableFollower()
    {
        follower.enabled = false;

    }

    private void Interact()
    {
        player.transform.SetParent(this.transform);

        player.GetComponent<ContinuousMoveProviderBase>().useGravity = false;
        player.GetComponent<ContinuousMoveProviderBase>().moveSpeed = 0;
        player.GetComponent<ContinuousMoveProviderBase>().enableStrafe = false;

        player.transform.position = this.transform.position;

        EnableFollower();


        Debug.Log("interacted");

    }
    void Trigger(SelectEnterEventArgs arg0)
    {
        if (taskManager.GetTaskState(4))
        {

            teleportationAnchor.teleportAnchorTransform = this.transform;
            Interact();
            Invoke(nameof(Ended), 10);

        }


    }

    void Ended()
    {
        Debug.Log("Completed");
    }

}
