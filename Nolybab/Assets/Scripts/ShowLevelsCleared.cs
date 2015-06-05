using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowLevelsCleared : MonoBehaviour {
	private Text text;
	void Start () {
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Game over " + GameManager.levelsCleared.ToString() + " levels cleared";
	}
}
