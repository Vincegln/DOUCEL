using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

	public Button PlayButton;
	public Button ExitButton;

	// Use this for initialization
	private void Start()
	{
		PlayButton.onClick.AddListener(PlayHandleClick);
		ExitButton.onClick.AddListener(ExitHandleClick);
	}

	public void PlayHandleClick()
	{
		SceneManager.LoadScene("MainMap");
	}

	public void ExitHandleClick()
	{
		Application.Quit();
	}
}
