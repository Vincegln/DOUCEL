using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class BorderController : MonoBehaviour
{
	public GameObject NextBox;
	public bool IsDoorExt = false;
	public bool IsDoorInt = false;
	public bool IsDoorLeft = false;
	public bool IsDoorRight = false;
	public GameObject DoorCollider;
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		GameObject go = other.gameObject;
		
		if (go.CompareTag("Player") && NextBox != null)
		{		
			Debug.Log("Collision detected");
		
			Vector3 newPosition = go.transform.position;
			
			if (IsDoorInt)
			{
				newPosition = DoorCollider.transform.position;
				newPosition.y -= 3.0f;
			}
			else if (IsDoorExt)
			{
				newPosition = DoorCollider.transform.position;
				newPosition.y += 3.0f;
			} 
			else if (IsDoorLeft)
            			{
            				newPosition = DoorCollider.transform.position;
            				newPosition.x += 3.0f;
			            }
            			else if (IsDoorRight)
            			{
            				newPosition = DoorCollider.transform.position;
            				newPosition.x -= 3.0f;
            			}
			else
			{
				switch (tag)
				{
					case "leftBorder":
						newPosition.x = NextBox.transform.Find("Camera").position.x + 14.31f;
						break;
					case "rightBorder":
						newPosition.x = NextBox.transform.Find("Camera").position.x - 14.31f;
						break;
					case "upperBorder":
						newPosition.y = NextBox.transform.Find("Camera").position.y - 10.3f;
						break;
					case "lowerBorder":
						newPosition.y = NextBox.transform.Find("Camera").position.y + 10.3f;
						break;
				}
			}
			newPosition.z = go.transform.position.z;
			go.transform.position = newPosition;
			NextBox.SetActive(true);
			GameObject.FindWithTag("GameManager").GetComponent<GameController>().PlaceText.text = NextBox.name;
			this.transform.parent.gameObject.SetActive(false);
		}
	}
}
