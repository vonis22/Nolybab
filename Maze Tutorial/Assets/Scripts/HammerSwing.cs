using UnityEngine;
using System.Collections;

public class HammerSwing : MonoBehaviour {

	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.E) || Input.GetKeyDown (KeyCode.Mouse0)) 
		{
			GetComponent<Animation> ().Play ("Hammer Swing");
		}
	}
}
