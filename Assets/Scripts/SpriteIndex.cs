using UnityEngine;
using System.Collections;

public class SpriteIndex : MonoBehaviour {

	public int Index;
	public bool Avaiable;

	void Start (){

		if (Avaiable == true) {

			GetComponent<BoxCollider2D> ().enabled = true;
			GetComponent<SpriteRenderer> ().color = Color.white;
		} else {

			GetComponent<BoxCollider2D> ().enabled = false;
			GetComponent<SpriteRenderer> ().color = Color.black;
		}
	}
}