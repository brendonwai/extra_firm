using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManagerScript : MonoBehaviour {
	public Canvas QuitMenu;
	public Canvas Rules;
	public Button startText;
	public Button rulesText;
	public Button quitText;

	void Start(){
		QuitMenu = QuitMenu.GetComponent<Canvas> ();
		Rules = Rules.GetComponent<Canvas> ();
		startText = startText.GetComponent<Button> ();
		rulesText = rulesText.GetComponent<Button> ();
		quitText = quitText.GetComponent<Button> ();
		QuitMenu.enabled = false;
		Rules.enabled = false;
	}

	public void RulesPress(){
		Rules.enabled = true;
		startText.enabled = false;
		rulesText.enabled = false;
		quitText.enabled = false;
	}

	public void QuitPress(){
		QuitMenu.enabled = true;
		startText.enabled = false;
		rulesText.enabled = false;
		quitText.enabled = false;
	}

	public void NoPress(){
		Rules.enabled = false;
		QuitMenu.enabled = false;
		startText.enabled = true;
		rulesText.enabled = true;
		quitText.enabled = true;
	}

	public void StartGame(){
		Application.LoadLevel ("Main");
	}

	public void QuitGame(){
		Application.Quit ();
	}
}
