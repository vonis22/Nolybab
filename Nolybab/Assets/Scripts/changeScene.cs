using UnityEngine;
using System.Collections;

public class changeScene : MonoBehaviour {

	public static bool loading = false;
	public GameObject loadingPrefab;


	public void ChangeToScene (string SceneToChangeTo)
	{
		loading = true;
		Application.LoadLevel (SceneToChangeTo);

	}
	public void ResetLevelsCleared()
	{
		GameManager.levelsCleared = 0;
	}

	void Update()
	{
		Screen.lockCursor = false;

		if (Input.GetButtonDown ("Restart Button") || Input.GetKeyDown (KeyCode.R))
		{
			loading = true;
			ChangeToScene("Start");
		}

		if (loading == true)
		{
			loadingPrefab.gameObject.SetActive(true);
			GetComponent<AudioSource>().Stop();
		}
		else 
		{
			loadingPrefab.gameObject.SetActive(false);
		}
	}
}
