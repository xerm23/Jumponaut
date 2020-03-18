using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraPoints : MonoBehaviour {
	public int pointstoGive;
	private AudioSource CoinSound;
	private ScoreManager theScoreManager;

	// Use this for initialization
	void Start () {
		theScoreManager = FindObjectOfType<ScoreManager> ();
		CoinSound = GameObject.Find ("CoinSound").GetComponent<AudioSource> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name == "Player") {
			theScoreManager.AddScore (pointstoGive);
		}
		Destroy (gameObject);

		//ako prebrzo pokupi
		if (CoinSound.isPlaying) {
			CoinSound.Stop();
			CoinSound.Play ();
		}
		else
			CoinSound.Play ();
	}
}
