using UnityEngine;
using System.Collections;

public class LoadLevelSelection : MonoBehaviour {

	public string LevelName;
	public GameObject Foreground;

	public void CallLoadLevel(){

		StartCoroutine ("Loadlevel");
	}

	public IEnumerator Loadlevel (){
		
		Foreground.GetComponent<Animator> ().SetTrigger ("ChangeScene");
		//PlayerPrefs.Save ();
		yield return new WaitForSeconds (.5f);
		Application.LoadLevel (LevelName);
	}
}
