using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Manger : MonoBehaviour {
	public GameObject player1;
	public GameObject player2;
	public GameObject[] CompleteRegionList;
	public bool player1Turn;
	public float elappsedTime;
	public bool player1Wins;
	public bool player2Wins;
	public Text turnText;
	
	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

	// Use this for initialization
	void Start () {
		player1=GameObject.Find("Player1");
		player2=GameObject.Find("Player2");
		turnText = turnText.GetComponent<Text> ();
		player1Turn = true;
		CompleteRegionList=GameObject.FindGameObjectsWithTag("region");
	}
	
	void startGame(){
		player1.SendMessage("PlayerAction");
	}

	// Update is called once per frame
	void Update () {
	

		if (player1Turn)
			turnText.text = "Player 1's Turn";
		else 
			turnText.text = "Player 2's Turn";

		elappsedTime = Time.time;
	}

	void NextTurn(){
		player1.SendMessage("updateRegionOwned");
		player2.SendMessage("updateRegionOwned");
		foreach (GameObject region in CompleteRegionList) {
			if (player1.GetComponent<Player>().RegionCount == 9)
			{
				Application.LoadLevel("player 1 wins");
			}
			if (player2.GetComponent<Player>().RegionCount == 9)
			{
				Application.LoadLevel("2Wins");
			}
		}

		foreach(GameObject region in CompleteRegionList){
			region.GetComponent<RegionScript>().Clicked=false;
			region.GetComponent<RegionScript>().Actioned=false;
		}
		player1Turn=!player1Turn;
		if (player1Turn)
			player1.SendMessage("PlayerAction");
		else
			player2.SendMessage("PlayerAction");
	}


}
