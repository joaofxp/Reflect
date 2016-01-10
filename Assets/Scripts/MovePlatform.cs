using UnityEngine;
using System.Collections;

public class MovePlatform : MonoBehaviour {

	public float DistanceMin;
	public float DistanceMax;
	public float Speed;
	bool moveLeft = false;
	public bool shouldStop;

	void Update ()	{		

		if (transform.position.x > DistanceMax) {
			moveLeft = true;
			if (shouldStop) {
				GetComponent<movePlatformStop> ().TurnOffMove ();				
			}
		}

		if (transform.position.x < DistanceMin) {
			moveLeft = false;
			if (shouldStop) {
				GetComponent<movePlatformStop> ().TurnOffMove ();				
			}
		}

		if (moveLeft) {
			transform.Translate (Vector3.left * Time.deltaTime * Speed);		
		} else{
			transform.Translate (Vector3.right * Time.deltaTime * Speed);
		}
	}
}
