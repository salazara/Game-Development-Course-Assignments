using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	
	public float ballInitialVelocity = 600f;

	private Rigidbody rb;
	private bool ballInPlay = false;
	
	void Awake () {
		
		rb = GetComponent<Rigidbody>();
		
	}
	
	void Update () 
	{
		if (Input.GetButtonDown("Fire1") && ballInPlay == false)
		{
			transform.parent = null;
			ballInPlay = true;
			rb.isKinematic = false;
			rb.AddForce(new Vector3(ballInitialVelocity, ballInitialVelocity, 0));
		}
	}
}