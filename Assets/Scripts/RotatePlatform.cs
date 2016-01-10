using UnityEngine;
using System.Collections;

public class RotatePlatform : MonoBehaviour {

	public float RotateAmount;	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0,0,RotateAmount*Time.deltaTime);
	}
}
