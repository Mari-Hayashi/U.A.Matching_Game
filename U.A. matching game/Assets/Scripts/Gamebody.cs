using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamebody : MonoBehaviour {
	
	//==== TEXT ====
	public GameObject nextlevel;
	public GameObject gameover;
	public GameObject scoretext;

	public AudioClip cardflipsound;
	public AudioClip cardmatchsound;

	public GameObject card;
	public GameObject shade;

	//============================

	private string choosingcard;
	private string secondlayer;

	private GameObject card1;
	private GameObject card2;

	private float time;
	private float countdown;
	public static int level = 7;
	public static int score = 100;
	public static int scoreincrease;

	private bool starting;
	private bool choosing;
	private bool miss;
	private GameObject[] CARDS;

	GameObject c1;
	GameObject c2;

	void Start () {
		miss = false;
		miss = false;
		scoreincrease = 1;
		for (int i = 0; i < 4; ++i) {  // y
			for (int j = 0; j < 7; ++j) { // x
				GameObject obj;
				var pos = new Vector3 (-4.5f + 1.51f * j, 1f + 2f * i, 0f);
				//y = 1, 3, 5, 7
				// x = 0 + 1.5 + 1.5 + 1.5 +  ...
				obj = Instantiate (card,pos, Quaternion.identity);
			}
		}
		starting = true;
		choosing = true;
		level = 1;
		score = 0;
		Level.now = 0;
		Level.tonext = 20;

	}

	/*void OnCollisionEnter2D (Collision2D cubes){
		Debug.Log ("touch");
		if (Major.getlayer (cubes.gameObject) == "BOX") {
			Debug.Log ("www");
			if (GetComponent<Rigidbody2D> ().gravityScale == -1) {
				GetComponent<Rigidbody2D> ().gravityScale = 1;
			}
		}
	}*/
	/*void assigncard(GameObject obj){
		string cardtype;
		float color = Random.Range (0f, 2f);
		int shinsou = Mathf.FloorToInt (color);
		if (shinsou == 0){cardtype = "DEKU";} else {cardtype = "OCHAKO";}
		obj.layer = LayerMask.NameToLayer (cardtype);
	}*/

	bool iscard(GameObject obj){
		if (Major.getlayer (obj) == "DEKU" ||
		    Major.getlayer (obj) == "OCHAKO" ||
			Major.getlayer (obj) == "KATSUKI" ||
			Major.getlayer (obj) == "TENYA" ||
			Major.getlayer (obj) == "NODEKU" ||
			Major.getlayer (obj) == "NOCHAKO" ||
		Major.getlayer (obj) == "MOMO" ||
		Major.getlayer (obj) == "SHOUTO" ||
		Major.getlayer (obj) == "MAT" ||
		    Major.getlayer (obj) == "NONE") {
			return true;
		} else {
			return false;
		}
	}

	void makecards(){
		for (int j = 0; j < 7; ++j) { // x
			GameObject obj;
			var pos = new Vector3 (-4.5f + 1.5f * j, -5f, 0f);
			//y = 1, 3, 5, 7
			// x = 0 + 1.5 + 1.5 + 1.5 +  ...
			obj = Instantiate (card,pos, Quaternion.identity) as GameObject;
		}
	}

	void assignlayer(GameObject obj){
		string layername = Major.getlayer (obj);

		if (layername == "NONE") { //card not flipped yet
			obj.layer = LayerMask.NameToLayer (Level.assigncards (level));
		}
		if (layername == "NODEKU") {
			obj.layer = LayerMask.NameToLayer (Level.assigncardswithout (level, "DEKU"));
		}
		if (layername == "NOCHAKO") {
			obj.layer = LayerMask.NameToLayer (Level.assigncardswithout (level, "OCHAKO"));
		}
	}
void reset(){
		starting = true;
		choosing = true;
		card1 = null;
		card2 = null;
		time = 0;
}
	void destroycard(){
		Destroy (c1);
		Destroy (c2);
	}

	bool samecard(GameObject obj1, GameObject obj2){
		float x1 = obj1.transform.position.x;
		float y1 = obj1.transform.position.y;
		float x2 = obj2.transform.position.x;
		float y2 = obj2.transform.position.y;
		bool shinsou = false;
		if (x1 == x2 && y1 == y2){
			shinsou = true;
			}
		return shinsou;
	}
	void gameend(){
		gameover.SetActive (true);
		shade.SetActive (true);
		Kosei.canmove = false;
		time = 0;
	}

void scoreupdate(){
	nextlevel.GetComponent<TextMesh> ().text = "Next Level\n" + Level.now + " / " + Level.tonext;
	scoretext.GetComponent<TextMesh> ().text = "Score\n" + score;
}
public static bool scorechange = false;

	void Update () {
		if (scorechange) {
			scoreupdate ();
			scorechange = false;
		}
		time += Time.deltaTime;
		if (Kosei.canmove && !Kosei.iida) {
			countdown += Time.deltaTime;
		}
		if (Input.GetMouseButtonDown (0) && iscard (Major.clickedobject ()) && Kosei.canmove) {
			

			// ====================== first card ====================
			if (time >= 0.2 && starting) {
				time = 0;
				card1 = Major.clickedobject ();
				string layername = Major.getlayer (card1);
				assignlayer (card1);
				layername = Major.getlayer (card1);
				card1.GetComponent<Animator> ().SetInteger (layername, 1);
				GetComponent<AudioSource> ().PlayOneShot (cardflipsound);
				if (layername == "ALLMIGHT") {
					Kosei.allmighty = true;
					reset ();
					Invoke ("makecards", 3f);
				} else if (layername == "AIZAWA") {
					Kosei.eraser = true;
					Destroy (card1);
					reset ();
				} else {
					choosingcard = layername;
					starting = false;
				}
			}

			//  =====================   second card   ======================
			if (time >= 0.1 && choosing && !samecard (Major.clickedobject (), card1)) {
				time = 0;
				card2 = Major.clickedobject ();
				secondlayer = Major.getlayer (card2);
				assignlayer (card2);
				secondlayer = Major.getlayer (card2);
				card2.GetComponent<Animator> ().SetInteger (secondlayer, 1);
				GetComponent<AudioSource> ().PlayOneShot (cardflipsound);
				if (secondlayer == "ALLMIGHT") {
					Kosei.allmighty = true;
					Invoke ("makecards", 3f);
					reset ();
				} else if (secondlayer == "AIZAWA") {
					Kosei.eraser = true;
				card1.GetComponent<Animator> ().SetInteger (choosingcard, 2);
					Destroy (card2);
					reset ();
				} else {
					choosing = false;
				}
			}
		}
			//========================= after  ==================
			if (time >= 0.5 && !starting && !choosing) {
			if (secondlayer == "MAT" || choosingcard == "MAT") {
			card1.layer = LayerMask.NameToLayer ("DISAPPEAR");
			card2.layer = LayerMask.NameToLayer ("DISAPPEAR");
			card1.GetComponent<Animator> ().SetInteger (choosingcard, 3);
			card2.GetComponent<Animator> ().SetInteger (secondlayer, 3);
			c1 = card1;
			c2 = card2;
			score += scoreincrease * 2;
			Level.now += scoreincrease * 2;
				scorechange = true;
			time = 0;
			Invoke ("destroycard", 0.5f);
		} else if (secondlayer == choosingcard) {
				Kosei.count (card1);
				card1.layer = LayerMask.NameToLayer ("DISAPPEAR");
				card2.layer = LayerMask.NameToLayer ("DISAPPEAR");
				card1.GetComponent<Animator> ().SetInteger (choosingcard, 3);
				card2.GetComponent<Animator> ().SetInteger (secondlayer, 3);
				c1 = card1;
				c2 = card2;
				score += scoreincrease * 2;
				Level.now += scoreincrease * 2;
				scorechange = true;
				time = 0;
				Invoke ("destroycard", 0.5f);
						} else {
				card1.GetComponent<Animator> ().SetInteger (choosingcard, 2);
				card2.GetComponent<Animator> ().SetInteger (secondlayer, 2);
				time = 0;
							/*card2.GetComponent<Animator> ().SetBool (secondlayer, false);
							card1.GetComponent<Animator> ().SetBool ("Unmatched", true);
							card2.GetComponent<Animator> ().SetBool ("Unmatched", true);*/
						}
						starting = true;
						choosing = true;
					}

		if (countdown >= 8f) {
			CARDS = GameObject.FindGameObjectsWithTag ("CARD");
			
			foreach (GameObject card in CARDS){
				card.transform.position += new Vector3 (0f, 1.8f, 0f);
			if (card.transform.position.y >= 6.5f && Major.getlayer(card) != "OCHAKO") {
					miss = true;
				}
			}
		makecards ();
		countdown = 0;
			if (miss) {
				gameend ();
			}
		}
	if (Input.GetMouseButtonDown (0) && miss && time >= 1f) {
			Major.changescene ("title");
		}
	}//update
} // monobehavior