using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {
	public float elappsedTime;
	public Text timeText;
	// Use this for initialization
	void Start () {
		timeText = timeText.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		string minuteStr, secondStr;
		elappsedTime = Time.time;
		int minutes = (int) Time.time/ 60;
		int seconds = (int) Time.time % 60;
		if (minutes < 10)
			minuteStr = "0" + minutes.ToString();
		else
			minuteStr = minutes.ToString();
		if (seconds < 10)
			secondStr = "0" + seconds.ToString ();
		else
			secondStr = seconds.ToString ();
		timeText.text = minuteStr + ":" + secondStr;
	}
}
