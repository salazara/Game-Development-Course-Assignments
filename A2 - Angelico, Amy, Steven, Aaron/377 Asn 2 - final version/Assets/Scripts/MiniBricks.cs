using UnityEngine;
using System.Collections;

public class MiniBricks : MonoBehaviour {

	public GameObject brickParticle;

	void OnCollisionEnter (Collision other)
	{
		
		Vector3 brick_pos = transform.position;
		
		Instantiate(brickParticle, brick_pos, Quaternion.identity);
		GM.instance.bricks--;
        //AudioSource.PlayClipAtPoint(Sound.clip, transform.position);
        //audio.PlayOneShot(Sound.GetComponent<AudioClip>());

        GetComponent<AudioSource>().Play();
        
        GetComponent<Collider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;

        Destroy(gameObject, GetComponent<AudioSource>().clip.length);
	}
}
