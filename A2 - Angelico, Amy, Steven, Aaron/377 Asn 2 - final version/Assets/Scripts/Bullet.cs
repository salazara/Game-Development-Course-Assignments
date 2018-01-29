using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	private Rigidbody rb;
	
	void Start () {

		rb = GetComponent<Rigidbody> ();
		rb.AddForce(new Vector3(0, 1000f, 0));
	
	}

	void OnCollisionEnter (Collision other)
	{
		Destroy(gameObject);
	}

}
