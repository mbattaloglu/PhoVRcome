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
    XRSimpleInteractable simpleInteractable;
    Camera playerHead;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        taskManager = AcrophobiaTaskManager.Instance;
        simpleInteractable = GetComponent<XRSimpleInteractable>();
        simpleInteractable.activated.AddListener(Trigger);
        playerHead = Camera.main;
    }

    public void Teleport(Transform point)
    {
        var rotationAngleY = point.rotation.eulerAngles.y - playerHead.transform.rotation.eulerAngles.y;

        player.transform.Rotate(0, rotationAngleY, 0);

        var distanceDiff = point.position - playerHead.transform.position;

        player.transform.position += distanceDiff;
    }

    void Trigger(ActivateEventArgs arg0)
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
                    }
                    break;

            }

            if (canGoToBalcony)
            {
                Teleport(balconyPoint);

                isPlayerInHouse = false;

                canGoToBalcony = false;
            }
            else
            {
                isPlayerInHouse = true;
                
            }


        }
        else
        {
            Teleport(housePoint);


            isPlayerInHouse = true;
        }
    }


}
