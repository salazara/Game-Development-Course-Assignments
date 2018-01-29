using UnityEngine;
using System.Collections;

public class F_Particle_Coll : MonoBehaviour {

	private bool hurt = false;
	private float hurtDelay;

	public Material normalMat;
	public Material hurtMat;

	void OnParticleCollision(GameObject other) {

		hurt = true;
		hurtDelay = Time.time + 0.1f;

	}

	void Update () {

		if (hurt) {

			Renderer r = GetComponent<Renderer> ();
			r.material = hurtMat;


			if (Time.time > hurtDelay) {

				r = GetComponent<Renderer> ();
				r.material = normalMat;

				hurt = false;
			}
		}
		
	}


}
