using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class startMovie : MonoBehaviour {

	private MovieTexture introMovie;
	private AudioSource sound;
	public GameObject options_prefab;
	public float playTimer = 0f;
	public static bool storyMode;
	void Start () 
	{
		//introMovie = gameObject.GetComponent<Renderer>().material.mainTexture as MovieTexture;
		//introMovie.Play ();
		options_prefab.GetComponent<options> ().startTune.Stop ();
		introMovie = (MovieTexture)GetComponent<RawImage> ().texture;
		introMovie.Play ();
		sound = GetComponent<AudioSource> ();
		sound.clip = introMovie.audioClip;
		sound.Play ();
		storyMode = true;
	}

	void Update () 
	{
		playTimer += Time.deltaTime;
		if (Input.GetKeyDown(KeyCode.Space) || playTimer >= introMovie.audioClip.length)
		{
			options_prefab.GetComponent<options> ().Play ();
			playTimer = 0f;
		}
	}
}
