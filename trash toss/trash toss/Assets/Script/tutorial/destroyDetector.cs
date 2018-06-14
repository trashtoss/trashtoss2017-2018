using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyDetector : MonoBehaviour {

	public static bool isDestroyed;
	public tutorialSpawn spawnFunc;
    private int itemRangeMin;
    private int itemRangeMax;
    

    // Use this for initialization
    void Start () 
	{
        isDestroyed = false;
        switch (difficultySettings.tutorialLevelCounter)
        {
            case 1:
                itemRangeMin = 0;
                itemRangeMax = 6;
                break;
            case 2:
                itemRangeMin = 6;
                itemRangeMax = 12;
                break;
            case 3:
                itemRangeMin = 12;
                itemRangeMax = 18;
                break;
            case 4:
                itemRangeMin = 18;
                itemRangeMax = 24;
                break;
            case 5:
                itemRangeMin = 24;
                itemRangeMax = 30;
                break;
        }
        //spawnFunc.spawn(kinds);
    }
	
	// Update is called once per frame
	void Update () 
	{
        

        if (isDestroyed) 
		{
            spawnFunc.spawn (itemRangeMin, itemRangeMax);
			isDestroyed = false;
        }
	}
}
