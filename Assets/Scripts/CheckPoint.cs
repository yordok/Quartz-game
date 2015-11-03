using UnityEngine;
using System.Collections;
//this scripts is used for setting the players chckpointnum value
//when hitting the collsion box of the object this script is attached to
public class CheckPoint : MonoBehaviour {

	GameObject Player;
	public int checkNum;
	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player") {
			//Sets the checkpointnum to the checkpoints checknum
			Player.GetComponent<PlayerValues> ().CheckpointNum = checkNum;
		}
	}

}
