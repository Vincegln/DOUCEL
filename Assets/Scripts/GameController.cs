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
	private bool isDarkside;
	public Text TimerText;
	public Text PlaceText;
	public List<Image> ItemSlots;
	public List<Text> ItemNames;
	public int NbOfItems = 0;
	public Flowchart GhostFlowchart;
	public Material invertedSprite;
	public Material invertedStoryTextSprite;
	private bool _inGameMenu = false;
	private PlayerController _playerScript;
	private float _playerSpeed;
	public Button ExitButton;
	public Button ReturnButton;
	private bool _returnButtonClicked = false;
	public GameObject MenuPanel;
	public Flowchart JackFlowchart;
	private bool _gameStarted = false;
	public GameObject Jack;
	private Vector3 jackInitPosition;
	public float JackSpeed;
	private bool _jackGone;
	public float JackDistance;
	private bool _jackLeaving = false;
	public Animator moveJack;
	private bool _ending = false;
	public GameObject SayDialog;
	public GameObject MenuDialog;
	

	private void Start()
	{
		PlaceText.text = "Morgue";
		isDarkside = false;
		GhostFlowchart.SetBooleanVariable("isDarkside",false);
		ExitButton.onClick.AddListener(ExitHandleClick);
		ReturnButton.onClick.AddListener(ReturnHandleClick);
		_playerScript = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
		jackInitPosition = Jack.transform.position;
		invertedSprite.SetFloat("_INVERSION",0.0f);
		invertedStoryTextSprite.SetFloat("_INVERSION",1.0f);
	}

	// Update is called once per frame
	void Update ()
	{

		if (JackFlowchart.GetBooleanVariable("JackLeaving"))
		{
			_gameStarted = true;
		}
		
		if (_ending || JackFlowchart.GetBooleanVariable("Finished"))
		{
			SceneManager.LoadScene("Ending");
		}
		
		Debug.Log(_gameStarted);
		if (Input.GetKeyDown(KeyCode.Escape) || _returnButtonClicked)
		{
			if (!_inGameMenu)
			{
				SayDialog.SetActive(false);
				MenuDialog.SetActive(false);
				_playerSpeed = _playerScript.Speed;
				_playerScript.Speed = 0.0f;
				MenuPanel.SetActive(true);
			}
			else if (_inGameMenu)
			{
				MenuPanel.SetActive(false);
				_playerScript.Speed = _playerSpeed;
				_returnButtonClicked = false;
				SayDialog.SetActive(true);
				MenuDialog.SetActive(true);
			}
			_inGameMenu = !_inGameMenu ;
		}

		if (!_inGameMenu)
		{
			if (_gameStarted)
			{
				TimeElapsed += Time.deltaTime;
			}
			if (TimeElapsed > 86400 && !_ending)
			{
				Flowchart.BroadcastFungusMessage("Time's up");
				_ending = true;
				
			}
			_hoursText = (int) ((TimeElapsed*48) / 3600);
			_minutesText = (int) (TimeElapsed*48 - (_hoursText * 3600)) / 60;
			if (_hoursText + 13 > 23)
			{
				_hoursText -= 11;
			}
			else
			{
				_hoursText += 13;}
			TimerText.text = _hoursText + ":" + _minutesText.ToString("D2");
			if (isDarkside != GhostFlowchart.GetBooleanVariable("isDarkside"))
			{
				isDarkside = !isDarkside;
				invertedSprite.SetFloat("_INVERSION", !isDarkside ? 0.0f : 1.0f);
				invertedStoryTextSprite.SetFloat("_INVERSION", !isDarkside ? 1.0f : 0.0f);
			}

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