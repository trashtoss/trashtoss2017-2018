using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class startTutorial : MonoBehaviour
{	
	public tutorialSpawn spawnFunc;
	public Button startButton;
	public Button completeButton;
	//public Button zbc;


	void Start()
	{
		Button start = startButton.GetComponent<Button>();
		start.onClick.AddListener(startOnClick);
		Button complete = completeButton.GetComponent<Button>();
		complete.onClick.AddListener(completeOnClick);
		//Button test = zbc.GetComponent<Button> ();
		//test.onClick.AddListener (change);
	}

	void Update()
	{
		if (difficultySettings.score == difficultySettings.levelGoal)
		{
			enable(transform.Find("Level complete").gameObject);
			enable(completeButton.gameObject);
		}
	}
	void startOnClick()
	{
		difficultySettings.isStarted = true;
        difficultySettings.isTutorial = true;
        //transform.FindChild("game start").gameObject.SetActive(false);
        disable(transform.Find("Level Panel").gameObject);
		disable(startButton.gameObject);
        switch (difficultySettings.tutorialLevelCounter)
        {
            case 1:
                spawnFunc.spawn(0, 6);
                break;
            case 2:
                spawnFunc.spawn(6, 12);
                break;
            case 3:
                spawnFunc.spawn(12, 18);
                break;
            case 4:
                spawnFunc.spawn(18, 24);
                break;
            case 5:
                spawnFunc.spawn(24, 30);
                break;
        }
    }

	void completeOnClick()
	{
		disable(completeButton.gameObject);
		disable(transform.Find("Level complete").gameObject);
		levelManager.LoadPreviousScene();
	}

	/*void change()
	{
		difficultySettings.spawnGap = .1f;
	}*/

	private void enable(GameObject obj) { obj.SetActive(true); }
	private void disable(GameObject obj) { obj.SetActive(false); }
}
