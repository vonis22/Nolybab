using UnityEngine;
using System.Collections;

public class SeePlayer : MonoBehaviour {
	public float repathSet;
	public float seeTimer;
	public bool decreaseTimer = false;
	public AIPath aiScript;

	void Start () 
	{
		repathSet = this.GetComponentInParent<AIPath> ().repathRate;
		aiScript = GameObject.FindGameObjectWithTag ("Maze").GetComponent<AIPath> ();
	}

	void Update () 
	{
//		print (seeTimer);

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

	void OnTriggerStay (Collider c)
	{
		if (c.tag == "Player")
		{
			print (" Ik zie je...");
			seeTimer = 2.0f;
		}

	}

	void OnTriggerEnter(Collider c)
	{
		if (c.tag == "Player")
		{
			this.GetComponentInParent<AIPath> ().repathRate = 0.5f;
			//aiScript.SearchPath();
		}
	}

	void OnTriggerExit()
	{
		print (" Doei...");
		decreaseTimer = true;
	}
}
