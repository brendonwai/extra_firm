using UnityEngine;
using System.Collections;


public class EndTurnButton : MonoBehaviour {
	public GameObject Manger;
	bool p1Turn;
	bool p2Turn;
	private void OnMouseDown(){
		//change sprite
		Debug.Log ("#BEARJAM");
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		p1Turn = gameObject.GetComponent<Manger> ().player1Turn;
		p2Turn = gameObject.GetComponent<Manger> ().player2Turn;
	}
}
