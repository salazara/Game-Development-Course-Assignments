using UnityEngine;
using System.Collections;

public class AudioGong : MonoBehaviour
{

    AudioSource smashAudio;

    private void Start()
    {
        smashAudio = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag.Equals("Ball") == true)
        {
            smashAudio.Play();
        }
    }

}
