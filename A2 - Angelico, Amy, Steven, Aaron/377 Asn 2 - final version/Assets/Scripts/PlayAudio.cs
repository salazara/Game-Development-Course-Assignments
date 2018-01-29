using UnityEngine;
using System.Collections;

public class PlayAudio : MonoBehaviour {

    public static AudioClip thisclip;

    public static void Play(AudioClip theclip) {
        thisclip = theclip;
        AudioSource.PlayClipAtPoint(thisclip, new Vector3(5,1,2));
	}
}
