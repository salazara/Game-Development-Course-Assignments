using UnityEngine;
using System.Collections;

public class FalltoDeath : MonoBehaviour {
	

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){ 
			Debug.Log ("Player fell to death");
			GM.instance.GameOver();
		}
	}
}

