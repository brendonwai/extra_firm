using UnityEngine;
using System.Collections;

public class Fighting : MonoBehaviour {
	public GameObject Dice;
	public GameObject Region;
	public int testAR = 5;
	public int testCR = 3;
	public int rollAR = 0;
	public int rollCR = 0;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.F)) {
			
			Fight (testAR,testCR);
			
		}
	}
	void Fight(int AV,int CV){
		Debug.Log ("hihihihihihi");
		Dice.GetComponent<DiceScript>() .roller();
		Debug.Log(rollAR = Dice.GetComponent<DiceScript> ().roll + AV);
		Dice.GetComponent<DiceScript>() .roller();
		Debug.Log(rollCR = Dice.GetComponent<DiceScript> ().roll + CV);
		int result = (rollAR - rollCR);
	}

}
