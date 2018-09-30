using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {
	public GameObject leveltext;
	public GameObject katsukibar;
	public GameObject ochakobar;
	public GameObject tenyabar;
	public GameObject shoutobar;
	public GameObject momobar;
	public GameObject empty;

	//public GameObject nextlevel;
	public static int tonext = 20;
	public static int now = 0;

	public static int randint(float num){
		int shinsou;
		shinsou = Mathf.FloorToInt (Random.Range (0f, num));
		while (shinsou == num) {
			shinsou = Mathf.FloorToInt (Random.Range (0f, num));
		}
		return shinsou;
	}

	public static float numchar = 0f;


	public static string assigncardswithout(int level, string namewithout){
		string returnvalue;
		returnvalue = assigncards (level);
		while (returnvalue == namewithout){
			returnvalue = assigncards (level);
		}
		return returnvalue;
	}


	public static string assigncards(int level){
		int allmight = randint (100);
		if (allmight == 0) {
			return "ALLMIGHT";
		} else if (allmight == 1) {
			return "AIZAWA";
		} else {
			if (level <= 1) {
				return "DEKU";
			} else {
				if (level <= 2) {
					numchar = 2f;
				} else if (level <= 4) {
					numchar = 3f;
				} else if (level <= 6) {
					numchar = 4f;
				} else if (level <= 8) {
					numchar = 5f;
				} else {
					numchar = 6f;
				}


				int rand = randint (numchar);

				if (rand == 0) {
					return "DEKU";
				} else if (rand == 1) {
					return "KATSUKI";
				} else if (rand == 2) {
					return "OCHAKO";
				} else if (rand == 3) {
					return "TENYA";
				} else if (rand == 4) {
					return "SHOUTO";
				} else if (rand == 5) {
					return "MOMO";
				} else {
					return null;
				}
			}
		}
	}
	private List<int> NUMNEEDED = new List<int> {0,20,40,40,50,50,60,70,80,90,100,100,100,100,100,100};

	void start (){
		//NUMNEEDED.Add (20);
		//Debug.Log (Level\);
	}
	/*
	 * num = score. reset every level up.
	 * NUMNEEDED[i] = num needed for every level i. reset every level.tonext.
	 * score = score appear on score screen.
	 * */
	void Levelup(int level){
		if (now >= NUMNEEDED[level]){
			now = 0;
			Gamebody.level += 1;
			tonext = NUMNEEDED [Gamebody.level];
		}
		if (level >= 2) {
			katsukibar.SetActive (true);
		}
		if (level >= 3) {
			ochakobar.SetActive (true);
		}
		if (level >= 5) {
			tenyabar.SetActive (true);
		}
		if (level >= 7) {
			shoutobar.SetActive (true);
		}
		if (level >= 9) {
			momobar.SetActive (true);
		}
	}

void Update(){
		if (Input.GetMouseButtonDown (0)) {
			//int score = Gamebody.score;
			Levelup (Gamebody.level);

			//nextlevel.GetComponent<TextMesh> ().text = "Next Level\n" + now + " / " + tonext;
			leveltext.GetComponent<TextMesh> ().text = "Level\n" + Gamebody.level;
		}
	}
}
/* Level 1 = deku. x 20
 * Level 2 = +Katsuki x 40
 * Level 3 = +Ochako x 40
 * Level 4 = x50
 * Lecel 5 = +Iida x 50
 * 6 x60
 * 7 = Todoroki x70
 * 8 x80
 * 9 = momo x 90
 * 10 = lest is 100.
 * 0-0.999: deku
 * 1-1.999:Katsuki
 * 2 ocha
 * 3 iida
 */
