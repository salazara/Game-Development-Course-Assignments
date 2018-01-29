using UnityEngine;
using System.Collections;

public class SpawnPlayer : MonoBehaviour {

	public GameObject player;

	void Awake () {
		Instantiate (player, transform.position, Quaternion.identity);
	}

}
