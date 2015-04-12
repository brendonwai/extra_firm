using UnityEngine;
using System.Collections;


public class DiceScript : MonoBehaviour {
	public int roll;
	public Sprite One;
	public Sprite Two;
	public Sprite Three;
	public Sprite Four;
	public Sprite Five;
	public Sprite Six; 
	SpriteRenderer sprite;
	// Use this for initialization
	void Start () {

		roll = Random.Range(1,7);
		sprite = GetComponent<SpriteRenderer> ();

	}
	public int roller()
	{
		roll =  Random.Range (1, 7);

		if (roll == 1) {
			sprite.sprite=One;
		}
		if (roll == 2) {
			sprite.sprite=Two;
		}
		if (roll == 3) {
			sprite.sprite=Three;
		}
		if (roll == 4) {
			sprite.sprite=Four;
		}
		if (roll == 5) {
			sprite.sprite=Five;
		}
		if (roll == 6) {
			sprite.sprite=Six;
		}

		return roll;
	}
	// Update is called once per frame
	void Update () {
		 
		if (Input.GetKeyDown (KeyCode.R)) {

			roller ();

		}


	}
}
