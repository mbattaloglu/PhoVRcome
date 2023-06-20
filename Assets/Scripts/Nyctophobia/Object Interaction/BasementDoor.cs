using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BasementDoor : MonoBehaviour
{
    private Animator animator;
    private bool isOpen;
    private Transform player;

    public GameObject warnText;
    private bool warnStarted = false;
    private void Start()
    {
        warnText.SetActive(false);
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
                        StartCoroutine(WarnUser());
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

    private IEnumerator WarnUser()
    {
        if(!warnStarted)
        {
            warnStarted = true;
            warnText.SetActive(true);
            yield return new WaitForSeconds(2);
            warnText.SetActive(false);
            warnStarted = false;
        }

        yield return null;
    }
}