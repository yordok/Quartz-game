using UnityEngine;
using System.Collections;
//script for ice that breaks over time
public class BreakingIce : MonoBehaviour {

	// Use this for initialization
	private bool Collided;
	private float currentTime;
	public float interval;
	public Material DefaultMat;
	public Material Red;
	public Material Yellow;
	public Material Green;

	void Start () {
		Collided = false;
	}
	
	// Update is called once per frame
	void Update () {
		//if colliding 
		if (Collided) {
			//for each if statement, there is an interval that chenges what material is applied to the object
			//green yellow then red
			if(Time.time > currentTime && Time.time < currentTime + interval){
				this.GetComponent<Renderer>().material = Green;
			}
			if(Time.time > currentTime + interval && Time.time < currentTime + interval * 2){
				this.GetComponent<Renderer>().material = Yellow;
			}
			if(Time.time > currentTime + interval *2 && Time.time < currentTime + interval * 3){
				this.GetComponent<Renderer>().material = Red;
			}
			//here the renderer and the box collider are diabled making the platform disappear
			if(Time.time > currentTime + interval * 3 && Time.time < currentTime + interval * 4){
				this.GetComponent<Renderer>().enabled = false;
				this.GetComponent<MeshCollider>().enabled = false; 
			}

			// after a certain time, all values are reset
			if(Time.time > currentTime + interval * 10 ){
				this.GetComponent<Renderer>().material = DefaultMat;
				this.GetComponent<Renderer>().enabled = true;
				this.GetComponent<MeshCollider>().enabled = true;

				Collided = false;
			}


		}
	}
	// collision, collided = true;
	void OnCollisionStay(Collision collision)
	{

		if (Collided == false) {

			Collided = true;
			currentTime = Time.time;

		}

	}
}
