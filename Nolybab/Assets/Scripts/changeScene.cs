using UnityEngine;
using System.Collections;

public class changeScene : MonoBehaviour {

	public static bool loading = false;
	public GameObject loadingPrefab;
	public AudioSource hoverSound;
	public AudioSource mouseClick;
	public AudioSource startTune;

	options script;

//	public void ChangeToScene (string SceneToChangeTo)
//	{
//		loading = true;
//		Application.LoadLevel (SceneToChangeTo);
//
//	}
	public void ResetLevelsCleared()
	{
		GameManager.levelsCleared = 0;
	}
	
	void Update()
	{
		Screen.lockCursor = false;

//		if (Input.GetButtonDown ("Restart Button") || Input.GetKeyDown (KeyCode.R))
//		{
//			loading = true;
//		}

//		if (loading == true)
//		{
//			//loadingPrefab.SetActive(true);
//			//GetComponent<AudioSource>().Stop();
//		}
//		else 
//		{
//			loadingPrefab.SetActive(false);
//		}
	}

	public void Hover ()
	{
		hoverSound.Play ();
	}

	public void MouseClick ()
	{
		mouseClick.Play ();
		loadingPrefab.SetActive(true);
		startTune = GameObject.Find ("Main Camera").GetComponent<AudioSource> ();
		startTune.Stop ();
		Application.LoadLevel ("Start");
		//loading = false;
	}
}
