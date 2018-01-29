using UnityEngine;
using System.Collections;

public class SummonA : MonoBehaviour {
	
	public GameObject monsterA;
	public bool summoned = false;

    public AudioClip monsterStart;

	// Update is called once per frame
	void Update () {

		if (GM.instance.bricks < 1 && summoned == false) {

			summoned = true;

			Vector3 monster_pos = new Vector3(0, 7f, 0);

			GM.instance.threat++;

			Instantiate (monsterA, monster_pos, Quaternion.identity);

            //monsterA.GetComponent<AudioSource>().PlayOneShot(monsterStart);
            GetComponent<AudioSource>().PlayOneShot(monsterStart);
		}

	}
}
