using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

	public Button PlayButton;
	public Button ExitButton;
	public Button CreditsButton;
	public Button ReturnButton;

	// Use this for initialization
	private void Start()
	{
		PlayButton.onClick.AddListener(PlayHandleClick);
		ExitButton.onClick.AddListener(ExitHandleClick);
		CreditsButton.onClick.AddListener(CreditsHandleClick);
		ReturnButton.onClick.AddListener(ReturnHandleClick);
	}

	public void PlayHandleClick()
	{
		SceneManager.LoadScene("MainMap");
	}

	public void ExitHandleClick()
	{
		Application.Quit();
	}
	
	private void CreditsHandleClick()
	{
		CreditsButton.transform.parent.gameObject.SetActive(false);
		ReturnButton.transform.parent.gameObject.SetActive(true);
	}
	
	private void ReturnHandleClick()
	{
		ReturnButton.transform.parent.gameObject.SetActive(false);
		CreditsButton.transform.parent.gameObject.SetActive(true);
	}
}
