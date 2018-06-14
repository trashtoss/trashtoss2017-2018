using UnityEngine;
using System.Collections;

public class lerpable : MonoBehaviour
{
	private Vector3 startMarker;
	private Vector3 endMarker;
	public float speed = 15.0F;
	private float startTime = -1;
	private float journeyLength = -1;

	virtual public void Start()
	{
		//  Lerping is controlled by iff starttime != -1
		lerpTargetReached(); //  initialize everything to -1

	}

	virtual public void Update()
	{
		if (isLerping()) {
		//  If currently lerping towards somewhere
			float distCovered = (Time.time - startTime) * speed;
			float fractJourney = distCovered / journeyLength;
			transform.position = Vector3.Lerp (startMarker, endMarker, fractJourney);
		//  check for destination reached
			if (fractJourney > 0.99) {
			//  Pretty much there
				lerpTargetReached();
			}
		}
	}

	virtual public void lerpTargetReached(){
	//  Events scheduled to occur when the lerp reaches the target
		//  For example, turn off lerping
		startTime = -1;
		journeyLength = -1;
	}

	public void setLerpTarget(Vector3 destination){
		//  This is called once when the lerp target is set.
		//  First, activate the lerping physics
		startTime = Time.time;
		//  set the starting point to be the current position of the object
		startMarker = gameObject.transform.position;
		endMarker = destination;
		journeyLength = Vector3.Distance (startMarker, endMarker);

	}

	public bool isLerping (){
	//  Lerping is controlled by is starttime == -1
		return (startTime != -1);
	}
}