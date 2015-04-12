using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Manger : MonoBehaviour {
	public bool player1Turn;
	public bool player2Turn;
	public float elappsedTime;
	public bool player1Wins;
	public bool player2Wins;
	public Text turnText;

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

	// Use this for initialization
	void Start () {
		turnText = turnText.GetComponent<Text> ();
		player1Turn = true;
		player2Turn = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown (KeyCode.T)) {
			player1Turn = !player1Turn;
			player2Turn = !player2Turn;
			}

		if (player1Turn)
			turnText.text = "Player 1's Turn";
		else if (player2Turn)
			turnText.text = "Player 2's Turn";

		elappsedTime = Time.time;
	}
}
