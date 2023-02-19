using UnityEngine;
using System.Collections;
using System.Linq;

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

    public Transform lightSources;
    public Transform checkpoints;

    public Material darkMaterial;
    public Material lightMaterial;

    public float timeToCutElectricity;

    public GameObject[] lightSourceObjects;

    public GameObject emergencyLight;
    public GameObject emergencySpot;

    public float checkpointCount;

    private void Start()
    {
        checkpointCount = 0;
        Renderer[] objects = Object.FindObjectsOfType<Renderer>();
        lightSourceObjects = objects.Where(x => x.material.name.Contains("BA_Glow_White_01") || x.material.name.Contains("LampShadeFabric_On")).Select(x => x.gameObject).ToArray();
    }

    public IEnumerator CutElectricity()
    {
        yield return new WaitForSeconds(timeToCutElectricity);
        for (int i = 0; i < lightSources.childCount; i++)
        {
            lightSources.GetChild(i).gameObject.SetActive(false);
        }
        for (int i = 0; i < lightSourceObjects.Length; i++)
        {
            lightSourceObjects[i].GetComponent<Renderer>().material = darkMaterial;
        }
        yield return new WaitForSeconds(1);
        emergencyLight.GetComponent<Renderer>().material = lightMaterial;
        emergencyLight.SetActive(true);
        emergencySpot.SetActive(true);
    }

    public void OnAllCheckpointsReached()
    {
        Transform final = checkpoints.GetChild(checkpoints.childCount - 1);
        final.gameObject.SetActive(true);
    }
}

