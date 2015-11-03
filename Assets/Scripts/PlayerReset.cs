using UnityEngine;
using System.Collections;

public class PlayerReset : MonoBehaviour {

	// Use this for initialization
	GameObject[] Checkpoints;
	GameObject Player;
	void Start () {
		Checkpoints = GameObject.FindGameObjectsWithTag ("CheckPoint");
		Player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		int CP = Player.GetComponent<PlayerValues>().CheckpointNum;
		Debug.Log(CP);
		if (this.transform.position.y < 320 || Input.GetButton("Reset")) {
			foreach(GameObject g in Checkpoints)
			{

				if(g.GetComponent<CheckPoint>().checkNum == CP)
				{
					Player.transform.position = g.transform.position;
				}
			}

		}


	}

	public void ResetPlayer(){
		int CP = Player.GetComponent<PlayerValues>().CheckpointNum;
		foreach(GameObject g in Checkpoints)
		{
			
			if(g.GetComponent<CheckPoint>().checkNum == CP)
			{
				Player.transform.position = g.transform.position;
			}
		}

	}
}
