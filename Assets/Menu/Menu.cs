using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {
	public GameObject settings;
	public void StartGame()
	{
		Application.LoadLevel (1);
		//GameObject.DontDestroyOnLoad (gameObject); //Переноска из одной сцены в другую.
	}

	public void LoadGame()
	{

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
	}

	public void setSound(float value)
	{
		Global.music = value;
	}
}
