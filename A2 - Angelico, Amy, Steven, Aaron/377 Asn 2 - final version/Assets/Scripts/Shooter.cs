using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject muzzlePrefab;
	public GameObject bulletPrefab;

	private bool fireKeyPressed = false;
	
	void Update () {

		if (Input.GetButtonDown("Fire1"))
		{
			fireKeyPressed = true;
		}

		if(Input.GetKeyDown (KeyCode.Space) && fireKeyPressed == true){
			Instantiate (muzzlePrefab, new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), Quaternion.identity);
			Instantiate (bulletPrefab, new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), Quaternion.identity);
            GetComponent<AudioSource>().Play();
        }	
	}
}
