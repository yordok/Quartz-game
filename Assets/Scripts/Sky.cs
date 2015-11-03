using UnityEngine;
using System.Collections;

public class Sky : MonoBehaviour {

	public float rotationSpeed;

	// Use this for initialization
	void Start () {
		rotationSpeed = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		// Slowly rotate the object around its X axis at 1 degree/second.
		//transform.Rotate(Vector3.right * Time.deltaTime);
		
		// ... at the same time as spinning relative to the global 
		// Y axis at the same speed.
		//transform.Rotate(Vector3.up * Time.deltaTime, Space.World);

		//Like a globe?
		//transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);

		//transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

		//transform.RotateAroundLocal(Vector3.forward, Time.deltaTime * rotationSpeed);

		transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime); //y
		//transform.Translate(Vector3.right * Time.deltaTime, Space.Self); //x
		//transform.Translate(Vector3.forward * Time.deltaTime, Space.Self); //z
	}
}
