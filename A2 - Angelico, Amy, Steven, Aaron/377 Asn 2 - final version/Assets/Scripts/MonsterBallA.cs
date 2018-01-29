using UnityEngine;
using System.Collections;

public class MonsterBallA : MonoBehaviour {
	
	private Rigidbody rb;
	public GameObject deathParticles;

	float delay;

	void Awake () {

		rb = GetComponent<Rigidbody>();

		int[] r = {-1, 1};
		rb.AddForce(new Vector3(100f * r[Random.Range (0, 2)], -600f, 0));

		delay = Time.time + 10f;
		
	}

	void Update(){

		if (Time.time > delay) {
			Instantiate (deathParticles);
			Destroy (gameObject);
		}
	}
	/*
	void OnCollisionEnter (Collision other)
	{  
		Instantiate(deathParticles, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
	*/

}