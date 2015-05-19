using UnityEngine;
using System.Collections;

public class WallSounds : MonoBehaviour {

	//AudioClips
	public AudioClip wallSound_0;
	public AudioClip wallSound_1;
	public AudioClip wallSound_2;
	public AudioClip wallSound_3;
	public AudioClip wallSound_4;
	public AudioClip wallSound_5;
	public AudioClip wallSound_6;
	public AudioClip wallSound_7;
	public AudioClip wallSound_8;

	public AudioClip[] wallSounds;

	void Start () 
	{
		wallSounds = new AudioClip[] 
		{
			wallSound_0,
			wallSound_1,
			wallSound_2,
			wallSound_3,
			wallSound_4,
			wallSound_5,
			wallSound_6,
			wallSound_7,
			wallSound_8
		};
	}

	void PlaySound()
	{
		GetComponent<AudioSource> ().clip = wallSounds [Random.Range (0, wallSounds.Length)];
		GetComponent<AudioSource>().Play();
	}

	void OnTriggerEnter (Collider c)
	{
		if (c.tag == "Pickaxe") 
		{
			PlaySound();
		}
	}
}
