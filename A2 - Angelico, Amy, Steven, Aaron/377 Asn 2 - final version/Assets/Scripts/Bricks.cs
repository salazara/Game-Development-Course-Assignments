using UnityEngine;
using System.Collections;

public class Bricks : MonoBehaviour {
	
	public GameObject brickParticle;
	public GameObject miniBricksPrefab;

    //public AudioClip brickBreak;

    //public AudioSource audio;
	
	void OnCollisionEnter (Collision other)
	{

		Vector3 brick_pos = transform.position;

		Instantiate(brickParticle, brick_pos, Quaternion.identity);
		GM.instance.bricks--;
        //AudioSource.PlayClipAtPoint(Sound.GetComponent<AudioSource>(), new Vector3(5, 1, 2), 0.9f);

        GetComponent<AudioSource>().Play();

        GetComponent<Collider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;

        Destroy(gameObject, GetComponent<AudioSource>().clip.length);

        //audio.PlayOneShot(Sound.GetComponent<AudioClip>());

		if (GM.instance.bricks > 0) {
			GM.instance.bricks += 2;
			Instantiate(miniBricksPrefab, brick_pos, Quaternion.identity);
		}
	}
}