using UnityEngine;
using System.Collections;

public class PlayerValues : MonoBehaviour {
	public int GemCount;
	public int CheckpointNum;
	// Use this for initialization
	void Start () {
		//What Checkpoint you have readched
		//is incremented when you hit a new checkpoint space
		CheckpointNum = 0;
		//how many gems you have collected
		GemCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
	}
}
