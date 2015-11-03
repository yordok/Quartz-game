using UnityEngine;
using System.Collections;

public class TouchReset : MonoBehaviour {
	GameObject Player;
	public AudioClip broken;
	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col){
		if (col.collider.tag == "Player") {
			GetComponent<AudioSource>().clip = broken;
			GetComponent<AudioSource>().Play();
			Player.GetComponent<PlayerReset>().ResetPlayer();
		}
	}
}
