using UnityEngine;
using System.Collections;

public class movePlatformStop : MonoBehaviour {

	public float waitTime;

	public void TurnOffMove(){
		GetComponent<MovePlatform> ().enabled = false;	
		StartCoroutine (Reactivate ());
	}

	IEnumerator Reactivate(){
		yield return new WaitForSeconds(waitTime);
		GetComponent<MovePlatform> ().enabled = true;	
		yield return null;
	}

//	public float DistanceMin;
//	public float DistanceMax;
//	public float Speed;
//	public bool moveLeft; 
//	public float waitSeconds;
//
//	void Awake (){
//		moveLeft = false;
//	}
//
//	void Update ()	{		
//
//		if (transform.position.x > DistanceMax) { // pode ir para esquerda ao chegar no limite direito
//			ToTheLeft();
//		}
//		if (transform.position.x < DistanceMin) {// pode ir para direita ao chegar no limite esquerdo
//			ToTheRight();
//			Speed = 0f;
//		}
//
//		if (moveLeft) {
//			transform.Translate (Vector3.left * Time.deltaTime * Speed);		
//		} 
//		else {
//			transform.Translate (Vector3.right * Time.deltaTime * Speed);
//		}
//
//	}
//
//	void ToTheRight (){
//		Invoke("RightGo", waitSeconds);
//	}
//
//	void RightGo(){
//		moveLeft = false;
//		Speed = 50f;
//	}
//
//	void ToTheLeft(){
//		Invoke("LeftGo", waitSeconds);
//	}
//
//	void LeftGo(){
//		moveLeft = true;
//	}
}
