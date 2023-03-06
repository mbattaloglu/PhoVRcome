using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Keys : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<XRGrabInteractable>().selectEntered.AddListener(GetKeys);
    }

    private void GetKeys(SelectEnterEventArgs arg0)
    {
        if (NyctophobiaGameManager.GetInstance().isElectricCut)
        {
            NyctophobiaGameManager.GetInstance().isKeyFound = true;
            NyctophobiaGameManager.GetInstance().SetTaskType(NyctophobiaTaskList.SearchForPhone);
            StartCoroutine(DestroyKeys());
        }
    }

    private IEnumerator DestroyKeys()
    {
        yield return new WaitForSeconds(0.25f);
        Destroy(gameObject);
    }
}
