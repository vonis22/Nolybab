using UnityEngine;
using System.Collections;

public class pickslaan : MonoBehaviour {
	

	void Start () {
	
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.E)) {
			GetComponent<Animation> ().Play ("slaan");
		}
	}
}
