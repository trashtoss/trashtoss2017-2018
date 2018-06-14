using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class difficultySettings : MonoBehaviour {
    public static float timer;
    public static bool isStarted;
    public static bool isCompleted;
    public static bool gameOvered;
    public static bool isTutorial;
    public static int score; // lives/pollution bar
    public static int landfillCounter;
    public static int endlessScore; //endless mode score based on correct tosses (+10 correct, -5 wrong)
    public static float barGainRatePlastic;
    public static float barGainRateMetal;
    public static float barGainRateGlass;
    public static float barGainRatePaper;
    public static float barGainRateCompost;
    public static float barDropRate;
    public static float moveSpeed;
    public static int levelGoal;
    public static int livesLeft; // chances before failing endless mode
    public static float spawnGap;
    public static float digestionTime_rec;
    public static float digestionTime_com;
	public static List<string> playRecord;
	public static List<string> failedRecord;
	public static int levelCounter = 1;
    public static int tutorialLevelCounter;
	public static bool doubleTap;
	public static bool dTapError;
	public static float totalAccumulatedMoney;
    // Use this for initialization
    void Start ()
    {
		Time.timeScale = 1;
		totalAccumulatedMoney = 0;
        isStarted = false;
        isCompleted = false;
        gameOvered = false;
        isTutorial = false;
		doubleTap = false;
		dTapError = false;
        score = 0;
        landfillCounter = 0;
        endlessScore = persistentScore.PersistentScore;
		playRecord = new List<string> ();
		failedRecord = new List<string> ();
        //setDifficulty(10, 1, .01f, .05f, 10);
        secondStar.DestroyedCount = 0;
		print("game start: level goal: " + (levelGoal) + "    gainRateGlass: " + barGainRateGlass +
     	"    gainRatePlastic: " + barGainRatePlastic + "    gainRateMetal: " + barGainRateMetal +
    	"    gainRateCompost: " + barGainRateCompost + "    gainRatePaper: " + barGainRatePaper +
     	"    dropRate" + barDropRate + 
		"    speed: " + moveSpeed + "    limit: " + livesLeft);
    }
	
	// Update is called once per frame
	void Update ()
    {
		Time.timeScale = 1;

        if (isStarted)
            timer += Time.deltaTime;
        //print(timer);


		//level goal
        //print(score);
        if (score == levelGoal)
		{
		   persistentScore.PersistentScore = endlessScore;
		   print("pscore:" + persistentScore.PersistentScore);
		   print("\n");
		   print("score:" + endlessScore);
			isCompleted = true;
			Time.timeScale = 0;
		}

        //game over
		if (landfillCounter >= livesLeft) {
			gameOvered = true;
			Time.timeScale = 0;
		}
	}

    
	public void setDifficulty(string difficulty)
    {
		switch (difficulty)
		{
			case "low":
				setGoal (8);
				setGainRate (1.0f, 1.2f, 1.5f, 0.7f, 0.5f);
				setDropRate (.011f);
				setSpeed (.03f);
				setLives (5);
				setSpawnGap (2f);
				break;
			case "medium low":
				setGoal (16);
				setGainRate (1.0f, 1.2f, 1.5f, 0.7f, 0.5f);
				setDropRate (.011f);
				setSpeed (.03f);
				setLives (5);
				setSpawnGap (2f);
				break;
			case "medium":
				setGoal (23);
				setGainRate (1.0f, 1.2f, 1.5f, 0.7f, 0.5f);
				setDropRate (.011f);
				setSpeed (.03f);
				setLives (5);
				setSpawnGap (2f);
				break;
			case "medium high":
				setGoal (32);
				setGainRate (1.0f, 1.2f, 1.5f, 0.7f, 0.5f);
				setDropRate (.011f);
				setSpeed (.03f);
				setLives (5);
				setSpawnGap (2f);
				break;
			case "high":
				setGoal (43);
				setGainRate (1.0f, 1.2f, 1.5f, 0.7f, 0.5f);
				setDropRate (.011f);
				setSpeed (.03f);
				setLives (5);
				setSpawnGap (2f);
				break;
			case "extreme":
				setGoal (70);
				setGainRate (1.0f, 1.2f, 1.5f, 0.7f, 0.5f);
				setDropRate (.011f);
				setSpeed (.03f);
				setLives (5);
				setSpawnGap (2f);
				break;
			default:
				setGoal (100);
				setGainRate (1.0f, 1.2f, 1.5f, 0.7f, 0.5f);
				setDropRate (.011f);
				setSpeed (.03f);
				setLives (5);
				setSpawnGap (2f);
				break;
		}
    }

    private void setGoal(int goal) { levelGoal = goal; }

	//sets gain rate for current money bar (not in use, should be changed/deleted)
    private void setGainRate(float rateGlass, float ratePlastic, float rateMetal, float ratePaper, float rateCompost) {
        barGainRateGlass = rateGlass; barGainRatePlastic = ratePlastic; barGainRateMetal = rateMetal;
        barGainRatePaper = ratePaper; barGainRateCompost = rateCompost;
    }

    private void setDropRate(float rate) { barDropRate = rate; }

    private void setSpeed(float speed) { moveSpeed = speed; }

    private void setLives(int lives) { livesLeft = lives; }

    private void setSpawnGap(float gap) { spawnGap = gap; }
}
