using UnityEngine;
using System.Collections;

public class PlatformRotation : MonoBehaviour {
	
	public float rotSpeed;
	public char axis;
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (axis == 'x') {
			transform.Rotate (Vector3.right, Time.deltaTime * rotSpeed);
		}
		if (axis == 'y') {
			transform.Rotate (Vector3.up, Time.deltaTime * rotSpeed);
		}
		if (axis == 'z') {
			transform.Rotate (Vector3.forward, Time.deltaTime * rotSpeed);
		}
		}
}
