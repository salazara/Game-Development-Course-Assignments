using UnityEngine;
using System.Collections;

public class DaControl : MonoBehaviour {

	void FixedUpdate () {

		transform.Translate(Vector3.down * Input.GetAxis ("Vertical") * 0.5f);
		transform.Rotate(Vector3.left * Input.GetAxis ("Horizontal") * 3f);
	}
}
