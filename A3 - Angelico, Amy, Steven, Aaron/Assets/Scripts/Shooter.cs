using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour
{
	//public Rigidbody projectile;

	public GameObject wreckingBall;

	//public Transform shotPos;

	//public float shotForce = 10000f;

	public float moveSpeed = 1f;

	private GameObject wreckingBallClone;

	float h = 0f;
	float v = 0f;

	bool shot = false;
	bool res = false;

	float delay;

	void Start(){
		wreckingBallClone = Instantiate (wreckingBall, new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
	}

	void Update ()
	{
		h = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
		v = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

		transform.Translate(new Vector3(h, v, 0f));

		if (shot == false) 
			wreckingBallClone.transform.Find ("physics_samoflange").Translate (new Vector3 (-h, v, 0f));

		if(Input.GetButtonUp("Fire1") && shot == false)
		{
	
			//Rigidbody shot = Instantiate(projectile, shotPos.position, shotPos.rotation) as Rigidbody;
			//shot.AddForce(shotPos.forward * shotForce);

			shot = true;
			Rigidbody rb = wreckingBallClone.transform.Find ("physics_samoflange").GetComponent<Rigidbody>();

			rb.isKinematic = false;
			rb.AddForce(new Vector3(0, 0, -5000f));

		}

		Reset ();

	}

	void Reset()
	{
		if (shot == true) {
			if(res == false){
				res = true;
				delay = Time.time + 10f;
			}
			else{
				if(Time.time > delay){
					Application.LoadLevel(Application.loadedLevel);
				}
			}
		}
	}

}