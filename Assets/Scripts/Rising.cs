using UnityEngine;
using System.Collections;

public class Rising : MonoBehaviour {


	//There are 200 Gems in the scene
	//It needs to go up 20 to reach the top
	public Vector3 temp;
	public Vector3 sec;
	public Vector3 tre;
	public Vector3 final;
	private GameObject Player;
	private GameObject Pillar;
	public AudioClip rise;
	public AudioClip win;
	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
		Pillar = GameObject.FindGameObjectWithTag ("Stair");
		temp = new Vector3(transform.position.x, transform.position.y + 5.0f, transform.position.z);
		sec = new Vector3(transform.position.x, transform.position.y + 10.0f, transform.position.z);
		tre = new Vector3(transform.position.x, transform.position.y + 15.0f, transform.position.z);
		final = new Vector3(transform.position.x, transform.position.y + 20.0f, transform.position.z);
	}

	// Update is called once per frame
	void Update () {

		if (Player.GetComponent<PlayerValues> ().GemCount == 50) {
			transform.position = temp;
			GetComponent<AudioSource>().clip = rise;
			GetComponent<AudioSource>().Play();
		}
		if (Player.GetComponent<PlayerValues> ().GemCount == 100) {
			transform.position = sec;
			GetComponent<AudioSource>().clip = rise;
			GetComponent<AudioSource>().Play();
		}
		if (Player.GetComponent<PlayerValues> ().GemCount == 150) {
			transform.position = tre;
			GetComponent<AudioSource>().clip = rise;
			GetComponent<AudioSource>().Play();
		}
		if (Player.GetComponent<PlayerValues> ().GemCount == 200) {
			transform.position = final;
			GetComponent<AudioSource>().clip = win;
			GetComponent<AudioSource>().Play();
		}
	}
	
}
