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
        float dist = Vector3.Distance(player.position, transform.position);
        if (dist < 15)
        {
            switch (isOpen)
            {
                case true:
                    StartCoroutine(Close());
                    break;
                case false:
                    StartCoroutine(Open());
                    break;
                default:
                    break;
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
