using UnityEngine;
using System.Collections;
//shifting platform script for the shifting platforms
public class ShiftingPlatform : MonoBehaviour {

	public Vector3 direction;
	public float speed;
	public float distance;
	public float delay;
	private Vector3 startPoint;
	private Vector3 endPoint;
	private bool D;
	float t;
	//public AudioClip smash;
	// Use this for initialization
	void Start () {
		delay = Random.Range(3, 15);
		t = 0;
		D = true;
		//sets the start and ednpoints
		startPoint = new Vector3 (transform.position.x, transform.position.y, transform.position.z); 
		endPoint = new Vector3 (transform.position.x + (direction.x * distance), transform.position.y + (direction.y * distance), transform.position.z + (direction.z * distance));

	}
	
	// Update is called once per frame
	void Update () {

		//moves between the two points
		if (D == true) {
			transform.position = Vector3.MoveTowards(transform.position,endPoint,speed);
			//GetComponent<AudioSource>().clip = smash;
			//GetComponent<AudioSource>().Play();
		} else {
			transform.position = Vector3.MoveTowards (transform.position, startPoint, speed);
		}
		if (transform.position == endPoint) {
			//GetComponent<AudioSource>().clip = smash;
			//GetComponent<AudioSource>().Play();
			D =false;
			t = Time.time;
		}
		if (transform.position == startPoint) {	
			if(Time.time >= t + delay){
				D = true;
			}
		}

	}
}
