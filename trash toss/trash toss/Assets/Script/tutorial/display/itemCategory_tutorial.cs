using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class itemCategory_tutorial : MonoBehaviour {

    Text text;
    private string c = "--compost";
    private string r = "--recycle";
    private string l = "--landfill";
	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        switch(difficultySettings.tutorialLevelCounter)
        {
            case 1:
                text.text = c;
                break;
            case 2:
                text.text = r;
                break;
            case 3:
                text.text = c;
                break;
            case 4:
                text.text = r;
                break;
            case 5:
                text.text = r;
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
