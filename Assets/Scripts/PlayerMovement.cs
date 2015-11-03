using UnityEngine;
using System.Collections;

//Player movement
public class PlayerMovement : MonoBehaviour {

	// Use this for initialization
	private Rigidbody RB;
	public float speed;
	public float jumpForce;
	public bool hasControl;
	private GameObject Cam;

	bool isGrounded;
	bool isWalking;
	bool isJumping;
	//public AudioClip roll;
	public AudioClip jump;
	//public AudioSource source1;
	//public AudioSource source2;
	void Start () {
		hasControl = true;
		isGrounded = false;
		RB = this.GetComponent<Rigidbody> ();
		isWalking = false;
		isJumping = false;
		//var asources = this.GetComponents<AudioSource> ();
		//source1 = asources [0];
		//source2 = asources [1];
	}
	
	// Update is called once per frame
	void Update () {
		Cam = GameObject.FindGameObjectWithTag ("MainCamera");
		int PositionNum = Cam.GetComponent<CameraFollow> ().CameraPosNum;
		//checks to see if the player is touching the gound
		//if so, augment the players torque
		//if not, add to the players force to make him contollable in the air
		Vector3 move = new Vector3();

		if (hasControl==true) {
			if (isGrounded) {
				//changes the axis based on the camera position
				if (PositionNum == 1) {
					move = new Vector3 (-Input.GetAxis ("XAXIS"), 0, Input.GetAxis ("YAXIS"));
					isWalking = true;
					isJumping = false;
				}
				if (PositionNum == 2) {
					move = new Vector3 (-Input.GetAxis ("YAXIS"), 0, -Input.GetAxis ("XAXIS"));
					isWalking = true;
					isJumping = false;
				}
				if (PositionNum == 3) {
					move = new Vector3 (Input.GetAxis ("XAXIS"), 0, -Input.GetAxis ("YAXIS"));
					isWalking = true;
					isJumping = false;
				}
				if (PositionNum == 4) {
					move = new Vector3 (Input.GetAxis ("YAXIS"), 0, Input.GetAxis ("XAXIS"));
					isWalking = true;
					isJumping = false;
				}
				//add the torque to the object
				RB.AddTorque (move * speed);
				//if the player is grounded and he presses the jump button, player jumps with y force
				if (Input.GetButtonDown ("Jump")) {
					RB.AddForce (new Vector3 (0, 1, 0) * jumpForce);
					//isWalking = false;
					//isJumping = true;
					GetComponent<AudioSource>().clip = jump;
					GetComponent<AudioSource>().Play();

				}
				isGrounded = false;
			} else {
				//changes the axis based on cammera position
				if (PositionNum == 1) {
					move = new Vector3 (-Input.GetAxis ("YAXIS"), 0, -Input.GetAxis ("XAXIS"));
					//isJumping = true;
				}
				if (PositionNum == 2) {
					move = new Vector3 (Input.GetAxis ("XAXIS"), 0, -Input.GetAxis ("YAXIS"));
					//isJumping = true;
				}
				if (PositionNum == 3) {
					move = new Vector3 (Input.GetAxis ("YAXIS"), 0, Input.GetAxis ("XAXIS"));
					//isJumping = true;
				}
				if (PositionNum == 4) {
					move = new Vector3 (-Input.GetAxis ("XAXIS"), 0, Input.GetAxis ("YAXIS"));
					//isJumping = true;
				}
				//adds the force to the player
				RB.AddForce (move * 15);
			}
		}
	}
	void FixedUpdate(){
		//increases the speed to 2.0f times than regualr speed
		Time.timeScale = 2.5f;
	}

	/*void playSounds(){
		if (isWalking == true && isJumping == false) {
			//GetComponent<AudioSource>().Play();
			source1.Play();
			source2.Stop();
		}
		if (isWalking == false && isJumping == true) {
			//GetComponent<AudioSource>().Play();
			source2.Play();
			source1.Stop();
		}
	}*/

	void OnCollisionStay(Collision collision)
	{
		//if it is touching th egrounded the players is grounded
		if (collision != null) {
			isGrounded = true;
		} else {
			isGrounded = false;
		}


	}
}
