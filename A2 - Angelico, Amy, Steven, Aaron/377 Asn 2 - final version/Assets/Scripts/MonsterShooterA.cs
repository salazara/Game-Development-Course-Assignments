using UnityEngine;
using System.Collections;

public class MonsterShooterA : MonoBehaviour {
	
	public GameObject muzzlePrefab;
	public GameObject monsterBallPrefab;
	
	float attackDelay;

	void Start(){
		attackDelay = Time.time + 1f;
	}

	void Update () {

		if(Time.time > attackDelay){
			attackDelay = Time.time + 8f;
			Instantiate (muzzlePrefab, new Vector3(transform.position.x, transform.position.y - 2f, transform.position.z), Quaternion.identity);
			Instantiate (monsterBallPrefab, new Vector3(transform.position.x, transform.position.y - 2f, transform.position.z), Quaternion.identity);
			GetComponent<AudioSource>().Play();
		}	
	}
}
