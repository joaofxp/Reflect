using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Currency : MonoBehaviour {

	public static int Points;
	public static int Coins;
	public Text PointsText;

	void Start(){

		Points = PlayerPrefs.GetInt ("Points");
		Coins = PlayerPrefs.GetInt ("Coins");
	}

	void Update(){

		PointsText.text = Points + "";

		if (Input.GetKeyDown (KeyCode.D))
			PlayerPrefs.DeleteAll ();
	}
}