using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class itemCategory_second : MonoBehaviour {

	Text text;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
        if (tips.tipsSlot2 <= 3)
            text.text = "--Compost";
        else if (tips.tipsSlot2 <= 19)
            text.text = "--Recycle";
        else if (tips.tipsSlot2 <= 30)
            text.text = "--Landfill";
        else
            text.text = "--Other";
    }

    // Update is called once per frame
    void Update()
	{
	}
}
