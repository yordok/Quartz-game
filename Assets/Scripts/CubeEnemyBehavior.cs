using UnityEngine;
using System.Collections;

public class CubeEnemyBehavior : MonoBehaviour {
	Vector3 startPos;
	bool upwards;
	// Use this for initialization
	void Start () {
		startPos = new Vector3(transform.position.x,transform.position.y + 10,transform.position.z);

		upwards = false;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (upwards);
		if (upwards == true) {
			float y = transform.position.y;
			Vector3 vec =transform.position;
			vec.y = y + 0.1f;
			transform.position = vec;

		}
		if (this.transform.position == startPos) {
			upwards = false;
		}
	}

	void OnCollisionEnter(Collision col)
	{
		upwards = true;
		if (col.collider.tag == "") {

		}
	}
}
