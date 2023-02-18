using UnityEngine;
using System.Collections;
using System.Linq;

public class NyctophobiaGameManager : GameManager
{
    public Transform lightSources;
    public GameObject[] lightSourceObjects;
    public Material darkMaterial;
    public float timeToCutElectricity;

    private void Start()
    {
        Renderer[] objects = Object.FindObjectsOfType<Renderer>();
        lightSourceObjects = objects.Where(x => x.material.name.Contains("BA_Glow_White_01") || x.material.name.Contains("LampShadeFabric_On")).Select(x => x.gameObject).ToArray();
        StartCoroutine(CutElectricity());
    }
    IEnumerator CutElectricity()
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
    }
}