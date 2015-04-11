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
		int OccupyCount=0;
		for(int i=0;i<RegionList.Length;i++){
			RegionScript rs= RegionList[i].GetComponent<RegionScript>();
			if(rs.owner!=0)
				OccupyCount++;
			health=3-OccupyCount;
		}
		switch(health){
			case 3:
				GetComponent<SpriteRenderer>().color=Color.green;
				break;
			case 2:
				GetComponent<SpriteRenderer>().color=Color.yellow;
				break;
			case 1:
			default:
				GetComponent<SpriteRenderer>().color=Color.red;
				break;
		}
	}
}
