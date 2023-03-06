using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameObject.CompareTag("Finish"))
            {
                StartCoroutine(NyctophobiaGameLoop.GetInstance().CutElectricity());
                NyctophobiaGameManager.GetInstance().SetTaskType(NyctophobiaTaskList.ElectricityCut);
                gameObject.GetComponent<Collider>().enabled = false;
            }
            else
            {
                NyctophobiaGameLoop.GetInstance().checkpointCount++;
                //TODO : NyctophobiaGameManager.GetInstance().checkpoints.childCount - 1 (change if to this)
                if (NyctophobiaGameLoop.GetInstance().checkpointCount == 1)
                {
                    NyctophobiaGameManager.GetInstance().SetTaskType(NyctophobiaTaskList.CheckpointsReached);
                    NyctophobiaGameLoop.GetInstance().OnAllCheckpointsReached();
                }
                gameObject.SetActive(false);
            }
            gameObject.GetComponent<Task>().isCompleted = true;
        }
    }
}