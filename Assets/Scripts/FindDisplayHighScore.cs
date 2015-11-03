using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;
//this reads in the highscore file and writes to it based on the players scores
public class FindDisplayHighScore : MonoBehaviour {

	StreamWriter SW;
	StreamReader SR;
	GameObject Player;
	string message;
	float currentTime;
	// Use this for initialization
	void Start () {
		currentTime = 1000000000;
		message = "";
		Player = GameObject.FindGameObjectWithTag ("Player");
		//creates a new text document if it does not exist
		if(!File.Exists("HighScore.txt")){
			File.Create("HighScore.txt");
			SW = new StreamWriter ("HighScore.txt");
			//first line is 200000 represents the time
			SW.WriteLine(20000);
			//second line is 0 represents the gem count
			SW.WriteLine(0);
			SW.Close();
		}
		//reads and gets both values from the text file
		SR = new StreamReader ("HighScore.txt");
		float time = float.Parse(SR.ReadLine ());
		int gems = int.Parse(SR.ReadLine ());
		SR.Close ();
		//sets the GUI text to the initial values in the txt file
		string HighScoreText = "Best Gem Count:" + gems;
		GameObject.FindGameObjectWithTag ("GemHighScore").GetComponent<Text> ().text = HighScoreText;

		HighScoreText = "Best Time:" + time;
		GameObject.FindGameObjectWithTag ("TimeHighScore").GetComponent<Text> ().text = HighScoreText;
	}

	void Update()
	{
		//waits til 5 seconds after you hit the end goal, resets the level.
		//current time is set when OnTiggerEnter is called
		if (Time.timeSinceLevelLoad > currentTime + 5) {
			//resets the checpoint number to the first one
			Player.GetComponent<PlayerValues>().CheckpointNum = 0;
			//resets the win text to nothing
			GameObject.FindGameObjectWithTag ("Text").GetComponent<Text> ().text = "";
			//reloads the level
			Application.LoadLevel(0);
		}
	}
	void OnTriggerEnter(Collider col){
		//set current time for the update method
		currentTime = Time.timeSinceLevelLoad;
		Debug.Log ("Hit End Post");
		//open streamreader gets values
		SR = new StreamReader ("HighScore.txt");
		float time = float.Parse(SR.ReadLine ());
		int gems = int.Parse(SR.ReadLine ());

		SR.Close ();
		//
		SW = new StreamWriter ("HighScore.txt");
		//checks to see if you beat the time hgih score
		//if so write to file
		if (Time.timeSinceLevelLoad < time) {
			time = Time.timeSinceLevelLoad;
			message = message + "New Best Time! " + time + "   ";
		} 
		else 
		{
			message = message+ "Too Slow";
		}

		//checks to see if you beat gem high score
		//if so write to file
		if (Player.GetComponent<PlayerValues> ().GemCount > gems) {
			gems = Player.GetComponent<PlayerValues> ().GemCount;
			message = message + "New Best Gem Count! " + gems + "   ";
		}
		else
		{
			message = message + "Get More Gems";

		}
		//write to file
		SW.WriteLine(time);
		SW.WriteLine(gems);
		//display message
		GameObject.FindGameObjectWithTag ("Text").GetComponent<Text> ().text = message;
		SW.Close ();



	}
}
