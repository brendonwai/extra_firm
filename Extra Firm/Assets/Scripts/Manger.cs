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
		turnText = GetComponent<Text>();
		player1Turn = true;
		CompleteRegionList=GameObject.FindGameObjectsWithTag("region");
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
		player1Turn=!player1Turn;
		if (player1Turn)
			player1.SendMessage("PlayerAction");
		else
			player2.SendMessage("PlayerAction");
	}


}
