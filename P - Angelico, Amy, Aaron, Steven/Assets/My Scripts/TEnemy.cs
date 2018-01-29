using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TEnemy : MonoBehaviour {

	public GameObject deathParticles;
	Transform target;
	NavMeshAgent agent;

	public Material defaultMat;
	public Material hurtMat;
	public int memories;
	public int hp = 3;

	float hurtDelay;
	bool isHit;

	Renderer r;

	void Start () {

		target = GameObject.FindWithTag ("Player").transform;
		r = GetComponent<Renderer> ();
		agent = GetComponent<NavMeshAgent> ();
	}

	void Update () {

		agent.SetDestination (target.position);
		CheckHit ();
		CheckDead ();

	}

	void CheckDead(){
		if (hp <= 0) {
			GameObject p = GameObject.Find ("Player");
			Player pScript = p.GetComponent<Player> ();
			pScript.memories += 10;
			if(transform.parent != null)
				Destroy (transform.parent.gameObject);
			else 
				Destroy (transform.gameObject);
			Instantiate (deathParticles, transform.position, Quaternion.Euler(-90, 0, 0));
			if(gameObject.name == "Merchant")
				GM.instance.bossDefeated = true;
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

