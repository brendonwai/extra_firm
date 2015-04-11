using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Virus : MonoBehaviour {

	public float speed = 1.5f;
	private Vector3 target;
	public bool rest;
	public int vNum;
	public Text tVNum;
	
	void Start () {
		target = transform.position;
		vNum = 10;
		tVNum.text = "Virus Count: " + vNum.ToString ();
	}
	
	void Update () {
		if (Input.GetKeyDown ("space")) {
			rest = true;
		}
		if (rest == true)
		{
			vNum += 5;
			tVNum.text = "Virus Count: " + vNum.ToString ();
			rest = false;
			
		}
		if (Input.GetMouseButtonDown(0)) {
			transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
		
		}

	}    
}

