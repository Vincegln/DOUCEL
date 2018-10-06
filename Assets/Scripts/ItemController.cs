using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Fungus;
using UnityEngine;

public class ItemController : MonoBehaviour
{

    private GameObject _go;
    private bool _isPlayerThere = false;
    
    private void LateUpdate()
    {
        if (Input.GetKey(KeyCode.F) && _isPlayerThere)
        {
            PlayerController playerscript = _go.GetComponent<PlayerController>();
            
            playerscript.Items.Add(this.transform.parent.gameObject);
            
            Flowchart.BroadcastFungusMessage("m");
            
            Debug.Log(playerscript.Items.Last().name + " picked up !");
            
            this.transform.parent.gameObject.SetActive(false);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           _go = other.gameObject;
            _isPlayerThere = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _go = null;
            _isPlayerThere = false;
        }
    }
}
