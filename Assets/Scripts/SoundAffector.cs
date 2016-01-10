using UnityEngine;
using System.Collections;

public class SoundAffector : MonoBehaviour {

    public GameObject MusicEffect, PlayerObj;
    private float amp;
    private float[] smooth = new float[2];
	public float Sensivity = 0.14f;
	private Vector2 StartScale;
     
    void Start()
    {

        // initalising the filter
        for (int i = 0; i < 2; i++) {
            smooth [i] = 0.0f;  
        }

    }
 
    // Update is called once per frame
    void Update () {

		PlayerObj = GameObject.Find ("Player");

		if (PlayerObj != null)
			PlayerObj.GetComponent<SpriteRenderer> ().color = new Color( 1, 1 ,1 , 1.2f - amp );
    }
 
    void OnAudioFilterRead (float[] data, int channels)
    {       
        for (var i = 0; i < data.Length; i = i + channels) {
            // the absolute value of every sample
            float absInput = Mathf.Abs(data[i]);
            // smoothening filter doing its thing
            smooth[0] = ((0.01f * absInput) + (0.99f * smooth[1]));
            // exaggerating the amplitude
            amp = smooth[0]*7;
            // it is a recursive filter, so it is doing its recursive thing
            smooth[1] = smooth[0];
        }
    }
}
