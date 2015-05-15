using UnityEngine;
using System.Collections;

public class SeePlayer : MonoBehaviour {
	public float repathSet;
	// Use this for initialization
	void Start () {
		repathSet = this.GetComponentInParent<AIPath> ().repathRate;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider c)
	{
		if (c.tag == "Player")
		{
			print (" Ik zie je...");
			repathSet = 0.5f;
		}
	}
}
