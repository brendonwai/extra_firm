using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class numText : MonoBehaviour {

	public GameObject Region;
	Text displayText;
	// Use this for initialization
	void Start () {
		displayText=GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		displayText.text=Region.GetComponent<RegionScript>().population.ToString();
	}
}
