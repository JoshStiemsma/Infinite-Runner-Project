using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class PlayerData : MonoBehaviour {

	public static PlayerData playerData;

	public int levelReached;


	void Awake () {
		if (playerData == null) {
			DontDestroyOnLoad (gameObject);
			playerData = this;
		} else if(playerData!=this){
			Destroy(gameObject);
		}
	}
	void Enable(){
		//Save ();
	}


	public void Save(){
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

			levelReached = data.levelReached;
		}

	}





	[Serializable]
	class PlayerDataClass{
		public int levelReached;


	}




}
