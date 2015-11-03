using UnityEngine;
using System.Collections;
//used to pickup gems and add them to playervalues
public class GemPickUp : MonoBehaviour {

	private GameObject Player;
	public AudioClip bling;

	void Start(){
		Player = GameObject.FindGameObjectWithTag ("Player");
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "Player") {
			//increments gem count by one
			Player.GetComponent<PlayerValues> ().GemCount++;
			GetComponent<AudioSource>().clip = bling;
			GetComponent<AudioSource>().Play();
			//destroys game object
			Destroy (gameObject, 0.5f);
		}
	}
}
