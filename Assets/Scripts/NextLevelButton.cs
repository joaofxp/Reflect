using UnityEngine;
using System.Collections;

public class NextLevelButton : MonoBehaviour {

	public GameObject ForeGround;
	public string NextLevelName;

	public void CallLoadNextLevel(){
		StartCoroutine ("LoadNextLevel");
	}
	
	public IEnumerator LoadNextLevel(){
		
		ForeGround.GetComponent<Animator> ().SetTrigger ("ChangeScene");
		yield return new WaitForSeconds (.5f);
		Application.LoadLevel (NextLevelName);
	}
}
