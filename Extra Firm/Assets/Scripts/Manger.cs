using UnityEngine;
using System.Collections;

public class Manger : MonoBehaviour {
	public bool player1Turn;
	public bool player2Turn;
	public float elappsedTime;
	public bool player1Wins;
	public bool player2Wins;

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}


	// Use this for initialization
	void Start () {
		player1Turn = true;
		player2Turn = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown (KeyCode.T)) {
			player1Turn = !player1Turn;
			player2Turn = !player2Turn;
			}

		elappsedTime = Time.time;
	}
}
