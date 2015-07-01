using UnityEngine;
using System.Collections;

public class LadderCollider : MonoBehaviour
{
	private GameManager GMScript;
	public AudioClip endAudio;
	private AudioSource audio;
	options script;

	void Start ()
	{
		audio = GetComponent<AudioSource> ();
	}
	void OnTriggerEnter (Collider coll)
	{
		if (coll.tag == "Player")
		{
			GameManager.levelsCleared += 1;

			if (startMovie.storyMode){
				if (PickUpDiaryPage.currentLevel == 4)
				{
					StartCoroutine(EndStory());
				}
				else 
				{
					PickUpDiaryPage.currentLevel += 1;
					Application.LoadLevel ("Scene");
				}
			} else {
			if (Application.loadedLevel == 3)
			{
				Application.LoadLevel("Start");
				
				script = GameObject.Find ("OptionHandler1").GetComponent<options> ();
				((options)script.GetComponent<options> ()).reloader = true;
			}
			
			if (Application.loadedLevel == 1)
			{
				Application.LoadLevel ("Scene");
				
				script = GameObject.Find ("OptionHandler1").GetComponent<options> ();
				((options)script.GetComponent<options> ()).reloader = true;
			}
			
			print ("Enter");
			}
		}
	}
	
	void OnTriggerExit (Collider coll)
	{
		if (coll.tag == "Player")
		{
			print ("ExitLeave");
		}
	}

	IEnumerator EndStory ()
	{
		PickUpDiaryPage.currentLevel = 1;
		audio.PlayOneShot (endAudio);
		Time.timeScale = 0;
		yield return new WaitForSeconds (endAudio.length);
		audio.Stop ();
		Application.LoadLevel("Start");
	}
}