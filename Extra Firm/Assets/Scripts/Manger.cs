using UnityEngine;
using System.Collections;

public class Manger : MonoBehaviour {
	public bool player1;
	public bool player2;
	public float elappsedTime;
	// Use this for initialization
	void Start () {
		player1 = true;
		player2 = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown (KeyCode.T)) {
			player1 = !player1;
			player2 = !player2;
			}
		elappsedTime = Time.time;
	}
}
