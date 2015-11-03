using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour {

	GameObject MainCamera;
	GameObject Player;
	public Vector3 CameraPos;
	public Vector3 LandingPos;
	public Vector3 LandingCameraPos;
	public bool cinematic;
	float t;
	public AudioClip boom;
	// Use this for initialization
	void Start () {
		cinematic = false;
		t = 0.0f;
		MainCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		Player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (cinematic == true) {
			if (Time.time >= t + 5) {
				Player.GetComponent<Rigidbody> ().AddForce (new Vector3 (0, 1, 0) * 100);
				GetComponent<AudioSource>().clip = boom;
				GetComponent<AudioSource>().Play();
			
			}
			if (Time.time >= t + 8.8) {

				Player.transform.position = LandingPos;
				MainCamera.transform.LookAt (Player.transform);
				MainCamera.transform.position = LandingCameraPos;
				Player.GetComponent<Rigidbody> ().AddForce (new Vector3 (0, -1, 0) * 100);
			}
			if (Time.time >= t + 9) {

				MainCamera.GetComponent<CameraFollow>().hasControl = true;
				Player.GetComponent<PlayerMovement>().hasControl = true;
				cinematic = false;
			}
		}
	}
	void OnTriggerEnter(Collider col) {
	
		if (col.gameObject.tag == "Player") {
			t = Time.time;
			cinematic = true;
			MainCamera.GetComponent<CameraFollow>().hasControl = false;
			Player.GetComponent<PlayerMovement>().hasControl = false;
			MainCamera.transform.position = CameraPos;
			MainCamera.transform.LookAt (Player.transform);
		}


	}
}
