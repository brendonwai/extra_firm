using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndUI : MonoBehaviour {
	public Canvas endMenu;
	public Button endText;
	// Use this for initialization
	void Start () {
		endMenu = endMenu.GetComponent<Canvas> ();
		endText = endText.GetComponent<Button> ();
	}

	public void ReturnPress(){
		Application.LoadLevel ("menu_scene");
	}
}
