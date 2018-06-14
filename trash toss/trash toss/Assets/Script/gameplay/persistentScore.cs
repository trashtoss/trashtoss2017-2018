using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class persistentScore : MonoBehaviour {
	public static int PersistentScore;
	// A hack to keep score persistent between endless mode levels
	void Start () {
		DontDestroyOnLoad(this);
		PersistentScore = 0;
		if (FindObjectsOfType(GetType()).Length > 1)
         {
             Destroy(gameObject);
         }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
