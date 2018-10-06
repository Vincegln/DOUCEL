using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{

    private GameObject _go;
    private bool _isPlayerThere = false;
    
    private void LateUpdate()
    {
        if (Input.GetKey(KeyCode.F) && _isPlayerThere)
        {
            PlayerController playerscript = _go.GetComponent<PlayerController>();
            GameController gameScript = GameObject.FindWithTag("GameManager").GetComponent<GameController>();
            
            playerscript.Items.Add(this.transform.parent.gameObject.GetComponent<SpriteRenderer>().sprite);

            Image itemSlot = gameScript.ItemSlots[gameScript.NbOfItems];
            itemSlot.sprite = this.transform.parent.gameObject.GetComponent<SpriteRenderer>().sprite;
            itemSlot.gameObject.SetActive(true);
            
            Text itemName = gameScript.ItemNames[gameScript.NbOfItems];
            itemName.text = this.transform.parent.gameObject.name;
            itemName.gameObject.SetActive(true);

            gameScript.NbOfItems++;
            Debug.Log(playerscript.Items.Last().name + " picked up !" + playerscript.Items.Count);
           
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
