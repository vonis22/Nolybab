using UnityEngine;
using System.Collections;

public class HammerSwing : MonoBehaviour {

	void Start ()
	{

	}
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.E) || Input.GetKeyDown (KeyCode.Mouse0)) 
		{
			GetComponent<Animation> ().Play ("Hammer Swing");
		}

	}
}
