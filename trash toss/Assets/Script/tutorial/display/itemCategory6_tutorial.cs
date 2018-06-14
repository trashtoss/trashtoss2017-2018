using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class itemCategory6_tutorial : MonoBehaviour
{

    Text text;
    private string c = "--compost";
    private string r = "--recycle";
    private string l = "--landfill";
    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();

        text.text = l;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
