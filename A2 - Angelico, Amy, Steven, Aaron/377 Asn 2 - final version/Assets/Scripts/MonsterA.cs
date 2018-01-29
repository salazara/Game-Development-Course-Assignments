using UnityEngine;
using System.Collections;

public class MonsterA : MonoBehaviour {

	private float monsterSpeed = 2.5f;
	public int monsterHP = 20;
	
	public Material normalMat;
	public Material hurtMat;

	private bool hurt = false;
	private float hurtDelay;

	public GameObject deathParticles;

    public AudioClip monsterHit;
    public AudioClip monsterDead;

	void OnCollisionEnter (Collision other)
	{  
		hurt = true;
		hurtDelay = Time.time + 0.1f;
		monsterHP--;

		if (monsterHP <= 0) {
			Instantiate(deathParticles, transform.position, Quaternion.identity);

            //GetComponent<AudioSource>().PlayOneShot(monsterDead); 

            //GetComponent<Collider>().enabled = false;
            //GetComponent<MeshRenderer>().enabled = false;

            //Destroy(gameObject, monsterDead.length);
            Destroy(gameObject);
			GM.instance.DestroyThreat();
			GM.instance.CheckGameOver();
		}

	}

	// Update is called once per frame
	void Update () {

		ColorChange ();

		if(transform.position.x < -6f) {
			monsterSpeed =  2.5f;
		}

		if(transform.position.x >  6f) {
			monsterSpeed = -2.5f;
		}

		transform.position = new Vector3(transform.position.x + (monsterSpeed * Time.deltaTime), transform.position.y, transform.position.z);
	
	}

	void ColorChange(){

		if (hurt) {
            GetComponent<AudioSource>().PlayOneShot(monsterHit);
			foreach(Transform child in transform){
				if(!(child.name == "Eye1" || child.name == "Eye2")){
					Renderer r = child.GetComponent<Renderer>();
					r.material = hurtMat;
				}
			}
			if (Time.time > hurtDelay) {
				foreach(Transform child in transform){
					if(!(child.name == "Eye1" || child.name == "Eye2")){
						Renderer r = child.GetComponent<Renderer>();
						r.material = normalMat;
					}
				}
				hurt = false;
			} 
		}

	}
}
