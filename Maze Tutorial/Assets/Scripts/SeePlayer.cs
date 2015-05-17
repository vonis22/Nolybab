using UnityEngine;
using System.Collections;

public class SeePlayer : MonoBehaviour {
	public float repathSet;
	public float seeTimer;
	public bool decreaseTimer = false;

	void Start () 
	{
		repathSet = this.GetComponentInParent<AIPath> ().repathRate;
	}

	void Update () 
	{
		print (seeTimer);

		if (decreaseTimer == true)
		{
			seeTimer -= Time.deltaTime;
		}

		if (seeTimer <= 0.0f)
		{
			this.GetComponentInParent<AIPath> ().repathRate = 10f;
			decreaseTimer = false;
		}
	}

	void OnTriggerEnter(Collider c)
	{
		if (c.tag == "Player")
		{
			seeTimer = 2.0f;
			print (" Ik zie je...");
			this.GetComponentInParent<AIPath> ().repathRate = 0.5f;
		}
	}

	void OnTriggerExit()
	{
		print (" Doei...");
		decreaseTimer = true;
	}
}
