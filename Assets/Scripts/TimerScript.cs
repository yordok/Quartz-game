using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//draws the time to the cereen
public class TimerScript : MonoBehaviour {
	private Text t;
	// Use this for initialization
	void Start () {
		t = this.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		t.text = Time.timeSinceLevelLoad.ToString ();
	}
}
