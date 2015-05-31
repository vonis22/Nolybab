using UnityEngine;
using System.Collections;

public class PickSwing : MonoBehaviour {


	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.E) || Input.GetKeyDown (KeyCode.Mouse0)) 
		{
			GetComponent<Animation> ().Play ("Pickaxe Swing");
		}
	}
}
