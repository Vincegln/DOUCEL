using System;
using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	public float TimeLeft = 1200.0f;
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
	

	private void Start()
	{
		PlaceText.text = "Morgue";
		isDarkside = false;
		GhostFlowchart.SetBooleanVariable("isDarkside",false);
	}

	// Update is called once per frame
	void Update ()
	{
		TimeLeft -= Time.deltaTime;
		_hoursText = (int) ((TimeLeft*72) / 3600);
		_minutesText = (int) (TimeLeft*72 - (_hoursText * 3600)) / 60;
		TimerText.text = _hoursText + ":" + _minutesText;
		if (isDarkside != GhostFlowchart.GetBooleanVariable("isDarkside"))
		{
			isDarkside = !isDarkside;
			invertedSprite.SetFloat("_INVERSION", !isDarkside ? 0.0f : 1.0f);
			invertedStoryTextSprite.SetFloat("_INVERSION", !isDarkside ? 1.0f : 0.0f);
		}
		
	}
}
