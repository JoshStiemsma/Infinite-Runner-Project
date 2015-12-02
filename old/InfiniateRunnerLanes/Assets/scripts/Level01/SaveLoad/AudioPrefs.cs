using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class AudioPrefs : MonoBehaviour {

	public float volume;
	public Slider VolSlider;
	public bool muted;
	public Button sound;
	void Start(){
		if (PlayerPrefs.GetFloat ("volume") != null) {
			volume = PlayerPrefs.GetFloat("volume");
			VolSlider.value = volume;
		}
		sound.GetComponent<Image>().color = Color.green;
	}

	void Update(){
		if (AudioListener.volume != volume) {
			AudioListener.volume = volume;
			PlayerPrefs.SetFloat("volume", volume);
		}
	}

	public void OnVolume(){
		volume = VolSlider.value;
	}
	public void OnMute(){
		if (volume != 0) {
			sound.GetComponent<Image>().color = Color.red;
			volume = 0;
		} else {
			muted= false;
			sound.GetComponent<Image>().color = Color.green;
			volume = VolSlider.value;;
		}
	}
}
