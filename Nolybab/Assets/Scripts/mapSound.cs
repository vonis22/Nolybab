using UnityEngine;
using System.Collections;

public class mapSound : MonoBehaviour {
	public AudioClip mapSoundClip;
	private bool soundPlayed;
	private float soundTimer;
	private bool paused = false;

	// Use this for initialization
	void Start () {
		soundPlayed = false;
		soundTimer = 1;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Escape))
		{
			if (paused)
			{
				paused = false;
			}
			else
			{
				paused = true;
			}
		}

		if (Input.GetKey (KeyCode.Q) && paused == false) 
		{
			soundTimer -= Time.deltaTime;
			if (soundPlayed == false) 
			{
				GetComponent<AudioSource> ().PlayOneShot (mapSoundClip, 0.7f);
			}
			soundPlayed = true;
		} else 
		{
			soundTimer = (mapSoundClip.length - (0.38f * mapSoundClip.length));
			soundPlayed = false;
			GetComponent<AudioSource> ().Stop ();
		}

		if (soundTimer <= 0) {
			soundPlayed = false;
			soundTimer = (mapSoundClip.length - (0.38f * mapSoundClip.length));

		}
	}
}
