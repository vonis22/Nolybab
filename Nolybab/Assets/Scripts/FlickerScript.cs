using UnityEngine;
using System.Collections;

public class FlickerScript : MonoBehaviour {
	public float baseFlicker = 1f;
	public float flickerIntensity = 1f;

	public float baseRange = 10f;
	public float rangeIntensity = 1f;

	public float sineCycle = 0f;
	public float sineSpeed = 0f;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		sineCycle += sineSpeed;
		if (sineCycle > 360f) 
			sineCycle = 0f;
		GetComponent<Light>().intensity = baseFlicker + ((Mathf.Sin (sineCycle * Mathf.Deg2Rad) * (flickerIntensity / 2.0f)) * (flickerIntensity / 2.0f));
	}
}
