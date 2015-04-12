using UnityEngine;
using System.Collections;

public class BodyPart : MonoBehaviour {

	//Health status for color display
	//3 for most healthy, 1 for least
	private int health;

	//List of Regions contained in this body part
	public GameObject[] RegionList;


	// Use this for initialization
	void Start () {
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
		if(BonusEnabled){
			for(int i=0;i<RegionList.Length;i++){
				RegionList[i].GetComponent<SpriteRenderer>().color=Color.yellow;
			}
			//Enable bonus here
		}
	}
}
