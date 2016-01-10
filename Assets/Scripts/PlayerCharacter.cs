using UnityEngine;
using System.Collections;

public class PlayerCharacter : MonoBehaviour {
	
	public static int PlayerSpriteIndex;


	void OnTriggerEnter2D ( Collider2D other ){

		if (other.tag == "Characters") {

			PlayerSpriteIndex = other.GetComponent<SpriteIndex>().Index;
			PlayerPrefs.SetInt( "CurCharacterIndex" , PlayerSpriteIndex );
		}
	}
}