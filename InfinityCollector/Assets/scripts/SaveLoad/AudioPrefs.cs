using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class AudioPrefs : MonoBehaviour {

	public float volume;
	public Slider VolSlider;
	public bool muted;
	public Button sound;
    public bool mainmenu;

	void Start(){
        if (PlayerPrefs.GetFloat ("volume") != null) {
			volume = PlayerPrefs.GetFloat("volume");
			VolSlider.value = volume;
		}
		sound.GetComponent<Image>().color = Color.green;
	}

	void Update(){
        float initVolume = volume;


            if (AudioListener.volume != volume)
            {
                AudioListener.volume = volume;
                PlayerPrefs.SetFloat("volume", volume);
                if (mainmenu == true)
                {
                    float newVolume = initVolume / 2f;
                    AudioListener.volume = newVolume;
                }
        }else
        {
            if (mainmenu == true)
            {
                float newVolume = initVolume / 2f;
                AudioListener.volume = newVolume;
            }


        }





    }
    /// <summary>
    /// Volume Slider
    /// </summary>
	public void OnVolume(){
		volume = VolSlider.value;
	}

    /// <summary>
    /// On Mute
    /// </summary>
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
