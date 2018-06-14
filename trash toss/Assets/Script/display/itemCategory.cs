using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class itemCategory : MonoBehaviour {

	Text text;

	// Use this for initialization
	void Start()
	{
		text = GetComponent<Text>();
        if (tips.tipsSlot1 <= 3)
            text.text = "--Compost";
        else if (tips.tipsSlot1 <= 19)
            text.text = "--Recycle";
        else if (tips.tipsSlot1 <= 30)
            text.text = "--Landfill";
        else
            text.text = "--Other";
	}

	// Update is called once per frame
	void Update()
	{
	}
}
