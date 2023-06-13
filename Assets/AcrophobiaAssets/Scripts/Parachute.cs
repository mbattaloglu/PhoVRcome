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
    AcrophobiaTaskManager taskManager;
    XRSimpleInteractable simpleInteractable;
    Camera playerHead;
    public GameObject completedPanel;

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

        taskManager = AcrophobiaTaskManager.Instance;
        simpleInteractable = GetComponent<XRSimpleInteractable>();
        simpleInteractable.activated.AddListener(Trigger);
        playerHead = Camera.main;
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
    void Trigger(ActivateEventArgs arg0)
    {

        if (taskManager.GetTaskState(4))
        {

            Interact();

            Teleport(this.transform);
            Invoke(nameof(Ended), 8);

        }
        else
        {
            taskManager.TaskWarning();

        }


    }

    public void Teleport(Transform point)
    {
        var rotationAngleY = point.rotation.eulerAngles.y - playerHead.transform.rotation.eulerAngles.y;

        player.transform.Rotate(0, rotationAngleY, 0);

        var distanceDiff = point.position - playerHead.transform.position;

        player.transform.position += distanceDiff;
    }

    void Ended()
    {
        taskManager.SetTaskState(5);

        Debug.Log("Completed");
        player.transform.SetParent(null);

        player.GetComponent<ContinuousMoveProviderBase>().useGravity = true;
        player.GetComponent<ContinuousMoveProviderBase>().moveSpeed = 1;
        player.GetComponent<ContinuousMoveProviderBase>().enableStrafe = true;

        DisableFollower();

    }
}
