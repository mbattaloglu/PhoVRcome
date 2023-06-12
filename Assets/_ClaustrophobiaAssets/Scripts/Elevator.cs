using UnityEngine;

public class Elevator : MonoBehaviour
{
    public bool isDoorOpen;

    public bool isPlayerInside;

    private void Start()
    {
        isDoorOpen = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isPlayerInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
        }
    }
}