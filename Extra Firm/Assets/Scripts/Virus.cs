using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Virus : MonoBehaviour {

	public int owner;
	Color P1Color= new Color(255/255.0f,116/255.0f,116/255.0f);
	Color P2Color= new Color(88/255.0f,176/255.0f,249/255.0f);



	void Start () {

	}

	
	void SetOwner(int new_owner){
		owner=new_owner;
		SetColor();
	}

	private void SetColor(){
		switch(owner){
			case 1:
				GetComponent<SpriteRenderer>().color=P1Color;
				break;
			case 2:
				GetComponent<SpriteRenderer>().color=P2Color;
				break;
			default:
				GetComponent<SpriteRenderer>().color=Color.white;
				break;
		}
	}
 
}

