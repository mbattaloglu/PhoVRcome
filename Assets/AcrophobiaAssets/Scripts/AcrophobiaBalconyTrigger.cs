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
        if (isPlayerInHouse)
        {

            switch (balconyId)
            {


                case 2:
                    if (taskManager.acrophobiaTasksCompleted[0])
                    {
                        canGoToBalcony = true;
                        taskManager.acrophobiaTasksCompleted[1] = true;
                    }
                    else
                    {
                        //insert warning here
                    }
                    break;
                case 3:
                    if (taskManager.acrophobiaTasksCompleted[1])
                    {
                        canGoToBalcony = true;
                        taskManager.acrophobiaTasksCompleted[2] = true;

                    }
                    else
                    {
                        //insert warning here
                    }
                    break;
                case 4:
                    if (taskManager.acrophobiaTasksCompleted[2])
                    {
                        canGoToBalcony = true;
                        taskManager.acrophobiaTasksCompleted[3] = true;

                    }
                    else
                    {
                        //insert warning here
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
                canGoToBalcony = true;
            }


        }
        else
        {
            teleportationAnchor.teleportAnchorTransform = housePoint;

            isPlayerInHouse = true;
        }
    }


}
