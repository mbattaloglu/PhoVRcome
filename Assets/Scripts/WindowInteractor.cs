using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowInteractor : MonoBehaviour
{
    public Animator animator;
    public Transform player;
    private bool isOpen;

    private void Start()
    {
        isOpen = false;
    }

    public void Interact()
    {
        if (player)
        {
            float dist = Vector3.Distance(player.position, transform.position);
            if (dist < 15)
            {
                Debug.Log("Distance is " + dist);
                Debug.Log("Player position: " + player.position);
                Debug.Log("Door position: " + transform.position);
                if (!isOpen)
                {
                    StartCoroutine(Open());
                }
                else
                {
                    StartCoroutine(Close());
                }
            }
        }
    }

    IEnumerator Open()
    {
        animator.Play("Openingwindow");
        isOpen = true;
        yield return new WaitForSeconds(.5f);
    }

    IEnumerator Close()
    {
        animator.Play("Closingwindow");
        isOpen = false;
        yield return new WaitForSeconds(.5f);
    }
}
