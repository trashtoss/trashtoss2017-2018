using UnityEngine;
using System.Collections;

public class trashMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (!difficultySettings.gameOvered) {
			UnityEngine.MonoBehaviour.print("Game playing");	
			transform.Translate (Vector3.down * difficultySettings.moveSpeed * Time.timeScale * Time.deltaTime);
		} else {
			UnityEngine.MonoBehaviour.print("Game over");	
		}
	}
}
