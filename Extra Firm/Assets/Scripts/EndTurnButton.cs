using UnityEngine;
using System.Collections;


public class EndTurnButton : MonoBehaviour {
	public GameObject Manager;
	bool p1Turn;
	bool p2Turn;
	private void OnMouseDown(){
		Manager.GetComponent<Manger>().SendMessage("EndTurn");

		//change sprite
		Debug.Log ("#BEARJAM");
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
