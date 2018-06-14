using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopItemsFromMoving : MonoBehaviour {
	public GameObject LevelInfo;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnEnable(){
		Time.timeScale = 0;
	}

	void OnDisable(){
		Time.timeScale = 1;
	}
}
