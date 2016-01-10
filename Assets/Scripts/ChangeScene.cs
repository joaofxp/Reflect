using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	public string LevelName;
	public int LevelNumber;
	public GameObject Foreground;
	public int StarsAmmount;
	public string LevelScoreSaved;
	public Image[] Stars;

	public void Awake (){

		StarsAmmount = PlayerPrefs.GetInt (LevelScoreSaved);
		for( int i = 0  ; i < StarsAmmount ; i++ ){
			if( StarsAmmount != 0 ){
				Stars[i].color = Color.white;
			}
		}
	}

	public void Change(){

		StartCoroutine ("Loadlevel");

	}

	public IEnumerator Loadlevel (){

		Foreground.GetComponent<Animator> ().SetTrigger ("ChangeScene");
		yield return new WaitForSeconds (.5f);
		Application.LoadLevel (LevelName);
	}
}