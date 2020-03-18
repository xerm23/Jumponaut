using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour {

	public void Play(){
		SceneManager.LoadScene ("Jumponaut");
	}

	public void Aout(){
		SceneManager.LoadScene ("About");
	}
}
