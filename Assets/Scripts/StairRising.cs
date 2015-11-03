using UnityEngine;
using System.Collections;

public class StairRising : MonoBehaviour {

	public Vector3 PositionA;
	private float height;
	private GameObject Player;
	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
		PositionA = new Vector3 (transform.position.x,transform.position.y - 20,transform.position.z);
		height = 0;



	}
	
	// Update is called once per frame
	void Update () {
		int count = Player.GetComponent<PlayerValues> ().GemCount;

		height = ((0.1f) * count);
		Debug.Log (height);

		transform.position = new Vector3 (PositionA.x, PositionA.y + height, PositionA.z);
	}
}
