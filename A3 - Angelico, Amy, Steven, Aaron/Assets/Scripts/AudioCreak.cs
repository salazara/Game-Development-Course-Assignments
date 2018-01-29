using UnityEngine;
using System.Collections;

public class AudioCreak : MonoBehaviour {
	
	AudioSource creakingAudio;
	
	private void Start()
	{
		creakingAudio = GetComponent<AudioSource>();
	}

	private void OnCollisionEnter(Collision col)
	{
		creakingAudio.Play();
	}

}
