using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RegionScript : MonoBehaviour {

	//name of the region
	public string regionName;

	//array of regions linked to this region
	//add in regions through inspector
	public GameObject[] LinkedRegions;

	//player occupying the region
	//0 for neutral,  1~4 to specify player number
	public int owner;

	//amount of virus currently in the region
	public int population;

	//percentage counted towards the whole human body
	public int weight;

	//Object reference to the virus object
	public GameObject virus;

	//List to store virus objects
	private List<GameObject> VirusList;

	SpriteRenderer sprite;

	public Sprite normal;
	public Sprite highlighted;
	public Sprite pressed;



	// Use this for initialization
	void Start () {
		VirusList=new List<GameObject>();
		owner=0;
		population=0;
		sprite=GetComponent<SpriteRenderer>();
	}


	// Set owner and population
	// Destroys and Instantiates virus object according to 
	// owner and population status
	void Populate(int new_owner, int amount){
		if(population>0){
			ClearVirus();
		}
		owner=new_owner;
		population=amount;
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
		sprite.sprite=highlighted;
	}

	//change sprite when mouse leaves region
	private void OnMouseExit(){
		sprite.sprite=normal;
	}

	//Mouse click action
	private void OnMouseDown(){
		//change sprite
		sprite.sprite=pressed;
		Debug.Log("clicked");

		//Do something else with mouse click

		//testing mouse click instantiation
		Populate(1,5);


	}

	private void OnMouseUp(){
		sprite.sprite=highlighted;
	}

	


	

}
