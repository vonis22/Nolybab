using UnityEngine;
using System.Collections;

public class pickslaan : MonoBehaviour {
	

	void Start () {
	
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			GetComponent<Animation> ().Play ("slaan");
		}
	}
}
