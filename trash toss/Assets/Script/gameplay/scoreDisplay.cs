using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scoreDisplay : MonoBehaviour {

    Text text;
    private int displayScore;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        displayScore = difficultySettings.endlessScore;
        text.text =  displayScore.ToString();
    }
}
