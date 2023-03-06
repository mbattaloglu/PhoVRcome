using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BasementDoor : MonoBehaviour
{
    private Animator animator;
    private bool isOpen;
    private Transform player;
    private void Start()
    {
        isOpen = false;
        gameObject.AddComponent<XRSimpleInteractable>();
        animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player").transform;
        GetComponent<XRSimpleInteractable>().activated.AddListener(Interact);
    }

    private void Interact(ActivateEventArgs arg0)
    {
        float dist = Vector3.Distance(player.position, transform.position);
        if (dist < 15)
        {
            switch (isOpen)
            {
                case true:
                    StartCoroutine(Close());
                    break;
                case false:
                    if (NyctophobiaGameManager.GetInstance().isKeyFound)
                    {
                        StartCoroutine(Open());
                    }
                    else
                    {
                        Debug.Log("You need to find the key first");
                    }
                    break;
            }
        }
    }
    private IEnumerator Open()
    {
        animator.Play("Opening");
        isOpen = true;
        yield return new WaitForSeconds(.5f);
    }

    private IEnumerator Close()
    {
        animator.Play("Closing");
        isOpen = false;
        yield return new WaitForSeconds(.5f);
    }
}