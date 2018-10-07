using System;
using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;
using UnityEngine.Internal.Experimental.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	public float TimeElapsed = 0.0f;
	private int _hoursText;
	private int _minutesText;
	public Text TimerText;
	public Text PlaceText;
	public List<Image> ItemSlots;
	public List<Text> ItemNames;
	public int NbOfItems = 0;
	private bool _inGameMenu = false;
	private PlayerController _playerScript;
	private float _playerSpeed;
	public Button ExitButton;
	public Button ReturnButton;
	private bool _returnButtonClicked = false;
	public GameObject MenuPanel;
	public Flowchart JackFlowchart;
	

	private void Start()
	{
		ExitButton.onClick.AddListener(ExitHandleClick);
		ReturnButton.onClick.AddListener(ReturnHandleClick);
		_playerScript = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
	}

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Escape) || _returnButtonClicked)
		{
			if (!_inGameMenu)
			{
				_playerSpeed = _playerScript.Speed;
				_playerScript.Speed = 0.0f;
				MenuPanel.SetActive(true);
			}
			else if (_inGameMenu)
			{
				MenuPanel.SetActive(false);
				_playerScript.Speed = _playerSpeed;
				_returnButtonClicked = false;
			}
			_inGameMenu = !_inGameMenu ;
		}

		if (!_inGameMenu)
		{
			TimeElapsed += Time.deltaTime;
			if (TimeElapsed > 86400)
			{
				Flowchart.BroadcastFungusMessage("Time's up");
				while(!JackFlowchart.GetBooleanVariable("IsTimeUp"))
				{}
				SceneManager.LoadScene("Ending");
			}
			_hoursText = (int) ((TimeElapsed*72) / 3600);
			_minutesText = (int) (TimeElapsed*72 - (_hoursText * 3600)) / 60;
			if (_hoursText + 13 > 24)
			{
				_hoursText -= 11;
			}
			else
			{
				_hoursText += 13;}
			TimerText.text = _hoursText + ":" + _minutesText.ToString("D2");
		}
	}
	
	public void ExitHandleClick()
	{
		SceneManager.LoadScene("Menu");
	}
	
	private void ReturnHandleClick()
	{
		_returnButtonClicked = true;
	}
}