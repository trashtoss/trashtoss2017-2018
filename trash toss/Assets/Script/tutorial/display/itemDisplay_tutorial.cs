using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class itemDisplay_tutorial : MonoBehaviour {

    public Sprite trash1;
    public Sprite trash2;
    public Sprite trash3;
    public Sprite trash4;
    public Sprite trash5;

    Image sprite;


    // Use this for initialization
    void Start () {
        sprite = GetComponent<Image>();

        switch (difficultySettings.tutorialLevelCounter)
        {
            case 1:
                sprite.sprite = trash1;
                break;
            case 2:
                sprite.sprite = trash2;
                break;
            case 3:
                sprite.sprite = trash3;
                break;
            case 4:
                sprite.sprite = trash4;
                break;
            case 5:
                sprite.sprite = trash5;
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
