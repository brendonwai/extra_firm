using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	public int playerNumber;
	public GameObject Manager;
	public List<GameObject> RegionsOwned;
	public int RegionCount=0;
	public int TotalVirus=0;
	Manger manger;

	// Use this for initialization
	void Start () {
		manger=Manager.GetComponent<Manger>();

		
	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject region in manger.CompleteRegionList){
			RegionScript reg=region.GetComponent<RegionScript>();
			if (reg.owner==playerNumber){
				RegionsOwned.Add(region);
				TotalVirus+=reg.population;
			}

		}
		RegionCount=RegionsOwned.Count;
	}

	void PlayerAction(){
		foreach (GameObject region in RegionsOwned){
			region.GetComponent<RegionScript>().Enabled=true;
		}
	}

	void PlayerEndEnable(){
		foreach (GameObject region in RegionsOwned){
			RegionScript reg=region.GetComponent<RegionScript>();
			reg.Enabled=false;
		}
	}

	void PlayerEndActionable(){
		foreach (GameObject region in RegionsOwned){
			RegionScript reg=region.GetComponent<RegionScript>();
			reg.Actionable=false;
		}
	}
}
