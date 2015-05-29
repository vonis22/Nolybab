using UnityEngine;
using System.Collections;

public class PickSwing : MonoBehaviour {
	

	void Start () {
	
	}

	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.E) || Input.GetKeyDown (KeyCode.Mouse0)) 
		{
			GetComponent<Animation> ().Play ("slaan");
		}
	}
}
