using UnityEngine;
using System.Collections;

public class Panel : MonoBehaviour {


	public GameObject panel1;
	public GameObject panel2;
	public Animator p1anim;
	public Animator p2anim;
	public Manger manager;

	// Use this for initialization
	void Start () {
		manager=GameObject.Find("Manager").GetComponent<Manger>();
		panel1.GetComponent<SpriteRenderer>().color=new Color(255/255.0f,116/255.0f,116/255.0f);
		panel2.GetComponent<SpriteRenderer>().color=new Color(88/255.0f,176/255.0f,249/255.0f);
		p1anim=panel1.GetComponent<Animator>();
		p2anim=panel2.GetComponent<Animator>();
		p1anim.SetBool("myTurn",false);
		p2anim.SetBool("myTurn",false);
	}

	
	// Update is called once per frame
	void Update () {
		if(manager.player1Turn){
			p1anim.SetBool("myTurn",true);
			p2anim.SetBool("myTurn",false);
		}else{
			p1anim.SetBool("myTurn",false);
			p2anim.SetBool("myTurn",true);
		}
	}
}


