using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Fungus;
using UnityEngine;

public class NpcController : MonoBehaviour {

	public Flowchart Flowchart;
	
	private GameObject _go;
	private float _playerSpeed;
	
	private void LateUpdate()
	{
		if (_go != null)
		{
			if (Flowchart.GetBooleanVariable("Talking"))
			{
				_go.GetComponent<PlayerController>().Speed = 0.0f;
			}
			else
			{
				_go.GetComponent<PlayerController>().Speed = _playerSpeed;
			}
		}
	}
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			_go = other.gameObject;
			_playerSpeed = _go.GetComponent<PlayerController>().Speed;
			Flowchart.gameObject.SetActive(true);
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			_go = null;
			Flowchart.gameObject.SetActive(false);
		}
	}
}
