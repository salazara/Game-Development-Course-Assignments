using UnityEngine;
using System.Collections;

public class Summoner1 : MonoBehaviour {

	public GameObject A;
	public GameObject B;
	public GameObject C;

	public int numberOfMonsters;

	bool active;

	GameObject [] monsters;

	void Start () {

		active = false;
		monsters = new GameObject[]{A,B,C};

	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player" && active == false){ 
			Debug.Log ("Player triggers summoner");
			active = true;
			for (int i = 0; i < numberOfMonsters; i++){ 
				Invoke ("Summon", (i+1) * 2.5f);
			}
		}
	}

	// Update is called once per frame
	void Summon () {
		Debug.Log ("a monster has been summoned");
		Instantiate (monsters [Random.Range(0, 3)], transform.position, Quaternion.identity);
	}
}
