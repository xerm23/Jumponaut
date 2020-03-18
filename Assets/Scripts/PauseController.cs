using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseController : MonoBehaviour {
	public Text pauseBtntxt;
	public Button pausebtn;
	public Button resumebtn;

	public void PauseGame(){
		Time.timeScale = 0f;
		pausebtn.gameObject.SetActive (false);
		resumebtn.gameObject.SetActive (true);

	}

	public void ResumeGame(){
		Time.timeScale = 1f;
		pausebtn.gameObject.SetActive (true);
		resumebtn.gameObject.SetActive (false);
	}
}
