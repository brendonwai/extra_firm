using UnityEngine;
using System.Collections;

public class Fighting : MonoBehaviour {
	public GameObject Dice;
	public GameObject RegionHead;
	public GameObject RegionBelly;
	public RegionScript Head;
	public RegionScript Belly;
	public int rollAR = 0;
	public int rollCR = 0;
	public int result = 0;
	// Use this for initialization
	void Start () {
		 Head = RegionHead.GetComponent<RegionScript>();
		 Belly = RegionBelly.GetComponent<RegionScript>();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.F)) {
			
			aftermath(Fight (Head.population-1,Belly.population));
			
		}
	}
	//rolls a dice + virus numbe and returns a result of attacker-defender
	int Fight(int AV,int CV){
		Dice.GetComponent<DiceScript>() .roller();
		rollAR = Dice.GetComponent<DiceScript> ().roll + AV;
		Dice.GetComponent<DiceScript>() .roller();
		rollCR = Dice.GetComponent<DiceScript> ().roll + CV;
		Debug.Log(result =rollAR - rollCR);
		return result;
	}
	void aftermath(int r){
		Head.Populate (1, 1);  //attack goes to 1 population
		if (r == 0) {		//tie
			Belly.Populate(0,r);
		}
		if (r > 0) {		//attacker wins
			Belly.Populate(1,r);
		}
		if (r < 0) {		//defender wins
			r = Mathf.Abs(r);
			Belly.Populate(2,r);
		}
	}
}
