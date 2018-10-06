using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NpcController : MonoBehaviour {

	//private GameObject _go;
	private bool _isPlayerThere = false;
	
	private void LateUpdate()
	{
		if (Input.GetKeyDown(KeyCode.F) && _isPlayerThere)
		{
			Debug.Log("Are you talking to me, fam ?");
		}
	}
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			//_go = other.gameObject;
			_isPlayerThere = true;
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			//_go = null;
			_isPlayerThere = false;
		}
	}
}
