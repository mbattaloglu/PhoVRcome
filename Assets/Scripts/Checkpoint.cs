using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameObject.CompareTag("Finish"))
            {
                StartCoroutine(NyctophobiaGameManager.GetInstance().CutElectricity());
            }
            else
            {
                Debug.Log("Checkpoint reached: " + gameObject.name);
                InformationPanel.GetInstance().tasks.Remove(gameObject.GetComponent<Task>());
                Destroy(gameObject.GetComponent<Task>());
                InformationPanel.GetInstance().Initialize();
                NyctophobiaGameManager.GetInstance().checkpointCount++;
                //TODO : NyctophobiaGameManager.GetInstance().checkpoints.childCount - 1 (change if to this)
                if(NyctophobiaGameManager.GetInstance().checkpointCount == 1)
                {
                    Debug.Log("All checkpoints reached. Go to the livingroom.");
                    NyctophobiaGameManager.GetInstance().OnAllCheckpointsReached();
                }
                gameObject.SetActive(false);
            }
        }
    }
}