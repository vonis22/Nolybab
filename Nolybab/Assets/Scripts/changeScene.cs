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
}
