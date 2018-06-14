using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DisplayTipText : MonoBehaviour {
	public Text Tip;
	public int NumOfTips = 3;
	public List<string> TipsList;
	//static Random randomize = new Random();
	// Use this for initialization
	void Start () {
		
	}
	void OnEnable(){
		string RandomizeTips = TipsList[Mathf.RoundToInt(Random.Range(0f, (float)TipsList.Count-1))];
		Tip.text = RandomizeTips;
	}
	// Update is called once per frame
	void Update () {
		

	}
}
