using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingController : MonoBehaviour
{

	public Flowchart endingFlowchart;
	public Material invertedSprite;
	public Material invertedStoryTextSprite;

	private void Start()
	{
		invertedSprite.SetFloat("_INVERSION",0.0f);
		invertedStoryTextSprite.SetFloat("_INVERSION",1.0f);
	}

	// Update is called once per frame
	void Update () {
		if (endingFlowchart.GetBooleanVariable("end"))
		{
			SceneManager.LoadScene("Menu");
		}
	}
}
