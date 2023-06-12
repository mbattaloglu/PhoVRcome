using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AcrophobiaEnterHouseTrigger : MonoBehaviour
{
    public Transform house;
    public Transform outside;
    public bool isPlayerInside = false;
    AcrophobiaTaskManager taskManager;
    XRSimpleInteractable simpleInteractable;

    private void Start()
    {
        taskManager = AcrophobiaTaskManager.Instance;
        simpleInteractable = GetComponent<XRSimpleInteractable>();
        simpleInteractable.activated.AddListener(Trigger);
    }

    public GameObject player;
    public Camera playerHead;

    public void Teleport(Transform point)
    {
        var rotationAngleY = point.rotation.eulerAngles.y - playerHead.transform.rotation.eulerAngles.y;

        player.transform.Rotate(0, rotationAngleY, 0);

        var distanceDiff = point.position - playerHead.transform.position;

        player.transform.position += distanceDiff;
    }

    void Trigger(ActivateEventArgs arg0)
    {
        if (isPlayerInside)
        {
            isPlayerInside = false;
            Teleport(outside);

        }
        else
        {
            if (!taskManager.GetTaskState(0))
            {
                taskManager.SetTaskState(0);
                Teleport(house);

            }

            isPlayerInside = true;
        }
    }
}
