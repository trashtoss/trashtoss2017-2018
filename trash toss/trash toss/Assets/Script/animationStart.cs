//Script Made By StrupsGames//
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class animationStart : MonoBehaviour 
{

	public Button Text;
	public Animator ani;
	//public Canvas yourcanvas;



	void Start () 
	{
		Text = Text.GetComponent<Button> ();
		ani.enabled = false;
		//yourcanvas.enabled = true;
	}


	public void Press() 

	{
		Text.enabled = true;
		ani.enabled = true;
		Destroy(Text,1);
		//yourcanvas.enabled = false;

	}
}