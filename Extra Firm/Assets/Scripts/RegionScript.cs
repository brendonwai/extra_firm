using UnityEngine;
using System.Collections;

public class RegionScript : MonoBehaviour {

	//name of the region
	public string regionName;

	//array of regions linked to this region
	//add in regions through inspector
	public GameObject[] LinkedRegions;

	//player occupying the region
	//0 for neutral,  1~4 to specify player number
	private int owner;

	//amount of virus currently in the region
	private int population;

	//percentage counted towards the whole human body
	public int weight;

	SpriteRenderer sprite;

	public Sprite normal;
	public Sprite highlighted;
	public Sprite pressed;



	// Use this for initialization
	void Start () {
		owner=0;
		population=0;
		sprite=GetComponent<SpriteRenderer>();
	}

	//Sets owner of region
	//See owner variable above for number representations
	void SetOwner(int new_owner){
		owner=new_owner;
	}

	//Gets owner of region
	//See owner variable above for number representations
	int GetOwner(){
		return owner;
	}

	//Sets population of region
	void SetPopulation(int new_population){
		population=new_population;
	}

	//Gets population of region
	int GetPopulation(){
		return population;
	}

	//change sprite when mouse hovers over region
	void OnMouseEnter(){
		sprite.sprite=highlighted;
	}

	//change sprite when mouse leaves region
	void OnMouseExit(){
		sprite.sprite=normal;
	}

	//Mouse click action
	void OnMouseDown(){
		//change sprite
		sprite.sprite=pressed;
		Debug.Log("clicked");

		//Do something else with mouse click

	}

	void OnMouseUp(){
		sprite.sprite=highlighted;
	}

	


	

}
