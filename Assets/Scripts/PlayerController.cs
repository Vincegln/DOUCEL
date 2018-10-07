using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	public float Speed = 0.1f;
	public List<GameObject> Items;
	public Animator move;
	public List<Sprite> idle;
	private int direction;
	
	// Use this for initialization
	void Start ()
	{
		this.GetComponent<SpriteRenderer>().sprite = idle[3];
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			Vector3 position = this.transform.position;
			position.x-=Speed;
			this.transform.position = position;
			direction = 0;
			move.SetBool("RightMoving",false);
			move.SetBool("UpMoving",false);
			move.SetBool("DownMoving",false);
			move.SetBool("LeftMoving", true);
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			Vector3 position = this.transform.position;
			position.x+=Speed;
			this.transform.position = position;
			direction = 1;
			move.SetBool("LeftMoving",false);
			move.SetBool("UpMoving",false);
			move.SetBool("DownMoving",false);
			move.SetBool("RightMoving", true);
		}
		if (Input.GetKey(KeyCode.UpArrow))
		{
			Vector3 position = this.transform.position;
			position.y+=Speed;
			this.transform.position = position;
			direction = 2;
			move.SetBool("LeftMoving",false);
			move.SetBool("RightMoving",false);
			move.SetBool("DownMoving",false);
			move.SetBool("UpMoving", true);

		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			Vector3 position = this.transform.position;
			position.y-=Speed;
			this.transform.position = position;
			direction = 3;
			move.SetBool("LeftMoving",false);
			move.SetBool("RightMoving",false);
			move.SetBool("UpMoving",false);
			move.SetBool("DownMoving", true);
		}
		if (!Input.anyKey)
		{
			move.SetBool("LeftMoving",false);
			move.SetBool("RightMoving",false);
			move.SetBool("UpMoving",false);
			move.SetBool("DownMoving",false);
			this.GetComponent<SpriteRenderer>().sprite = idle[direction];
		}
	}
}
