using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class BorderController : MonoBehaviour
{
	public GameObject NextBox;
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		GameObject go = other.gameObject;
		
		if (go.CompareTag("Player") && NextBox != null)
		{		
			Debug.Log("Collision detected");
		
			Vector3 newPosition = go.transform.position;
			
			switch (tag)
			{
				case "leftBorder":
					newPosition.x = NextBox.transform.Find("Camera").position.x + 15.31f;
					break;
				case "rightBorder":
					newPosition.x = NextBox.transform.Find("Camera").position.x - 15.31f;
					break;
				case "upperBorder":
					newPosition.y = NextBox.transform.Find("Camera").position.y - 11.3f;
					break;
				case "lowerBorder":
					newPosition.y = NextBox.transform.Find("Camera").position.y + 11.3f;
					break;
			}
			
			go.transform.position = newPosition;
			NextBox.SetActive(true);
			GameObject.FindWithTag("GameManager").GetComponent<GameController>().PlaceText.text = NextBox.name;
			this.transform.parent.gameObject.SetActive(false);
		}
	}
}
