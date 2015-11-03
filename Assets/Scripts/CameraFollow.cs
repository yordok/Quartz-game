using UnityEngine;
using System.Collections;
//controls the camera
public class CameraFollow : MonoBehaviour {

	public GameObject target;
	public float height;
	public float distance;
	public int CameraPosNum;
	public float timeSlow;
	public Vector2 CameraMove;
	public bool hasControl;
	// Use this for initialization
	void Start () {
		hasControl = true;
		timeSlow = 0.0f;
		CameraPosNum = 1;
		CameraMove = new Vector2 (0, 0);
		transform.position = target.transform.position;
	}
	
	// Update is called once per frame
	//update holds the input manager
	//
	void Update () {

		CameraMove.x = 0;
		CameraMove.y = 0;
		//increments camera position
		if (Input.GetButtonDown("CameraRight")) {
			CameraPosNum++;
			timeSlow = Time.time;
		}

		//decrements the camera position
		if (Input.GetButtonDown("CameraLeft")) {
			CameraPosNum--;
			timeSlow = Time.time;
		}

		//resets the values
		if (CameraPosNum > 4) {
			CameraPosNum =1;
		}
		if (CameraPosNum < 1) {
			CameraPosNum =4;
		}

	}

	void LateUpdate() {


		if (Time.time < timeSlow + 0.25f) {
			Time.timeScale = 0.5f;
		}
		if (hasControl==true) {
			//moves the camera to position 1
			if (CameraPosNum == 1) {
				transform.position = Vector3.MoveTowards (transform.position, new Vector3 (target.transform.position.x + distance, target.transform.position.y + height, target.transform.position.z), 1);
				transform.LookAt (target.transform);
			}
			//if the stick is to the right then the camrea will move right
			if (CameraPosNum == 2) {
				transform.position = Vector3.MoveTowards (transform.position, new Vector3 (target.transform.position.x, target.transform.position.y + height, target.transform.position.z + distance), 1);
				transform.LookAt (target.transform);
			}
			if (CameraPosNum == 3) {
				transform.position = Vector3.MoveTowards (transform.position, new Vector3 (target.transform.position.x - distance, target.transform.position.y + height, target.transform.position.z), 1);
				transform.LookAt (target.transform);
			}
			//if the stuck is left then the camera will move left
			if (CameraPosNum == 4) {
				transform.position = Vector3.MoveTowards (transform.position, new Vector3 (target.transform.position.x, target.transform.position.y + height, target.transform.position.z - distance), 1);
				transform.LookAt (target.transform);
			}


			//deals with the y axis
			//if the stick is up then the camera will move downward so you can see far ahead of yourself
			if (CameraMove.y == -1) {
				transform.position = Vector3.MoveTowards (transform.position, new Vector3 (target.transform.position.x + distance, target.transform.position.y + 5, target.transform.position.z), 1);
				transform.LookAt (target.transform);
			}

		}

	

	}
}
