using UnityEngine;
using System.Collections;

public class MusicManagerScript : MonoBehaviour {

	public AudioClip Dubstep01;

	void Start (){


		DontDestroyOnLoad (gameObject);

	}

	void FixedUpdate(){

		GameObject[] Managers = GameObject.FindGameObjectsWithTag ("MusicManager");

		if (Managers.Length > 1) {

			for( int i = 0; i < 1 ; i++){

				if( Managers[i].gameObject != this.gameObject ){
					Destroy( Managers[i]);
				}
			}
		}
	}
}