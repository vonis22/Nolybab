using UnityEngine;
using System.Collections;

public class NolyTalks : MonoBehaviour {

	public AudioClip nolyTalk_0;
	public AudioClip nolyTalk_1;
	public AudioClip nolyTalk_2;
	public AudioClip nolyTalk_3;
	public AudioClip nolyTalk_4;
	public AudioClip nolyTalk_5;
	public AudioClip nolyTalk_6;
	public AudioClip nolyTalk_7;
	public AudioClip nolyTalk_8;
	public AudioClip nolyTalk_9;

	public AudioClip[] nolySounds;
	public AudioClip randomSound;

	public float soundTimer = 5.0f;

	private AudioSource audio;
	// Use this for initialization
	void Start () {

		audio = GetComponent<AudioSource> ();
		nolySounds = new AudioClip[] {
			nolyTalk_0,
			nolyTalk_1,
			nolyTalk_2,
			nolyTalk_3,
			nolyTalk_4,
			nolyTalk_5,
			nolyTalk_6,
			nolyTalk_7,
			nolyTalk_8,
			nolyTalk_9
		};

		randomSound = nolySounds [Random.Range (0, nolySounds.Length)];
	
	}
	
	// Update is called once per frame
	void Update () {
		soundTimer -= Time.deltaTime;



		if (soundTimer <= 0){
			PlaySound();
			randomSound = nolySounds [Random.Range (0, nolySounds.Length)];
			soundTimer = Random.Range (5,16);

		}

	
	}

	void PlaySound()
	{
		audio.PlayOneShot(randomSound ,1f);
	}
}
