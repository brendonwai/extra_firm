﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RegionScript : MonoBehaviour {

	GameObject Player1;
	GameObject Player2;
	GameObject manager;

	//name of the region
	public string regionName;

	public AudioClip select;

	//array of regions linked to this region
	//add in regions through inspector
	public GameObject[] LinkedRegions;

	//player occupying the region
	//0 for neutral,  1~4 to specify player number
	public int owner=0;

	//amount of virus currently in the region
	public int population=0;

	//percentage counted towards the whole human body
	public int weight;

	//Object reference to the virus object
	public GameObject virus;

	//List to store virus objects
	private List<GameObject> VirusList;

	public bool Enabled;
	public bool Clicked;
	public bool Actionable;
	public bool Actioned;

	SpriteRenderer sprite;

	public Sprite normal;
	public Sprite highlighted;
	public Sprite pressed;



	// Use this for initialization
	void Start () {
		VirusList=new List<GameObject>();
		sprite=GetComponent<SpriteRenderer>();
		Player1=GameObject.Find("Player1");
		Player2=GameObject.Find("Player2");
		manager=GameObject.Find("Manager");
		Enabled=false;
		Clicked=false;
		Actionable=false;
		Actioned=false;
		if(owner!=0 && population!=0)
			Populate(owner,population);
	}


	// Set owner and population
	// Destroys and Instantiates virus object according to 
	// owner and population status
	public void Populate(int new_owner, int amount){
		Debug.Log(regionName+"'s new owner is "+new_owner+"\n amount is "+amount);
		if(population>0){
			ClearVirus();
		}
		owner=new_owner;
		population=amount;
		switch(owner){
			case 0:
				sprite.color=Color.white;
				break;
			case 1:
				sprite.color=new Color(255/255.0f,116/255.0f,116/255.0f);
				break;
			case 2:
				sprite.color=new Color(88/255.0f,176/255.0f,249/255.0f);
				break;
		}
		GenerateVirus();
	}

	//Destroys virus objects and cleans up VirusList
	private void ClearVirus(){
		if(VirusList.Count>0){
			for(int i=0;i<VirusList.Count;i++){
				Destroy(VirusList[i]);
			}
			VirusList.Clear();
		}
	}

	//Instantiates Virus objects in VirusList
	private void GenerateVirus(){
		for(int i=0;i<population;i++){
			Vector2 pos=new Vector2(transform.position.x+Random.Range(-.4f,.4f),transform.position.y+Random.Range(-.4f,.4f));
			VirusList.Add((GameObject)Instantiate(virus,pos,Quaternion.identity));
			VirusList[i].SendMessage("SetOwner",owner);
		}
	}

	//change sprite when mouse hovers over region
	private void OnMouseEnter(){
		if(Enabled || Actionable)
			sprite.sprite=highlighted;
	}

	//change sprite when mouse leaves region
	private void OnMouseExit(){
		sprite.sprite=normal;
	}

	//Mouse click action
	private void OnMouseDown(){
		if(Enabled || Actionable){
			//change sprite
			sprite.sprite=pressed;
			AudioSource.PlayClipAtPoint(select,transform.position);
			Debug.Log("clicked");
			if(Enabled){
				Clicked=true;
				foreach(GameObject LinkedRegion in LinkedRegions){
					LinkedRegion.GetComponent<RegionScript>().Actionable=true;
				}
				if(manager.GetComponent<Manger>().player1Turn)
					Player1.SendMessage("PlayerEndEnable");
				else
					Player2.SendMessage("PlayerEndEnable");
			}
			else if(Actionable){
				Actioned=true;
				if(manager.GetComponent<Manger>().player1Turn){
					Player1.SendMessage("PlayerEndActionable");
				}
				else
					Player2.SendMessage("PlayerEndActionable");
				callCombat();
			}
		}

	}

	private void callCombat(){
			GameObject ClickedRegion=null;
			GameObject ActionedRegion=null;
			foreach(GameObject region in manager.GetComponent<Manger>().CompleteRegionList){
				if (region.GetComponent<RegionScript>().Clicked)
					ClickedRegion=region;
				if (region.GetComponent<RegionScript>().Actioned)
					ActionedRegion=region;
			}
			GameObject.Find("CombatManager").GetComponent<Fighting>().Fight(ClickedRegion,ActionedRegion);
			Debug.Log("after fight");
			manager.SendMessage("NextTurn");
		}

	private void OnMouseUp(){
		if(Enabled || Actionable)
			sprite.sprite=highlighted;
	}

	


	

}
