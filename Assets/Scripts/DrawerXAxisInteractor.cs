using System.Collections;
using UnityEngine;

public class DrawerXAxisInteractor : MonoBehaviour
{
    public Animator animator;
    private bool isOpen;
    public Transform player;

    private void Start()
    {
        isOpen = false;
    }

    public void Interact()
    {
        float dist = Vector3.Distance(player.position, transform.position);
        if (dist < 10)
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
        animator.Play("openpull_01");
        isOpen = true;
        yield return new WaitForSeconds(.5f);
    }

    IEnumerator Close()
    {
        animator.Play("closepush_01");
        isOpen = false;
        yield return new WaitForSeconds(.5f);
    }
}