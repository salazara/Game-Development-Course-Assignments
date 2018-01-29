using UnityEngine;
using System.Collections;

public class AudioSmash : MonoBehaviour {
	
	AudioSource smashAudio;
	
	private void Start()
	{
		smashAudio = GetComponent<AudioSource>();
	}

	private void OnCollisionEnter(Collision col)
	{
		//samoflange ball was tagged with 'Ball'
		if (col.gameObject.tag.Equals ("Ball") == true) {
			smashAudio.Play ();
		}
	}

}
