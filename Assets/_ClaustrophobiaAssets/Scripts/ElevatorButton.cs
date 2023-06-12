using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ElevatorButton : MonoBehaviour
{
    private Animator animator;
    private Transform player;
    public Elevator thisElevator;
    public Elevator oppositeElevator;

    private void Start()
    {
        animator = GetComponentInParent<Animator>();
        gameObject.AddComponent<XRSimpleInteractable>();
        player = GameObject.FindWithTag("Player").transform;
        GetComponent<XRSimpleInteractable>().activated.AddListener(HandleDoor);
    }

    private void HandleDoor(ActivateEventArgs arg0)
    {
        switch (thisElevator.isDoorOpen)
        {
            case true:
                StartCoroutine(Close());
                break;
            case false:
                StartCoroutine(Open());
                break;
        }
        thisElevator.isDoorOpen = !thisElevator.isDoorOpen;
    }

    private IEnumerator Open()
    {
        animator.Play("Open Door");
        yield return new WaitForSeconds(0.5f);
    }

    private IEnumerator Close()
    {
        animator.Play("Close Door");
        yield return new WaitForSeconds(0.5f);

        if (thisElevator.isPlayerInside)
        {
            yield return new WaitForSeconds(2f);
            TeleportPlayer.GetInstance().Teleport(oppositeElevator.transform.GetChild(9).transform);
        }
    }
}
