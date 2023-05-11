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
    TeleportationAnchor teleportationAnchor;

    private void Start()
    {
        taskManager = AcrophobiaTaskManager.Instance;
        teleportationAnchor = GetComponent<TeleportationAnchor>();
        teleportationAnchor.selectEntered.AddListener(Trigger);
    }

    void Trigger(SelectEnterEventArgs arg0)
    {
        if (isPlayerInside)
        {
            teleportationAnchor.teleportAnchorTransform = outside;
            isPlayerInside = false;
        }
        else
        {
            taskManager.acrophobiaTasksCompleted[0] = true;
            teleportationAnchor.teleportAnchorTransform = house;

            isPlayerInside = true;
        }
    }
}
