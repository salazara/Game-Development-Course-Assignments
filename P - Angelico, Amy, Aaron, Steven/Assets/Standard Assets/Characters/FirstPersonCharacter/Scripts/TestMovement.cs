using UnityEngine;
using System.Collections;

public class TestMovement : MonoBehaviour {

	float h = 0f;
	float z = 0f;
	public float moveSpeed = 10f;
	
	void Update () {
		h = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
		z = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
		
		transform.Translate(new Vector3(h, 0, z), Space.World);
	}
}
