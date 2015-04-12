using UnityEngine;
using System.Collections;

public class BodyPart : MonoBehaviour {

	//Health status for color display
	//3 for most healthy, 1 for least
	private int health;
	public GameObject player1;
	public GameObject player2;

	//List of Regions contained in this body part
	public GameObject[] RegionList;
	public bool alreadyEnabled = false;


	// Use this for initialization
	void Start () {
		player1 = GameObject.Find ("Player1");
		player2 = GameObject.Find ("Player2");
		health=3;
	}
	
	// Update is called once per frame
	void Update () {
		bool BonusEnabled=true;
		int lastOwner=0;
		int OccupyCount=0;
		for(int i=0;i<RegionList.Length;i++){
			RegionScript rs= RegionList[i].GetComponent<RegionScript>();
			if(rs.owner==0)
				BonusEnabled=false;
			else{
				if(i==0){
					lastOwner=rs.owner;
				}else if (lastOwner!=rs.owner){
					BonusEnabled=false;
				}
				OccupyCount++;
			}	
			health=3-OccupyCount;
		}
		switch(health){
			case 3:
				GetComponent<SpriteRenderer>().color=Color.white;
				break;
			case 2:
				GetComponent<SpriteRenderer>().color=Color.yellow;
				break;
			case 1:
			default:
				GetComponent<SpriteRenderer>().color=Color.red;
				break;
		}
			if (BonusEnabled && alreadyEnabled == false && RegionList.Length>1) {
				alreadyEnabled = true;
				Debug.Log ("Increase");
				if (RegionList [0].GetComponent<RegionScript> ().owner == 1) {
					player1.SendMessage ("increaseMaxRoll");
				}
				if (RegionList [0].GetComponent<RegionScript> ().owner == 2) {
					player2.SendMessage ("increaseMaxRoll");
				}
			} else if (!BonusEnabled && alreadyEnabled == true) {
				alreadyEnabled = false;
				Debug.Log ("Decrease");
				if (RegionList [0].GetComponent<RegionScript> ().owner == 1) {
					player1.SendMessage ("decreaseMaxRoll");
				}
				if (RegionList [0].GetComponent<RegionScript> ().owner == 2) {
					player2.SendMessage ("decreaseMaxRoll");
				}
			}
		else{

			foreach(GameObject region in RegionList){
				region.GetComponent<SpriteRenderer>().color=Color.white;
			}
		}
	}
}
