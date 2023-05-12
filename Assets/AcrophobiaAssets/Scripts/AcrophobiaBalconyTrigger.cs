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
    AcrophobiaTaskManager taskManager;
    bool canGoToBalcony = false;
    TeleportationAnchor teleportationAnchor;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        taskManager = AcrophobiaTaskManager.Instance;
        teleportationAnchor = GetComponent<TeleportationAnchor>();
        teleportationAnchor.selectEntered.AddListener(Trigger);
        teleportationAnchor.teleportationProvider = player.GetComponent<TeleportationProvider>();

    }

    void Trigger(SelectEnterEventArgs arg0)
    {
        canGoToBalcony = false;

        if (isPlayerInHouse)
        {

            switch (balconyId)
            {


                case 2:
                    if (taskManager.GetTaskState(0))
                    {
                        canGoToBalcony = true;

                        if (!taskManager.GetTaskState(1))
                        {
                            taskManager.SetTaskState(1);

                        }
                    }
                    else
                    {
                        taskManager.TaskWarning();
                        teleportationAnchor.teleportAnchorTransform = player.transform;
                    }
                    break;
                case 3:
                    if (taskManager.GetTaskState(1))
                    {
                        canGoToBalcony = true;
                        if (!taskManager.GetTaskState(2))
                        {
                            taskManager.SetTaskState(2);

                        }

                    }
                    else
                    {
                        taskManager.TaskWarning();
                        teleportationAnchor.teleportAnchorTransform = player.transform;
                    }
                    break;
                case 4:
                    if (taskManager.GetTaskState(2))
                    {
                        canGoToBalcony = true;
                        if (!taskManager.GetTaskState(3))
                        {
                            taskManager.SetTaskState(3);

                        }

                    }
                    else
                    {
                        taskManager.TaskWarning();
                        teleportationAnchor.teleportAnchorTransform = player.transform;
                    }
                    break;

            }

            if (canGoToBalcony)
            {
                teleportationAnchor.teleportAnchorTransform = balconyPoint;

                isPlayerInHouse = false;

                canGoToBalcony = false;
            }
            else
            {
                teleportationAnchor.teleportAnchorTransform = player.transform;
                isPlayerInHouse = true;
                
            }


        }
        else
        {
            teleportationAnchor.teleportAnchorTransform = housePoint;

            isPlayerInHouse = true;
        }
    }


}
