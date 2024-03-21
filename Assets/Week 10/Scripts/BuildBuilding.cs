using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildBuilding : MonoBehaviour
{
    public GameObject[] buildings;
    public float scaleDuration = 2;

    private void Start()
    {
        StartCoroutine(BuildAllBuildings());
    }

    IEnumerator BuildAllBuildings() // use build() couritine in here and build the building in the array
    {
        foreach (GameObject building in buildings)
        {
            yield return StartCoroutine(Build(building));
        }
    }

    IEnumerator Build(GameObject building) //refer differnt buildings use in differnt courtouine
    {
        float buildTime = 0f;
        Vector3 initialScale = Vector3.zero; // giving vector3 a name here makes it easier
        Vector3 targetScale = Vector3.one*5;

        while (buildTime < scaleDuration) // while loop contineus until time reach duration
        {
            float t = buildTime / scaleDuration;
            building.transform.localScale = Vector3.Lerp(initialScale, targetScale, t);
            buildTime += Time.deltaTime;
            yield return null;
        }

        building.transform.localScale = targetScale; // scale is target scale
    }
}


