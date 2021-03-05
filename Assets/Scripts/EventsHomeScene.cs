using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EventsHomeScene : MonoBehaviour {
	[SerializeField]
	Canvas aboutCanvas;
	[SerializeField]
	Canvas mainCanvas;
	
	[SerializeField]
	Button soundBtn;
	[SerializeField]
	Sprite soundOffImg;
	[SerializeField]
	Sprite soundOnImg;

	

	bool soundEnabled = true;
	string soundEnabledPrefKey = "SoundEnabled";
    private void Start()
    {
		soundEnabled = PlayerPrefs.GetInt(soundEnabledPrefKey) == 1 ? true : false ;
		if (soundEnabled) soundBtn.image.sprite = soundOnImg;
		else soundBtn.image.sprite = soundOffImg;
        
    }


    public void playClick(){
		SceneManager.LoadScene ("Jumponaut");
	}

	public void aboutClick(){
		aboutCanvas.gameObject.SetActive(true);
		mainCanvas.gameObject.SetActive(false);
	}

	public void soundClick()
    {
        if (soundEnabled)
        {
			PlayerPrefs.SetInt(soundEnabledPrefKey, 0);
			soundEnabled = false;
			soundBtn.image.sprite = soundOffImg;
        }
        else
		{
			PlayerPrefs.SetInt(soundEnabledPrefKey, 1);
			soundEnabled = true;
			soundBtn.image.sprite = soundOnImg;
		}
    }
}
