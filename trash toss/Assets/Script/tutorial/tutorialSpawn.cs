using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialSpawn : MonoBehaviour
{
    public GameObject trashItems;

    System.Random trashType = new System.Random();

    public void spawn(int min, int max)
    {
        Vector3 spawnSpot = GameObject.Find("spawn spot").transform.position;

        int caseSwitch = trashType.Next(min, max);
        Instantiate(trashItems.transform.GetChild(caseSwitch), spawnSpot, transform.rotation);
    }
}