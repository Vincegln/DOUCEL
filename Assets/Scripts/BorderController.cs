using UnityEngine;

public class BorderController : MonoBehaviour
{
	public Camera OldCamera;
	public Camera NextCamera;
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log("Collision detected");
		OldCamera.gameObject.SetActive(false);
		NextCamera.gameObject.SetActive(true);
	}
}
