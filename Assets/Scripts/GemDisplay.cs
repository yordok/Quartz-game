using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//this is used to display the gem count to the screen
public class GemDisplay : MonoBehaviour {
	private Text t;
	private GameObject Player;
	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
		 t = this.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		//sets the text value of gems to the players gem count
		t.text = "Gems: " + Player.GetComponent<PlayerValues> ().GemCount.ToString ();
	}
}
