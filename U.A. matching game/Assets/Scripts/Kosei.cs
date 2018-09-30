using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kosei : MonoBehaviour {
	static int deku = 0;
	static int ochako = 0;
	static int katsuki = 0;
	static int tenya = 0;
	static int shouto = 0;
	static int momo = 0;

	float timenow;

	public GameObject icatch;
	public GameObject shade;
	public GameObject background;
	public Sprite bgnomal;
	public Sprite bgdeku;
	public Sprite bgbakugou;
	public Sprite bgiida;
	public Sprite bguraraka;
	public Sprite bgshouto;
	public Sprite bgmomo;
	public Sprite bgall;
	public Sprite bgaizawa;

	public static bool allmighty = false;
	public static bool eraser = false;

	public GameObject dekubar;
	public Sprite deku0;
	public Sprite deku1;
	public Sprite deku2;
	public Sprite deku3;
	public Sprite deku4;
	public Sprite deku5;

	public GameObject katsukibar;
	public Sprite katsu0;
	public Sprite katsu1;
	public Sprite katsu2;
	public Sprite katsu3;
	public Sprite katsu4;
	public Sprite katsu5;

	public GameObject ochabar;
	public Sprite ocha0;
	public Sprite ocha1;
	public Sprite ocha2;
	public Sprite ocha3;
	public Sprite ocha4;
	public Sprite ocha5;

	public GameObject iidabar;
	public Sprite iida0;
	public Sprite iida1;
	public Sprite iida2;
	public Sprite iida3;
	public Sprite iida4;
	public Sprite iida5;

	public GameObject todobar;
	public Sprite todo0;
	public Sprite todo1;
	public Sprite todo2;
	public Sprite todo3;
	public Sprite todo4;
	public Sprite todo5;

	public GameObject momobar;
	public Sprite momo0;
	public Sprite momo1;
	public Sprite momo2;
	public Sprite momo3;
	public Sprite momo4;
	public Sprite momo5;

	public AudioClip soundexplosion;
	public AudioClip soundfloat;
	public AudioClip soundicatch;
	public AudioClip soundam;
	public AudioClip soundaizawa;
	public AudioClip soundice;
	public AudioClip soundfire;

	static bool change;

	public static bool canmove = true;


	public static void count(GameObject obj){
		string layer = Major.getlayer (obj);
		change = false;
		if (layer == "DEKU") {
			deku += 1;
		}
		if (layer == "KATSUKI") {
			katsuki += 1;
		}
		if (layer == "OCHAKO") {
			ochako += 1;
		}
		if (layer == "TENYA") {
			tenya += 1;
		}
		if (layer == "SHOUTO") {
			shouto += 1;
		}
		if (layer == "MOMO") {
			momo += 1;
		}
	}

	//==================  DEKU =======================
	float a;
	bool izuku = false; // true when activating

	void dekukosei(int num){
		if (num == 1) {
			canmove = true;
			a = timenow;
			izuku = true;
			Gamebody.scoreincrease = 3;
		} else {
			izuku = false;
			Gamebody.scoreincrease = 1;
			background.GetComponent<SpriteRenderer> ().sprite = bgnomal;
		}
	}




	// =====================KATSUKI======================
	public GameObject[] CARDS;
	public List<GameObject> dekulist = new List<GameObject> ();
	void bakukosei(){
		CARDS = GameObject.FindGameObjectsWithTag ("CARD");
		foreach (GameObject card in CARDS){
			if (Major.getlayer(card) == "DEKU"){
				dekulist.Add (card);
			} else if (Major.getlayer(card) == "NONE" || Major.getlayer(card) == "NOCHAKO"){
				if (Level.randint (Level.numchar) == 0) {
					dekulist.Add (card);
				} else {
					card.layer = LayerMask.NameToLayer ("NODEKU");
				}
			}
		}
		StartCoroutine ("dekuexplosion");
	}


	IEnumerator dekuexplosion(){
		foreach (GameObject deku in dekulist) {
			deku.GetComponent<Animator> ().SetInteger ("DEKU", 1);
		}
		yield return new WaitForSeconds (0.7f);
		foreach (GameObject deku in dekulist) {
			deku.GetComponent<Animator> ().SetInteger ("DEKU", 4);
		}
		GetComponent<AudioSource> ().PlayOneShot (soundexplosion);
			yield return new WaitForSeconds (0.6f);
		foreach (GameObject deku in dekulist) {
			Destroy (deku);
			Gamebody.score += 1;
		}
		dekulist.Clear ();
		canmove = true;
		background.GetComponent<SpriteRenderer> ().sprite = bgnomal;
	}


	//==========================OCHAKO=======================
	public List<GameObject> uralist = new List<GameObject> ();
	void ochakosei(){
	 CARDS = GameObject.FindGameObjectsWithTag ("CARD");
		foreach (GameObject card in CARDS) {
			if (Major.getlayer (card) == "OCHAKO") {
				uralist.Add (card);
			} else if (Major.getlayer (card) == "NONE" || Major.getlayer(card) == "NODEKU") {
				if (Level.randint (Level.numchar) == 0) {
					uralist.Add (card);
					card.layer = LayerMask.NameToLayer ("OCHAKO");
				} else {
					card.layer = LayerMask.NameToLayer ("NOCHAKO");
				}
			}
		}

		StartCoroutine ("urafloat");
	}

	IEnumerator urafloat(){
		foreach (GameObject ura in uralist) {
			ura.GetComponent<Animator> ().SetInteger ("OCHAKO", 1);
		}
		yield return new WaitForSeconds (0.7f);
		foreach (GameObject uraraka in uralist) {
			uraraka.GetComponent<BoxCollider2D> ().isTrigger = true;
			uraraka.GetComponent<Rigidbody2D> ().gravityScale = -1;
		}
		GetComponent<AudioSource> ().PlayOneShot (soundfloat);
		yield return new WaitForSeconds (1f);
		foreach (GameObject ura in uralist) {
			ura.GetComponent<Rigidbody2D> ().gravityScale = 1;
			ura.GetComponent<BoxCollider2D> ().isTrigger = false;
			ura.GetComponent<Animator> ().SetInteger ("OCHAKO", 2);
		}
		canmove = true;
		uralist.Clear ();
		background.GetComponent<SpriteRenderer> ().sprite = bgnomal;
	}
	//========================TENYA====================
    public static bool iida = false;
	float b = 1;
	void iidakosei(int num){
		if (num == 1) {
			canmove = true;
			background.GetComponent<SpriteRenderer> ().sprite = bgiida;
			iida = true;
			b = timenow;
		} else {
			iida = false;
			background.GetComponent<SpriteRenderer> ().sprite = bgnomal;
		}
	}
	//===================== TODOROKI ===================
	private List<GameObject> todolist = new List<GameObject> ();
	IEnumerator todotodo(){
		yield return new WaitForSeconds (0.7f);
		CARDS = GameObject.FindGameObjectsWithTag ("CARD");
		int todokosei = Major.randint (2);
		if (todokosei == 0) {
			ice ();
		} else {
			fire ();
		}
		yield return new WaitForSeconds (0.7f);
		foreach (GameObject obj in todolist) {
			Destroy (obj);
			Gamebody.score += 1;
			Level.now += 1;
			Gamebody.scorechange = true;
		}
		canmove = true;
		background.GetComponent<SpriteRenderer> ().sprite = bgnomal;
		todolist.Clear ();
	}

	void ice(){
		foreach (GameObject card in CARDS) {
			if (card.transform.position.x <= -1) {
				todolist.Add (card);
				card.GetComponent<Animator> ().SetBool ("Ice", true);
			}
		}
		GetComponent<AudioSource> ().PlayOneShot (soundice);
	}
	void fire(){
			foreach (GameObject card in CARDS) {
				if (card.transform.position.x >= 1) {
					todolist.Add (card);
					card.GetComponent<Animator> ().SetBool ("Fire", true);
				}
			}
		GetComponent<AudioSource> ().PlayOneShot (soundfire);
	}
	//========================= MOMO ==================
	private List<GameObject> yaolist = new List<GameObject> ();

	IEnumerator yaomomo(){
		yield return new WaitForSeconds (0.7f);
		CARDS = GameObject.FindGameObjectsWithTag ("CARD");
		foreach (GameObject card in CARDS) {
			if (card.transform.position.y <= -4.5) {
				yaolist.Add (card);
				card.GetComponent<Animator> ().SetBool ("Mat", true);
			}	
		}
		yield return new WaitForSeconds (0.7f);
		foreach (GameObject mat in yaolist) {
			mat.GetComponent<Animator> ().SetInteger ("MAT", 2);
			mat.layer = LayerMask.NameToLayer ("MAT");
		}
		yaolist.Clear ();
		canmove = true;
		background.GetComponent<SpriteRenderer> ().sprite = bgnomal;
	}
	//=======================ALL MIGHT =================
	void allmight(){
		icatchstart (10);
		StartCoroutine ("toshinori");
	}

	IEnumerator toshinori(){
		yield return new WaitForSeconds (0.7f);
		CARDS = GameObject.FindGameObjectsWithTag ("CARD");
		foreach (GameObject card in CARDS) {
			string layer;
			layer = Major.getlayer (card);
			if (layer == "NODEKU") {
				layer = "NONE";
			} else if (layer == "NOCHAKO") {
				layer = "NONE";
			}
			card.GetComponent<Animator> ().SetInteger (layer, 3);
		}
		GetComponent<AudioSource> ().PlayOneShot (soundam);
		yield return new WaitForSeconds (0.7f);
		foreach (GameObject card in CARDS) {
			Destroy (card);
			Gamebody.score += 1;
			Level.now += 1;
			Gamebody.scorechange = true;
		}
		canmove = true;
		background.GetComponent<SpriteRenderer> ().sprite = bgnomal;
	}
	//================= AIZAWA =========================
	IEnumerator shouta(){
		icatchstart (9);
		yield return new WaitForSeconds (0.7f);
		GetComponent<AudioSource> ().PlayOneShot (soundaizawa);
		deku = 0;
		ochako = 0;
		katsuki = 0;
		tenya = 0;
		shouto = 0;
		momo = 0;
		change = false;
		canmove = true;
		background.GetComponent<SpriteRenderer> ().sprite = bgnomal;
	}
	//============================================================

	void icatchend(){
		icatch.GetComponent<Animator> ().SetInteger ("CHAR", 0);
		shade.SetActive (false);
	}


	void icatchstart(int num){
		GetComponent<AudioSource> ().PlayOneShot (soundicatch);
		/* 1 = deku
		 * 2 = katsuki
		 * 3 = ochako
		 * 4 = iida
		 */
		canmove = false;
		shade.SetActive (true);
		icatch.GetComponent<Animator> ().SetInteger ("CHAR", num);
		Invoke ("icatchend", 0.7f);
	}


	void Start () {
		canmove = true;
		iida = false;
		deku = 0;
		ochako = 0;
		katsuki = 0;
		tenya = 0;
		shouto = 0;
		momo = 0;
		allmighty = false;
		eraser = false;
		timenow = 0;
		background.GetComponent<SpriteRenderer> ().sprite = bgnomal;
		izuku = false;
		change = false;
	}

	void Update () {
		
		if (canmove) {
			timenow += Time.deltaTime;
		}
		//==========================
		if (allmighty) {
			allmight ();
			allmighty = false;
			background.GetComponent<SpriteRenderer> ().sprite = bgall;
		}
		//==============================
		if (eraser) {
			StartCoroutine ("shouta");
			eraser = false;
			background.GetComponent<SpriteRenderer> ().sprite = bgaizawa;
		}
		// ========================
		if (deku >= 5){
			background.GetComponent<SpriteRenderer> ().sprite = bgdeku;
			icatchstart (1);
			dekukosei (1);
			deku = 0;
		}
		if (izuku && timenow - a >= 11f){
			dekukosei (2);
		}
		// ============================
		if (katsuki >= 5) {
			icatchstart (2);
			Invoke ("bakukosei", 0.7f);
			katsuki = 0;
			background.GetComponent<SpriteRenderer> ().sprite = bgbakugou;
		}
		//=======================
		if (ochako >= 5) {
			ochako = 0;
			icatchstart (3);
			Invoke("ochakosei", 0.7f);
			background.GetComponent<SpriteRenderer> ().sprite = bguraraka;
		}
		// ==============================
		if (tenya >= 5) {
			icatchstart (4);
			tenya = 0;
			iidakosei (1);
		}
		if (iida && timenow - b >= 11f) {
			iidakosei (0);
		}
		//==============================
		if (shouto >= 5) {
			icatchstart (5);
			StartCoroutine ("todotodo");
			shouto = 0;
			background.GetComponent<SpriteRenderer> ().sprite = bgshouto;
		}
		//================================
		if (momo >= 5) {
			icatchstart (6);
			StartCoroutine ("yaomomo");
			momo = 0;
			background.GetComponent<SpriteRenderer> ().sprite = bgmomo;
		}
		//==========================

		if (!change) {
			if (deku == 1) {dekubar.GetComponent<SpriteRenderer> ().sprite = deku1;
			} else if (deku == 2){dekubar.GetComponent<SpriteRenderer> ().sprite = deku2;
			} else if (deku == 3){dekubar.GetComponent<SpriteRenderer> ().sprite = deku3;
			} else if (deku == 4){dekubar.GetComponent<SpriteRenderer> ().sprite = deku4;
			} else if (deku == 5){dekubar.GetComponent<SpriteRenderer> ().sprite = deku5;
			} else if (deku == 0){dekubar.GetComponent<SpriteRenderer> ().sprite = deku0;
			}
			if (katsuki == 1) {katsukibar.GetComponent<SpriteRenderer> ().sprite = katsu1;
			} else if (katsuki == 2){katsukibar.GetComponent<SpriteRenderer> ().sprite = katsu2;
			} else if (katsuki == 3){katsukibar.GetComponent<SpriteRenderer> ().sprite = katsu3;
			} else if (katsuki == 4){katsukibar.GetComponent<SpriteRenderer> ().sprite = katsu4;
			} else if (katsuki == 5){katsukibar.GetComponent<SpriteRenderer> ().sprite = katsu5;
			} else if (katsuki == 0){katsukibar.GetComponent<SpriteRenderer> ().sprite = katsu0;
			}
			if (ochako == 1) {ochabar.GetComponent<SpriteRenderer> ().sprite = ocha1;
			} else if (ochako == 2){ochabar.GetComponent<SpriteRenderer> ().sprite = ocha2;
			} else if (ochako == 3){ochabar.GetComponent<SpriteRenderer> ().sprite = ocha3;
			} else if (ochako == 4){ochabar.GetComponent<SpriteRenderer> ().sprite = ocha4;
			} else if (ochako == 5){ochabar.GetComponent<SpriteRenderer> ().sprite = ocha5;
			} else if (ochako == 0){ochabar.GetComponent<SpriteRenderer> ().sprite = ocha0;
			}
			if (tenya == 1) {iidabar.GetComponent<SpriteRenderer> ().sprite = iida1;
			} else if (tenya == 2){iidabar.GetComponent<SpriteRenderer> ().sprite = iida2;
			} else if (tenya == 3){iidabar.GetComponent<SpriteRenderer> ().sprite = iida3;
			} else if (tenya == 4){iidabar.GetComponent<SpriteRenderer> ().sprite = iida4;
			} else if (tenya == 5){iidabar.GetComponent<SpriteRenderer> ().sprite = iida5;
			} else if (tenya == 0){iidabar.GetComponent<SpriteRenderer> ().sprite = iida0;
			}
			if (shouto == 1) {todobar.GetComponent<SpriteRenderer> ().sprite = todo1;
			} else if (shouto == 2){todobar.GetComponent<SpriteRenderer> ().sprite = todo2;
			} else if (shouto == 3){todobar.GetComponent<SpriteRenderer> ().sprite = todo3;
			} else if (shouto == 4){todobar.GetComponent<SpriteRenderer> ().sprite = todo4;
			} else if (shouto== 5){todobar.GetComponent<SpriteRenderer> ().sprite = todo5;
			} else if (shouto == 0){todobar.GetComponent<SpriteRenderer> ().sprite = todo0;
			}
			if (momo == 1) {momobar.GetComponent<SpriteRenderer> ().sprite = momo1;
			} else if (momo == 2){momobar.GetComponent<SpriteRenderer> ().sprite = momo2;
			} else if (momo == 3){momobar.GetComponent<SpriteRenderer> ().sprite = momo3;
			} else if (momo == 4){momobar.GetComponent<SpriteRenderer> ().sprite = momo4;
			} else if (momo == 5){momobar.GetComponent<SpriteRenderer> ().sprite = momo5;
			} else if (momo == 0){momobar.GetComponent<SpriteRenderer> ().sprite = momo0;
			}

				
			change = true;
		}
	} //update
}
// dekukosei(1) = increase score.
// dekukosei (2) = stop increasing score.
