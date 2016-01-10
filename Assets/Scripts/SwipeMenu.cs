using UnityEngine;
using System.Collections;

public class SwipeMenu : MonoBehaviour {

	private float TargetPos;
	private float CurPos;
	public GameObject[] Characters;
	public int CurCharacter;

	void Start(){

		CurPos = this.transform.position.x;
		TargetPos = CurPos;
	}

	void Update (){

		//MoveTowards Target Pos

		transform.position = new Vector2(Mathf.Lerp(transform.position.x, TargetPos, Time.deltaTime * 10), 225.2427f);

		if (Input.GetKeyDown (KeyCode.RightArrow)) {


			if( CurCharacter < Characters.Length ){
				CurPos = this.transform.position.x;
				CurCharacter++;
				TargetPos = Characters[CurCharacter].transform.position.x;
			}
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {

			if( CurCharacter > 0 ){
				CurPos = this.transform.position.x;
				CurCharacter--;
				TargetPos = Characters[CurCharacter].transform.position.x;
			}
		}


		if (Input.touchCount>0 && Input.GetTouch(0).phase==TouchPhase.Ended) {
			Vector2 touchDelta = Input.GetTouch(0).deltaPosition;

			if (touchDelta.x>5) {
				//This was a flick to the left with magnitude of 5 or more
				CurPos = this.transform.position.x;
				TargetPos = CurPos + 300;
			}


			if (touchDelta.x<-5) {
				//This was a flick to the right with magnitude of 5 or more
				CurPos = this.transform.position.x;
				TargetPos = CurPos - 300;
			}
		}
	}
}
