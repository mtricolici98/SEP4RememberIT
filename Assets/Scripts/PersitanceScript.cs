using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class PersitanceScript {

	public float score { get; set;}
	public int attempt { get; set;}

	public void Save(float Score){
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Open (Application.persistentDataPath + "/playerScore.dat", FileMode.OpenOrCreate);
		PlayerInfo info = new PlayerInfo ();
		info.score = Score;
		attempt += 1;
		info.attnumber = attempt;
		bf.Serialize (file, info);
		file.Close ();

	}


	public void Load(){
		if (File.Exists (Application.persistentDataPath + "/playerScore.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/playerScore.dat", FileMode.Open);
			PlayerInfo info = (PlayerInfo) bf.Deserialize (file);
			score = info.score;
			attempt = info.attnumber;
			file.Close ();
		} else {
			score = 0;
			attempt = 0;
		}
	
	}










}
[Serializable]
class PlayerInfo{
	public float score { get; set; }
	public int attnumber{get;set;}


}