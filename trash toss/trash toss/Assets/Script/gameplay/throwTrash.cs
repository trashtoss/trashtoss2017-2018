using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class throwTrash : lerpable
{
	public float digestionTime;
	private int destroyTime = 3;

    //DO NOT TOUCH THESE THEY ARE USED FOR BARSCRIPT TO GET THE INFO NECESSARY
    public static bool correctCollision = false;
    public static GameObject tagHolder;
    // You can do whatever to these
    private Vector3 lastMousePosition;
	private Vector3 newMousePosition;
	private Vector2 distance;
	private Vector3 distance2;
	private Rigidbody2D rb;
	private bool moveByBelt;
	private bool moveBySwipe;
	private bool startCounting;
	private float time;
	private bool cleanedItem = false;
//	private Text doubleTapError;
    GameObject temp;


	//Added for double tap feature.
	int TapCount;
	public float MaxDubbleTapTime = 2.0f;
	float NewTime;
	private bool doubleTapInit_1;
	private bool doubleTapInit_2;
	Touch touch;
	//End of stuff added for double tap feature.

    //  Not thrown for now.
    private GameObject throwingTarget = null; 
	//  Pointers to the target objects
	GameObject compost;
	GameObject landfill;
	GameObject recycle;
	GameObject otherBin;
	GameObject sink;





	public override void Start()
	{

			


		base.Start();
		//ADDED FOR DOUBLE TAP
		TapCount = 0;
        //  Reset these variables every step
        moveByBelt = true; //  move the object down if true, basically
		moveBySwipe = false; //  set to true after the finger is released
		startCounting = false; //  countdown til automatated item destruction when true
		time = 0; //  presumably the time passed since the counter was activated

		//starts idle animations
		compost = GameObject.Find("composite bin");
		//compostanim = compost.GetComponent<Animator> ();

		landfill = GameObject.Find("landfill bin");
		//landfillanim = landfill.GetComponent<Animator> ();

		recycle = GameObject.Find("recycle bin");
		//recycleanim = recycle.GetComponent<Animator> ();


		//Find the sink
		sink = GameObject.Find("sink");
        otherBin = GameObject.Find("other bin");


}


	public override void Update()
	{
		
		base.Update();
		//  This is the shared update cycle of all throwable trash objects
		if (isLerping ()) {
			if (throwingTarget != null) {
				throwingTarget.GetComponent<bin_controller> ().anticipatingBad = false;
				throwingTarget.GetComponent<bin_controller> ().anticipatingGood = false;
			
				//  Do nothing in terms of physics.
				//  Let the lerp handle it.
				if (!matchesBin (throwingTarget)) {
					//  Uh oh! The finger has realeased the trash and it's going to the wrong bin!
					//  Make the bin wince
					throwingTarget.GetComponent<bin_controller> ().anticipatingBad = true;
				} else {
					//  make the bin excited to get a good trash
					throwingTarget.GetComponent<bin_controller> ().anticipatingGood = true;
				}
			}
		} else if (moveByBelt) {
			//  Literally move the item downward if it is on the belt
			transform.Translate (Vector3.down * (difficultySettings.moveSpeed) * Time.timeScale);
		}
		//ADDED TO CHECK FOR DOUBLE TAP
		else if (doubleTapInit_1) {
			NewTime = Time.time + MaxDubbleTapTime;
			doubleTapInit_1 = false;
//			} else if(TapCount == 2 && Time.time <= NewTime){
//
//				//Whatever you want after a dubble tap    
//				Destroy(gameObject);
//
//				TapCount = 0;
		} else if (doubleTapInit_2) {

			difficultySettings.doubleTap = true;

			TapCount = 0;
			doubleTapInit_2 = false;
			Destroy (gameObject);
		}
		//END OF DOUBLE TAP
		else if (moveBySwipe) {
			//  The buffer is the drag distance that is tolerated before anything happens
			float distanceBuffer = 0.2f;
			float horizontalSensitivity = 0.2f;
			//  Presumably distance2 contains the direction of the swipe, 
			//  and the decimal controls the speed.
			//transform.Translate (distance2 * .1f);
			GameObject closestBin = raycastForBin(this.gameObject.transform.position, distance2.normalized);
			if (closestBin != null) {
				throwAt (closestBin);
			} else {
				//  Neither swiped up nor down. Do neither
				moveByBelt = true;
				moveBySwipe = false;
			}
			//  Convert the drag vector into a discrete direction
			/*
			if (Mathf.Abs (distance2.x) > horizontalSensitivity) {
				//  horizontal > vertical
				if (distance2.x > distanceBuffer) {
					//right
					throwAt(compost);
				} else if (distance2.x < -distanceBuffer) {
					//left
					throwAt(recycle);
				}
			} else {
				//  v > h
				if (distance2.y > distanceBuffer) {
					//down
					throwAt (otherBin);
				} else if (distance2.y < -distanceBuffer) {
					//up
					throwAt (landfill);
				} else {
					//  Neither swiped up nor down. Do neither
					moveByBelt = true;
					moveBySwipe = false;
				}
			}
			*/

		}  
		else if (twoStepItemSatisfied())
		{
			
		}


	

		//  Check to see if the object should be destroyed yet
		timeOut(destroyTime);
	}

	public void throwAt(GameObject targetObj){
		//  Throws the current trash object at the specified gameObject
		setLerpTarget(targetObj.transform.position);
		throwingTarget = targetObj;
		cleanedItem = false;
		//print("throw target:" + throwingTarget);
	}

	public override void lerpTargetReached(){

		base.lerpTargetReached (); //  turns the lerp mechanic off
		//  Now activate the throwing target as if there was a collision.
		if (null != throwingTarget) {
			//print("lerp reached, checking against object:" + throwingTarget);
			checkForGoal (throwingTarget);
			//  and then clean up
			throwingTarget = null;
		}
	}

	void OnMouseDown()
	{
		lastMousePosition = Input.mousePosition;
	}



	void OnMouseUp()
	{
		// disable collider so player cannot swipe twice (so much for that)

//		if (TapCount == 0) {
//			doubleTapInit = true;
//			TapCount++;
//		} else {
		newMousePosition = Input.mousePosition;
		if (lastMousePosition != newMousePosition) {
			if (gameObject.CompareTag ("twostep")) {
				difficultySettings.dTapError = true;
			}
			moveByBelt = false;
			//  If just distance is used, the objects move incredibly fast
			//  but players control speed of object
			distance = newMousePosition - lastMousePosition;

			float xsquare = distance.x * distance.x;
			float ysquare = distance.y * distance.y;
			//  so dist2 extracts just direction
			distance2 = distance / distance.magnitude;

			//  speed of the throw proportional to the finger drag distance
			float minimumSpeed = 7f;
			speed = Mathf.Max (minimumSpeed, distance.magnitude / 10f);

			moveBySwipe = true;
			startCounting = true;
		} else if (TapCount == 0 && gameObject.CompareTag("twostep")) {
			TapCount++;
			doubleTapInit_1 = true;
			moveByBelt = false;
			startCounting = true;
		} else if (TapCount == 1) {
			doubleTapInit_2 = true;
		} else if (Time.time > NewTime) {
			TapCount = 0;
			moveByBelt = true;
			startCounting = false;
		}  
	}




	private void timeOut(float timer)
	{
		//  Throw the object in the landfill after the item counter diminishes
		//bool exist = false;

		if (startCounting)
			time += Time.deltaTime;
		if (time > timer)
		{
			difficultySettings.landfillCounter++;
			Destroy(gameObject);
		}
	}


	// bin collisions
	void OnTriggerEnter2D(Collider2D coll)
	{
		if(!cleanedItem)
		{
		checkForGoal(coll.gameObject);
		}
	}

	public bool matchesBin(GameObject bin){
		if (bin == null || this.gameObject == null)
			return false;
		return bin.tag == gameObject.tag || isRecyclable(this.gameObject) && bin.tag == "recycle";
	}

	public bool isRecyclable( GameObject trashObject){
		return  trashObject.tag == "Plastic" || trashObject.tag == "Paper" ||
				trashObject.tag == "Metal" || trashObject.tag == "Glass";
	}

	//  bin collisions
	public bool checkForGoal(GameObject other){
		//  checks for if the current trash scored a point and performs the following logic if so.
		//  returns true on success
		correctCollision = false;
		temp = gameObject;

		// check if this is tutorial and is being used with arrows
		if (other.tag != "spawnSpot") {
			
			//otherwise its recycle and create a temp to store tag
			if (isRecyclable (this.gameObject)) {
				temp = (GameObject)Instantiate (gameObject); //Why do we make a new object?
				//print("Before Change  " + gameObject.tag);
				temp.tag = "recycle";
				//print("After Change  " + gameObject.tag);
				//print (temp.tag);
			}
			if (matchesBin (other)) {
				print("item type: " + gameObject.tag + " matches bin: " + other.tag);
                handleCorrectItem(other);
				return true;
			}
			else { 
				print("item type: " + gameObject.tag + " does not match bin: " + other.tag);
				// if toss is thrown in incorrect bin
                difficultySettings.endlessScore -= 5; //subtract 5 from endless mode score if toss is wrong
				//  Increment penalty
				difficultySettings.landfillCounter++;
				//  Give feedback for the correct bin
				flashCorrectBin ();
				//  Destroy in all cases, regardless of success
				Destroy (gameObject); //  added
				Destroy (temp);
				other.GetComponent<bin_controller> ().animateIncorrect ();
				return false;
			}

		}
		return false;
	}



	public void flashCorrectBin(){
		//  Animates the arrow over the bin that the trash belongs to
		int answerFlashDuration = 36;
		if (matchesBin (compost)) {
			compost.gameObject.GetComponent<bin_controller> ().flashArowTimer = answerFlashDuration;
		} else if (matchesBin (landfill)) {
			landfill.gameObject.GetComponent<bin_controller> ().flashArowTimer = answerFlashDuration;
		} else if (matchesBin (recycle)) {
			recycle.gameObject.GetComponent<bin_controller> ().flashArowTimer = answerFlashDuration;
		} else if (matchesBin (otherBin)) {
			otherBin.gameObject.GetComponent<bin_controller> ().flashArowTimer = answerFlashDuration;
		} else if (matchesBin (sink)) {
			sink.gameObject.GetComponent<bin_controller> ().flashArowTimer = answerFlashDuration;
		}
	}
	
	public bool twoStepItemSatisfied(){
		return false;
	}
	
	public void useSink(GameObject itemToReset)
	{
		moveByBelt = true;
		moveBySwipe = false;
		Vector3 originBase = GameObject.Find("spawn spot").transform.position;
		throwingTarget = null;
		cleanedItem = true;
		setLerpTarget( originBase + new Vector3(0,2,0));
		print(tag + " " + transform.position);
		startCounting = false;
		
		Transform myChild = gameObject.transform.GetChild(0);
		SpriteRenderer mySpriteRenderer = GetComponent<SpriteRenderer>();
		SpriteRenderer childSpriteRenderer = myChild.gameObject.GetComponent<SpriteRenderer>();
		mySpriteRenderer.sprite = childSpriteRenderer.sprite;
		tag = myChild.tag;
		
	}
	
	public void handleCorrectItem( GameObject binToAnimate){
		
		if(tag == "sink")
		{
			useSink(gameObject);
		}
		else{
			difficultySettings.endlessScore += 10; //adds 10 to endless mode score if correct toss
			difficultySettings.score += 1;
			difficultySettings.playRecord.Add (gameObject.name.Substring (0, gameObject.name.Length - 7));

			// MONEY SYSTEM: Update accumulated money if current item has cost
			if (getItemCost(gameObject) != 0) {
				print ("getItemCost called in handleCorrectItem");
				var price = getItemCost (gameObject);
				difficultySettings.totalAccumulatedMoney += price;
				print ("this item costs: " + price);
				print ("total money: " + difficultySettings.totalAccumulatedMoney);
			}

			if (gameObject.tag == "composite") {
				//print (difficultySettings.score + " Composite");
				difficultySettings.digestionTime_com = digestionTime;
				//tagHolder = gameObject;
				if (!difficultySettings.isTutorial) { 
					tagHolder = (GameObject)Instantiate (gameObject);
				}
				correctCollision = true;

			} else if (gameObject.tag == "recycle" || temp.tag == "recycle") {
				difficultySettings.digestionTime_rec = digestionTime;
				if (!difficultySettings.isTutorial) {
					tagHolder = (GameObject)Instantiate (gameObject);
				}
				//tagHolder = gameObject;
				correctCollision = true;
			}
			
			
			Destroy (gameObject); //Marking this for later. Here is where we return sink items to origin once we have them
			
			Destroy (temp);
			
			//print (gameObject);
			//print (difficultySettings.score);
			if(binToAnimate)
			{
				binToAnimate.GetComponent<bin_controller> ().animateCorrect ();
			}
		}
	}
	
	public GameObject raycastForBin(Vector3 origin, Vector3 direction){
		//  Return the closest bin to any point in the line provided
		GameObject closestBin = null;
		float closestDistanceToCheckpoint = 99999;

		int rayIncrement = 3;
		for (int rayDistance = 0; rayDistance < 100; rayDistance += rayIncrement){
			Vector3 pointToCheck = origin + direction * rayDistance; //  Travel incrementally along this direction as loop continues
			float distanceFromBinToRayPoint;

			//  Go through all the bins and find the closest one to this point
			// sink is closest to pointToCheck
			// if sink doesn't exist (beacuse we are playing the tutorial) then ignore
			if (sink != null) {
				distanceFromBinToRayPoint = Vector3.Distance (sink.gameObject.transform.position, pointToCheck);
				if (distanceFromBinToRayPoint < closestDistanceToCheckpoint) {
					closestBin = sink;
					closestDistanceToCheckpoint = distanceFromBinToRayPoint;
				}
			}

			// recycling bin is closest to pointToCheck
			distanceFromBinToRayPoint = Vector3.Distance(recycle.gameObject.transform.position , pointToCheck);
			if (distanceFromBinToRayPoint < closestDistanceToCheckpoint) {
				//  New record found
				//  New record found
				closestBin = recycle;
				closestDistanceToCheckpoint = distanceFromBinToRayPoint;
			}

			// compost is closest to pointToCheck
			distanceFromBinToRayPoint =  Vector3.Distance(compost.gameObject.transform.position , pointToCheck);
			if (distanceFromBinToRayPoint < closestDistanceToCheckpoint) {
				//  New record found
				closestBin = compost;
				closestDistanceToCheckpoint = distanceFromBinToRayPoint;
			}

			// landfill is closest to pointToCheck
			distanceFromBinToRayPoint =  Vector3.Distance(landfill.gameObject.transform.position , pointToCheck);
			if (distanceFromBinToRayPoint < closestDistanceToCheckpoint) {
				//  New record found
				closestBin = landfill;
				closestDistanceToCheckpoint = distanceFromBinToRayPoint;
			}

			// otherBin is closest to pointToCheck
			distanceFromBinToRayPoint =  Vector3.Distance(otherBin.gameObject.transform.position , pointToCheck);
			if (distanceFromBinToRayPoint < closestDistanceToCheckpoint) {
				//  New record found
				closestBin = otherBin;
				closestDistanceToCheckpoint = distanceFromBinToRayPoint;
			}
		}
		//print("bin selected is: " + closestBin);
		return closestBin;
	}
    
    // MONEY SYSTEM: returns cost of current item based on name
	public float getItemCost(GameObject trashItem) {
		var itemCost = 0f;
		var itemName = trashItem.transform.name;
		print ("getItemCost reached");
		print ("item: " + itemName);
		switch(itemName)
		{
		case "cleanHummus": //not sure which clone is needed for complex items?
			itemCost = .5f;
			break;
        case "dirtyHummus(Clone)":
			itemCost = .5f;
			break;
		case "egg-carton":
			itemCost = .002f;
			break;
        case "egg-carton(Clone)":
			itemCost = .002f;
			break;
		case "cerealNoPlastic": //not sure which clone is needed for complex items?
			itemCost = .003f;
			break;
		case "cleanSodaCan": //not sure which clone is needed for complex items?
			itemCost = .05f;
			break;
		case "Trash_TunaCan":
			itemCost = .05f;
			break;
        case "Trash_TunaCan(Clone)":
			itemCost = .05f;
			break;
		case "Trash_GlassBottles_1":
			itemCost = .05f;
			break;
        case "Trash_GlassBottles_1(Clone)":
			itemCost = .05f;
			break;
		case "Trash_GlassBottles_2":
			itemCost = .05f;
			break;
        case "Trash_GlassBottles_2(Clone)":
			itemCost = .05f;
			break;
		case "glass":
			itemCost = .05f;
			break;
        case "glass(Clone)":
			itemCost = .05f;
			break;
		case "foil":
			itemCost = .05f;
			break;
        case "foil(Clone)":
			itemCost = .05f;
			break;
		case "ketchup":
			itemCost = .1f;
			break;
        case "ketchup(Clone)":
			itemCost = .1f;
			break;
		case "clean tomato sauce jar": //not sure which clone is needed for complex items?
			itemCost = .1f;
			break;
		case "newspaper":
			itemCost = .001f;
			break;
        case "newspaper(Clone)":
			itemCost = .001f;
			break;
		case "envelope":
			itemCost = .0002f;
			break;
        case "envelope(Clone)":
			itemCost = .0002f;
			break;
		case "milkJug_empty": //not sure which clone is needed for complex items?
			itemCost = .05f;
			break;
		case "milk":
			itemCost = .05f;
			break;
        case "milk(Clone)":
			itemCost = .05f;
			break;
		default:
			itemCost = 0;
			break;
		}
		print ("cost: " + itemCost);
		return itemCost;
	}
}