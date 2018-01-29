using UnityEngine;
using System.Collections;

public class RainControl : MonoBehaviour {

	void FixedUpdate () {

		if (transform.position.x >= 10)
			transform.position = new Vector3(10, transform.position.y, transform.position.z);

		if (transform.position.x <= -10)
			transform.position = new Vector3(-10, transform.position.y, transform.position.z);

		transform.Translate(Vector3.right * Input.GetAxis ("Horizontal"));

	}
}