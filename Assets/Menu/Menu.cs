using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Menu : MonoBehaviour {
	public GameObject player;
	public GameObject settings;

	[System.Serializable]
	public class Position
	{
		public float x;
		public float y;
		public float z;
	}

	public void StartGame()
	{
		Application.LoadLevel (1);
		//GameObject.DontDestroyOnLoad (gameObject); //Переноска из одной сцены в другую.
	}

	public void Save()
	{
		Position position = new Position ();
		position.x = player.transform.position.x;
		position.y = player.transform.position.y;
		position.z = player.transform.position.z;

		if(!Directory.Exists(Application.dataPath + "/saves"))
			Directory.CreateDirectory(Application.dataPath +"/saves");
		FileStream fs = new FileStream(Application.dataPath + "/saves/save.sv", FileMode.Create);
		BinaryFormatter formatter = new BinaryFormatter();
		formatter.Serialize(fs, position);
		fs.Close();
	}

	public void LoadGame()
	{
		if (File.Exists (Application.dataPath + "/saves/save.sv")) 
		{
			FileStream fs = new FileStream(Application.dataPath + "/saves/save.sv", FileMode.Open);
			BinaryFormatter formatter = new BinaryFormatter();
			try
			{
				Position pos = (Position)formatter.Deserialize(fs);
				player.transform.position = new Vector3(pos.x, pos.y, pos.z);
			}
			catch (System.Exception e)
			{
				Debug.Log(e.Message);
			}
			finally
			{
				fs.Close();
			}
		}
		else
		{
			Application.Quit();
		}
	}

	public void Settings()
	{
		settings.SetActive (!settings.activeSelf);
	}

	public void ExitGame()
	{
		Application.Quit ();
	}

	public void setMusic(float value)
	{
		Global.music = value;
		//audio.Play ();
	}

	public void setSound(float value)
	{
		Global.sound = value;
	}
}
