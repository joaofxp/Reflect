using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public int Lives;
	public Text LivesText;
	public GameObject ScoreUI;
	public Image[] Stars;
	public Transform MonetizationObj;
	public GameObject NextButton, ForeGround;
	public string LevelScoreToSave;
	public AudioClip[] StarFx;

	public int WallPoint;

	public int ScoreNeeded;
	int ScoreCurrent;


	void Awake(){

		ForeGround.SetActive (true);
	}

	void Update(){

//		if (Advertisement.IsReady()) { 
//			MonetizationObj.gameObject.SetActive (true);
//		}

		LivesText.text = Lives + " Lives";
	}

	public IEnumerator ShowScore(){

		ScoreUI.SetActive (true);
		ScoreCurrent = GameObject.Find ("Player").GetComponent<ProjectileDragging> ().ScoreCount;
		Debug.Log (ScoreCurrent);
//		PlayerPrefs.GetInt (LevelScoreToSave);
//		int CurScore = '3';
		//Show Current Stars;
//
//		for( int i = 0  ; i < SavedScore ; i++ ){
//			Stars[2].color = Color.white;
//		}
//

		bool ShowNextButton = false;
		if (ScoreCurrent >= ScoreNeeded * 0.50f ) {
			
			yield return new WaitForSeconds (1);
			GetComponent<AudioSource>().clip = StarFx[0];
			GetComponent<AudioSource>().Play();
			Stars[0].color = Color.white;
			ShowNextButton = true;
		}

		if (ScoreCurrent >= ScoreNeeded * 0.75f ) {

			yield return new WaitForSeconds (1);
			GetComponent<AudioSource>().clip = StarFx[1];
			GetComponent<AudioSource>().Play();
			Stars[1].color = Color.white;
		}

		if (ScoreCurrent >= ScoreNeeded) {

			yield return new WaitForSeconds (1);
			GetComponent<AudioSource>().clip = StarFx[2];
			GetComponent<AudioSource>().Play();
			Stars[2].color = Color.white;
		}
	
//		for( int i = ScoreCurrent  ; i < Lives ; i++ ){
//
//			yield return new WaitForSeconds (1);
//			GetComponent<AudioSource>().clip = StarFx[i];
//			GetComponent<AudioSource>().Play();
//			Stars[0].color = Color.white;
//		}

		if (ShowNextButton) {
			NextButton.SetActive(true);
			
		}

	}

	public void Retry (){

		Application.LoadLevel (Application.loadedLevel);
	}

//	public void Monetization (){
//
//		if (Advertisement.isReady ()) {
//
//			Advertisement.Show ("59059", new ShowOptions {
//				resultCallback = result => {
//					//Ad Callback function here
//					Currency.Coins += 10;
//					PlayerPrefs.SetInt("Coins", Currency.Points );
//					PlayerPrefs.Save();
//				}
//			});
//		}
//	}
}