using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class startMovie : MonoBehaviour {

	private MovieTexture introMovie;
	private AudioSource sound;
	
	void Start () 
	{
		//introMovie = gameObject.GetComponent<Renderer>().material.mainTexture as MovieTexture;
		//introMovie.Play ();
		//(MovieTexture)GetComponent<Image>().material.mainTexture).Play();

		introMovie = (MovieTexture)GetComponent<RawImage> ().texture;
		introMovie.Play ();
		sound = GetComponent<AudioSource> ();
		sound.clip = introMovie.audioClip;
		sound.Play ();
	}

	void Update () 
	{
//	 	if (!introMovie.isPlaying)
//		{
//			print ("movie playing status: " + introMovie.isPlaying + ".");
//			introMovie.Play ();
//		}
	}
}
