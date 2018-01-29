using UnityEngine;
using System.Collections;

public class EnemyA : MonoBehaviour {

	public GameObject deathParticles;

	public Material defaultMat;
	public Material hurtMat;

	public int hp = 3;
	public int memories;

	float hurtDelay;
	bool isHit;

	Renderer r;
	
	void Start () {
		r = GetComponent<Renderer> ();
	}
	
	void Update () {
		CheckHit ();
		CheckDead ();
	}
	
	void CheckDead(){
		if (hp <= 0) {
			GameObject p = GameObject.Find ("Player");
			Player pScript = p.GetComponent<Player> ();
			pScript.memories += 10;
			Destroy (transform.parent.gameObject);
			Instantiate (deathParticles, transform.position, Quaternion.Euler(-90, 0, 0));
		}
	}
	
	void Hit(int n){
		Debug.Log (gameObject.name +" Hit");
		hp -= n;
		
		r.material = hurtMat;
		
		isHit = true;
		hurtDelay = Time.time + 0.1f;
		
	}
	
	void CheckHit(){
		
		if (isHit && Time.time > hurtDelay) {
			
			r.material = defaultMat;
			
			isHit = false;
		}
	}
}