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
		RegionsOwned.Clear();
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
		int count =0;
		int pop = Random.Range (1, 3);
		foreach (GameObject region in RegionsOwned){
			region.GetComponent<RegionScript>().Enabled=true;
			if (count > 0)
			{
				region.GetComponent<RegionScript>().Populate(playerNumber,region.GetComponent<RegionScript>().population + pop);
			}
			count+=1;
		}
	}

	void PlayerEndEnable(){
		foreach (GameObject region in RegionsOwned){
			RegionScript reg=region.GetComponent<RegionScript>();
			reg.Enabled=false;
		}
	}

	void PlayerEndActionable(){
		foreach (GameObject region in manger.CompleteRegionList){
			region.GetComponent<RegionScript>().Actionable=false;
		}
	}
}
