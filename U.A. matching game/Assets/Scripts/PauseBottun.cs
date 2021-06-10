using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseBottun : MonoBehaviour {
	public Sprite buttononmouse;
	public Sprite buttonoffmouse;


	// Use this for initialization
	void Start () {
		GetComponent<SpriteRenderer> ().sprite = buttonoffmouse;
	}

	void OnMouseEnter() {
		GetComponent<SpriteRenderer> ().sprite = buttononmouse;
	}
	void OnMouseExit() {
		GetComponent<SpriteRenderer> ().sprite = buttonoffmouse;
	}
	/*void OnMouseDown(){
		GetComponent<AudioSource> ().PlayOneShot (soundbutton);
		if (Major.getlayer (this.gameObject) == "PAUSE") {
			p = true;
		}
		if (Major.getlayer (this.gameObject) == "START") {
			g = true;
		}
		if (Major.getlayer (this.gameObject) == "HOWTO") {
			h = true;
		}
		if (Major.getlayer (this.gameObject) == "TITLE") {
			t = true;
		}
	}*/
	// Update is called once per frame
	void Update () {
		
	}
}
