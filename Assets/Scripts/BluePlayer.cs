using UnityEngine;
using System.Collections;

public class BluePlayer : MonoBehaviour {
	public float maxStretch = 3.0f;
	public LineRenderer catapultLineFront;
	public LineRenderer catapultLineBack; 
	public AudioClip StringPull;
	public GameObject WinParticles;
	public AudioClip WinSoundFX;
	public GameObject CollisionEffect;
	public Sprite[] PlayerSprite;

	private SpringJoint2D spring;
	private Transform catapult;
	private Ray rayToMouse;
	private Ray leftCatapultToProjectile;
	private float maxStretchSqr;
	private float circleRadius;
	private bool clickedOn;
	private Vector2 prevVelocity;
	private GameObject LevelManagerObj;
	private Vector2 StartPos;

	
	void Awake () {
		spring = GetComponent <SpringJoint2D> ();
		StartPos = this.transform.position;
		LevelManagerObj = GameObject.Find ("LevelManager");
		catapult = spring.connectedBody.transform;
		GetComponent<SpriteRenderer> ().sprite = PlayerSprite[PlayerPrefs.GetInt ("CurCharacterIndex")];
		GetComponent<CircleCollider2D> ().radius = 6;
	}
	
	void Start () {
		LineRendererSetup ();
		rayToMouse = new Ray(catapult.position, Vector3.zero);
		leftCatapultToProjectile = new Ray(catapultLineFront.transform.position, Vector3.zero);
		maxStretchSqr = maxStretch * maxStretch;
		CircleCollider2D circle = GetComponent<Collider2D>() as CircleCollider2D;
		circleRadius = circle.radius;
	}
	
	void Update () {
		if (clickedOn) {
			Dragging ();
		}
		
		if (spring != null) {
			if (!GetComponent<Rigidbody2D>().isKinematic && prevVelocity.sqrMagnitude > GetComponent<Rigidbody2D>().velocity.sqrMagnitude) {
				Destroy (spring);
				GetComponent<Rigidbody2D>().velocity = prevVelocity;
			}
			
			if (!clickedOn)
				prevVelocity = GetComponent<Rigidbody2D>().velocity;
			
			LineRendererUpdate ();
			
		} else {
			catapultLineFront.enabled = false;
			catapultLineBack.enabled = false;
		}
	}
	
	void LineRendererSetup () {
		catapultLineFront.SetPosition(0, catapultLineFront.transform.position);
		catapultLineBack.SetPosition(0, catapultLineBack.transform.position);
		
		catapultLineFront.sortingLayerName = "Foreground";
		catapultLineBack.sortingLayerName = "Foreground";
		
		catapultLineFront.sortingOrder = 3;
		catapultLineBack.sortingOrder = 1;
	}
	
	void OnMouseDown () {
		if (clickedOn == false) {
			spring.enabled = false;
			clickedOn = true;
			GetComponent<AudioSource> ().clip = StringPull;
			GetComponent<AudioSource> ().Play ();
			GetComponent<CircleCollider2D> ().radius = 1.32f;
		}
	}
	
	void OnMouseUp () {
		spring.enabled = true;
		Instantiate(CollisionEffect, this.transform.position, Quaternion.identity );
		GetComponent<Rigidbody2D>().isKinematic = false;
		clickedOn = false;
	}

	void Dragging () {
		Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 catapultToMouse = mouseWorldPoint - catapult.position;
		
		if (catapultToMouse.sqrMagnitude > maxStretchSqr) {
			rayToMouse.direction = catapultToMouse;
			mouseWorldPoint = rayToMouse.GetPoint(maxStretch);
		}
		
		mouseWorldPoint.z = 0f;
		transform.position = mouseWorldPoint;
	}

	void LineRendererUpdate () {
		Vector2 catapultToProjectile = transform.position - catapultLineFront.transform.position;
		leftCatapultToProjectile.direction = catapultToProjectile;
		Vector3 holdPoint = leftCatapultToProjectile.GetPoint(catapultToProjectile.magnitude);
		catapultLineFront.SetPosition(1, holdPoint);
		catapultLineBack.SetPosition(1, holdPoint);
	}

	void OnTriggerEnter2D( Collider2D other ){
		if (other.tag == "Border" || other.tag == "Espinhos") {
			if( LevelManagerObj.GetComponent<LevelManager>().Lives > 1 ){
				//Reset the scene and reduce 1 life
				LevelManagerObj.GetComponent<LevelManager>().Lives--;
				transform.position = StartPos;
				GetComponent<Rigidbody2D>().isKinematic = true;
				spring = gameObject.AddComponent<SpringJoint2D>();
				spring.connectedBody = catapult.GetComponent<Rigidbody2D>();
				catapultLineBack.enabled = true;
				catapultLineFront.enabled = true;
				spring.distance = 0.5f;
				spring.frequency = 5;
			}else{
				//LooseScreen
				LevelManagerObj.GetComponent<LevelManager>().Lives--;
				LevelManagerObj.GetComponent<LevelManager>().StartCoroutine("ShowScore");
				Destroy( this.gameObject );

			}
		}
		if (other.tag == "Finish") {

			StartCoroutine("WinLevel");
		}
	}

	IEnumerator WinLevel (){

		GetComponent<Animator> ().SetTrigger ("Vanish");
		GetComponent<AudioSource> ().clip = WinSoundFX;
		GetComponent<AudioSource> ().Play ();
		GetComponent<CircleCollider2D> ().enabled = false;
		GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		yield return new WaitForSeconds (0.25f);
		Instantiate (WinParticles, this.transform.position, Quaternion.identity);
		yield return new WaitForSeconds( 2 );
		LevelManagerObj.GetComponent<LevelManager>().StartCoroutine ("ShowScore");
	}

	void OnCollisionEnter2D(Collision2D other ){
		
		if (other.gameObject.tag == "Wall") {
			
			Instantiate(CollisionEffect, this.transform.position, Quaternion.identity );
		}
	}
}