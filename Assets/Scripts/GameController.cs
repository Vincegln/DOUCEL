using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	public float TimeLeft = 1200.0f;
	private int _hoursText;
	private int _minutesText;
	public Text TimerText;
	public Text PlaceText;
	public List<Image> ItemSlots;
	public List<Text> ItemNames;
	public int NbOfItems = 0;
	
	// Update is called once per frame
	void Update ()
	{
		TimeLeft -= Time.deltaTime;
		_hoursText = (int) ((TimeLeft*72) / 3600);
		_minutesText = (int) (TimeLeft*72 - (_hoursText * 3600)) / 60;
		TimerText.text = _hoursText + ":" + _minutesText;

	}
}
