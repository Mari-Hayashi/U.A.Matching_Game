using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseBottunControl : MonoBehaviour {
	public GameObject pausetext;
	public GameObject shade;
	public GameObject howto1;
	public GameObject howto2;
	public GameObject loading;

	public AudioClip soundbutton;

	public static bool pausing;
	public static float timefloat;
	public static bool how1;
	public static bool how2;

	public static bool nogame;


	void gamestart(){
		if (!nogame && timefloat > 0.1f) {
			loading.SetActive (true);
			Major.changescene ("main");
			timefloat = 0;
		}
	}
	void howto(){
		if (!nogame && timefloat > 0.1f) {
			howto1.SetActive (true);
			how1 = true;
			nogame = true;
			timefloat = 0;
			Kosei.canmove = false;
			shade.SetActive (true);
		}
	}
	void pause(){
		if (!nogame && timefloat > 0.1f){
			nogame = true;
			pausetext.SetActive (true);
			shade.SetActive (true);
			pausing = true;
			timefloat = 0;
			Kosei.canmove = false;
		}
	}
	void backtotitle(){
		if (!nogame && timefloat > 0.1f) {
			Major.changescene ("title");
			timefloat = 0;
		}
	}

	// Use this for initialization
	void Start () {
		pausing = false;
		nogame = false;
		how1 = false;
		how2 = false;
		timefloat = 0;
	}
	
	// Update is called once per frame
	void Update () {
		timefloat += Time.deltaTime;

		if (Input.GetMouseButtonDown (0)) {
			Debug.Log ("clicked");
			if (Major.clickedobject () != null) {
				if (Major.getlayer (Major.clickedobject ()) == "PAUSE") {
					GetComponent<AudioSource> ().PlayOneShot (soundbutton);
					pause ();
				}
				if (Major.getlayer (Major.clickedobject ()) == "START") {
					GetComponent<AudioSource> ().PlayOneShot (soundbutton);
					gamestart ();
				}
				if (Major.getlayer (Major.clickedobject ()) == "HOWTO") {
					GetComponent<AudioSource> ().PlayOneShot (soundbutton);
					howto ();
				}
				if (Major.getlayer (Major.clickedobject ()) == "TITLE") {
					GetComponent<AudioSource> ().PlayOneShot (soundbutton);
					backtotitle ();
				}
			}
		}


		if (Input.GetMouseButtonDown (0) && pausing && timefloat > 0.1f) {
			pausing = false;
			Kosei.canmove = true;
			pausetext.SetActive(false);
			shade.SetActive(false);
			nogame = false;
			timefloat = 0;
		}


		if (Input.GetMouseButtonDown (0) && how1 && timefloat > 0.1f) {
			GetComponent<AudioSource> ().PlayOneShot (soundbutton);
			howto1.SetActive (false);
			howto2.SetActive (true);
			how1 = false;
			how2 = true;
			timefloat = 0;
		}

		if (Input.GetMouseButtonDown (0) && how2 && timefloat > 0.1f) {
			GetComponent<AudioSource> ().PlayOneShot (soundbutton);
			howto2.SetActive (false);
			how2 = false;
			timefloat = 0;
			Kosei.canmove = true;
			nogame = false;
			shade.SetActive (false);
		}
	}
}
