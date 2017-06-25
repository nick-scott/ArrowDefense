using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Stores and updates the players score
/// </summary>

public class ScoreText : MonoBehaviour {

	public Text textInstance;
	private int scoreLegnth = 4;
	private int score = 0;
	private int numOfZeros;
	private string newScore;

	public string ScoreString{
		get{return "Score: " + newScore;}
	}

	// Use this for initialization
	void Start () {
		textInstance = GetComponent<Text> ();
		//Test Add
		AddToScore (1);
	}
	
	// Update is called once per frame
	void Update () {
		textInstance.text = ScoreString;
	}

	//Adds int value to score
	public void AddToScore(int i){
		score += i;
		numOfZeros = scoreLegnth - score.ToString().Length;
		for(int j = 0; j < numOfZeros; j++){
			newScore += "0";
		}
		newScore += score.ToString ();
	}
}
