using UnityEngine;
using System.Collections;

public class Fighting : MonoBehaviour {
	public GameObject Dice;
	public int rollAR = 0;
	public int rollCR = 0;
	public int result = 0;
	// Use this for initialization
	void Start () {

	}

	//rolls a dice + virus numbe and returns a result of attacker-defender
	public void Fight(GameObject ClickedRegion,GameObject ActionedRegion){
		RegionScript creg=ClickedRegion.GetComponent<RegionScript>();
		RegionScript areg=ActionedRegion.GetComponent<RegionScript>();
		int AV=creg.population-1;
		int CV=areg.population;
		if (areg.owner==0)
			result=AV;
		else if(areg.owner==creg.owner){
			result=AV+CV;
			if(result>10)
				result=10;
		}
		else{
			Dice.GetComponent<DiceScript>() .roller();
			rollAR = Dice.GetComponent<DiceScript> ().roll + AV;
			Dice.GetComponent<DiceScript>() .roller();
			rollCR = Dice.GetComponent<DiceScript> ().roll + CV;
			result =rollAR - rollCR;
		}
		creg.Populate(creg.owner,1);
		if(result==0)
			areg.Populate(0,0);
		else if(result>0)
			areg.Populate(creg.owner,result);
		else{
			result=Mathf.Abs(result);
			areg.Populate(areg.owner,result);
		}
		
	}

}
