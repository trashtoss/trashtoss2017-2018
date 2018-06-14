using UnityEngine;
using System.Collections;

public class spawnTrash : MonoBehaviour {

    public GameObject trashItems;
	public GameObject complexTrashItems;
	public GameObject double_1;
	public GameObject double_2;

    System.Random trashType = new System.Random();
    [SerializeField] private float xOffset;
	int caseSwitch = 0;

    public void spawn()
    {
        Vector3 spot = GameObject.Find("spawn spot").transform.position;
        Vector3 spawnSpot = spot + new Vector3(0, 2, 0);



		if (difficultySettings.endlessScore < 5) {
			caseSwitch = trashType.Next (1, complexTrashItems.transform.childCount);
			Instantiate (complexTrashItems.transform.GetChild (caseSwitch), spawnSpot, transform.rotation);
		} else {
			if (difficultySettings.doubleTap == true){
                StartCoroutine("wait");
				//double_2.transform.localScale = new Vector3 (.09f, .09f, .09f);
				//Instantiate (double_1.transform, spawnSpot, transform.rotation);
				//Instantiate (double_2.transform, spot, transform.rotation);
				difficultySettings.doubleTap = false;

			} else {
				caseSwitch = trashType.Next (1, complexTrashItems.transform.childCount);
				Instantiate (complexTrashItems.transform.GetChild (caseSwitch), spawnSpot, transform.rotation);
			}
		}
    }

    
    IEnumerator wait()
    {
        Time.timeScale = 0;
        Vector3 spot = GameObject.Find("spawn spot").transform.position;
        Vector3 spawnSpot = spot + new Vector3(0, 3.5f, 0);
        double_2.transform.localScale = new Vector3(.09f, .09f, .09f);
        Instantiate(double_1.transform, spawnSpot, transform.rotation);
        Instantiate(double_2.transform, spot, transform.rotation);
        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 1f;
    }
	void Update(){

	}
}
