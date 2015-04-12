using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	public int playerNumber;
	public GameObject Manager;
	public List<GameObject> RegionsOwned;
	public int RegionCount=0;
	public int TotalVirus=0;

	public int max =6;

	public Text RegionText;
	public Text VirusText;

	Manger manger;

	// Use this for initialization
	void Start () {
		manger=Manager.GetComponent<Manger>();
		RegionText = RegionText.GetComponent<Text> ();
		VirusText = VirusText.GetComponent<Text> ();
	}
	void increaseMaxRoll(){
	                     
		max += 1 ;
	 }
	void decreaseMaxRoll(){
		
		max -= 1 ;
	}
	// Update is called once per frame
	void Update () {
		RegionText.text = "Regions: " + RegionCount.ToString ();
		VirusText.text = "Viruses: " + TotalVirus.ToString ();
	}

	void updateRegionOwned(){
		RegionsOwned.Clear();
		TotalVirus=0;
		foreach (GameObject region in manger.CompleteRegionList){
			RegionScript reg=region.GetComponent<RegionScript>();
			if (reg.owner==playerNumber && !RegionsOwned.Contains(region)){
				RegionsOwned.Add(region);
				TotalVirus+=reg.population;
			}
		}
		RegionCount=RegionsOwned.Count;
	}

	void PlayerAction(){
		updateRegionOwned();
		int count =0;
		int pop = Random.Range (0, 3);
		foreach (GameObject region in RegionsOwned){
			region.GetComponent<RegionScript>().Enabled=true;
			
			if (count > 0 )
			{	
				
				RegionScript reg=region.GetComponent<RegionScript>();
				int new_pop=pop+reg.population;
				if(new_pop>10)
					new_pop=10;
				reg.Populate(playerNumber,new_pop);

			}
			count+=1;
			
		}
	}

	void PlayerEndEnable(){
		foreach (GameObject region in RegionsOwned){
			RegionScript reg=region.GetComponent<RegionScript>();
			reg.Enabled=false;
		}
		updateRegionOwned();
	}

	void PlayerEndActionable(){
		foreach (GameObject region in manger.CompleteRegionList){
			region.GetComponent<RegionScript>().Actionable=false;
		}
		updateRegionOwned();
	}
}
