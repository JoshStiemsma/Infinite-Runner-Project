using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class PlayerData : MonoBehaviour {

	public static PlayerData playerData;

	public int levelReached;

	public bool SetLevelAt;
	public int chosenLevel;


	void Awake () {
		if (playerData == null) {
			DontDestroyOnLoad (gameObject);
			playerData = this;
		} else if(playerData!=this){
			Destroy(gameObject);
		}
		//Load ();
	}
	void Enable(){
	
	}


	public void Save(){
		Debug.Log ("Saved Game");
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/playerInfo.dat");
		PlayerDataClass data = new PlayerDataClass();
		data.levelReached = levelReached;
		bf.Serialize (file, data);
		file.Close ();

	}

	public void Load()
	{
		if (File.Exists (Application.persistentDataPath + "/playerInfo.dat")) {
	
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			PlayerDataClass data = (PlayerDataClass)bf.Deserialize (file);
			file.Close();
			if(SetLevelAt==false){
			levelReached = data.levelReached;
			}else{
				levelReached = chosenLevel;

			}
			Debug.Log ("Loaded Game to " + levelReached);
		}

	}





	[Serializable]
	class PlayerDataClass{
		public int levelReached;


	}




}
