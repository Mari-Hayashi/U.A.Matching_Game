using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Major : MonoBehaviour {
	/*
	 * GameObject clickedobject() = returns game object that is clicked.
	 * if (Input.GetMouseButtonDown (0)){ use here }
	 * 
	 * void changescene( "scenename" ) = changescene.
	 * 
	 * string getlayer( gameobject ) = returns layer name of gameobject.
	 * make sure rigid body and collider is attached to the gameobject.
	 * 
	 * int randint(float) ... returns random integer 0 ~ num-1. 
	 * (if float = 5, it returns 0, 1, 2, 3 or 4)
	 */

	//============================================================================
	public static GameObject clickedobject(){
		Vector2 clicklocation= Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Collider2D collision2d = Physics2D.OverlapPoint(clicklocation);
		if (collision2d) {
			return collision2d.transform.gameObject;
		} else {
			return null;
		}
	}
	//============================================================================
	public static void changescene(string scenename){
		SceneManager.LoadScene (scenename);
	}
	//============================================================================
	public static string getlayer(GameObject obj){
		return LayerMask.LayerToName (obj.gameObject.layer);
	}
	//============================================================================
	public static int randint(float num){
		int shinsou;
		shinsou = Mathf.FloorToInt (Random.Range (0f, num));
		while (shinsou == num) {
			shinsou = Mathf.FloorToInt (Random.Range (0f, num));
		}
		return shinsou;
	}	
	//==============================

}