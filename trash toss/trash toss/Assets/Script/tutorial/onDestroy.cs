using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onDestroy : MonoBehaviour {

	void OnDestroy()
	{
        if (destroyDetector.isDestroyed == false)
            secondStar.DestroyedCount++;
        destroyDetector.isDestroyed = true;
 
    }
}
