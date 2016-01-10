using UnityEngine;
using System.Collections;

public class MenuSlideControl : MonoBehaviour {
	Vector2 StartPos;
	int SwipeID = -1;
	float minMovement = 20.0f;
	private Vector2 Target;
	float PosX = 0 ;

	void Awake (){

		Target = this.transform.position;
		PosX = this.transform.position.x;
	}
	
	void Update ()
	{

		this.transform.position = Vector2.Lerp (this.transform.position, new Vector2( PosX , 0 ), Time.deltaTime * 10);

		foreach (var T in Input.touches) {
			var P = T.position;
			if (T.phase == TouchPhase.Began && SwipeID == -1) {
				SwipeID = T.fingerId;
				StartPos = P;
			} else if (T.fingerId == SwipeID) {
				var delta = P - StartPos;
				if (T.phase == TouchPhase.Moved && delta.magnitude > minMovement) {
					SwipeID = -1;
					if (Mathf.Abs (delta.x) > Mathf.Abs (delta.y)) {
						if (delta.x > 0) {
							
							//Debug.Log ("Swipe Right Found");
							//this.transform.Translate( new Vector2( 7 , 0 ));
							//Target = new Vector2( PosX + 7 , 0 );
							PosX += 7;
						} else {
							
							//Debug.Log ("Swipe Left Found");
							//this.transform.Translate( new Vector2( -7 , 0 ));
							//Target = new Vector2( PosX - 7 , 0 );
							PosX -= 7;
						}
					} 
					else {
						if (delta.y > 0) {
							
							//Debug.Log ("Swipe Up Found");
						} else {
							
							//Debug.Log ("Swipe Down Found");
						}
					}
				} else if (T.phase == TouchPhase.Canceled || T.phase == TouchPhase.Ended)
					SwipeID = -1;
			} 
		}
	}   
}