using UnityEngine;
using System.Collections;

public class DestroyAfterTime : MonoBehaviour {

	public float TimeUntilDelete;

	void Start(){

		Invoke ("Destroy", TimeUntilDelete);
	}

	void Destroy(){

		Destroy (this.gameObject);
	}
}
