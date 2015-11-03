using UnityEngine;
using System.Collections;

public class Bumper : MonoBehaviour {
	
	float bumperForce;
	GameObject Player;
	int numBounces;
	Vector3 reflection;
	public AudioClip boing;
	//var rb;
	
	
	// Use this for initialization
	void Start () {
		bumperForce = 10;
		Player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter(Collision coll) {
		var rb = Player.GetComponent<Rigidbody>();
		rb.AddForce (-1 * coll.contacts [0].normal * bumperForce, ForceMode.Impulse);
		GetComponent<AudioSource>().clip = boing;
		GetComponent<AudioSource>().Play();
		
	}
}
