using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text ScoreText;
	public Text HighScore;

	public float scoreCount;
	public float HightScoreCount;

	public float pointsPerSecond;
	public bool scoreIncreasing;
	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey("HighScore")) {
			HightScoreCount = PlayerPrefs.GetFloat ("HighScore");
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (scoreIncreasing) {
			scoreCount += pointsPerSecond * Time.deltaTime;
		}
		if (scoreCount > HightScoreCount) {
			HightScoreCount = scoreCount;
			PlayerPrefs.SetFloat ("HighScore", HightScoreCount);
		}

		ScoreText.text = "Score: " + Mathf.Round(scoreCount);
		HighScore.text = "High Score: " + Mathf.Round(HightScoreCount);
		
	}

	public void AddScore(int points){
		scoreCount += points;
	}
}
