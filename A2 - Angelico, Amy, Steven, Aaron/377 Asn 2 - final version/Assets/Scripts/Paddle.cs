using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
	
	public float paddleSpeed = 1f;
	
	private Vector3 playerPos = new Vector3 (0, -9.5f, 0);
	
	void Update () 
	{
		float xPos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);
		playerPos = new Vector3 (Mathf.Clamp (xPos, -8.45f, 8.45f), -9.5f, 0f);
		transform.position = playerPos;
	}
}