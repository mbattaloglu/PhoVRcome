using UnityEngine;

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

    public NyctophobiaTaskList taskType;

    public bool isElectricCut;
    public bool isKeyFound;

    private void Start()
    {
        taskType = NyctophobiaTaskList.GoAllCheckpoints;
    }
}