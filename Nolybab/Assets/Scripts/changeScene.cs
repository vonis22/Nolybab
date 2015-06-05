using UnityEngine;
using System.Collections;

public class changeScene : MonoBehaviour {
	
	public void ChangeToScene (string SceneToChangeTo)
	{
		Application.LoadLevel (SceneToChangeTo);
	}
	public void ResetLevelsCleared()
	{
		GameManager.levelsCleared = 0;
	}

	void Update()
	{
		if (Input.GetButtonDown ("Restart Button") || Input.GetKeyDown (KeyCode.R))
		{
			ChangeToScene("Scene");
		}
	}
}
