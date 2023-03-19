using UnityEngine.SceneManagement;

public class NyctophobiaGameManager : GameManager
{
    #region Singleton

    private static NyctophobiaGameManager instance;

    private NyctophobiaGameManager()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public static NyctophobiaGameManager GetInstance()
    {
        return instance;
    }

    #endregion

    private NyctophobiaTaskList taskType;

    public bool isElectricCut;
    public bool isKeyFound;

    private void Start()
    {
        taskType = NyctophobiaTaskList.GoAllCheckpoints;
    }

    public void SetTaskType(NyctophobiaTaskList task)
    {
        this.taskType = task;
        NyctophobiaTaskManager.GetInstance().Initialize();
    }

    public NyctophobiaTaskList GetTaskType()
    {
        return this.taskType;
    }


}