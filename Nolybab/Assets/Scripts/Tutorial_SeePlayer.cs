using UnityEngine;
using System.Collections;

public class Tutorial_SeePlayer : MonoBehaviour {
	public float repathSet;
	public float seeTimer;
	public bool decreaseTimer = false;
	public Tutorial_AiNolybab aiScript;

	void Start () 
	{
		repathSet = this.GetComponentInParent<Tutorial_AiNolybab> ().repathRate;
		aiScript = GameObject.FindGameObjectWithTag ("Maze").GetComponent<Tutorial_AiNolybab> ();
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
			this.GetComponentInParent<Tutorial_AiNolybab> ().repathRate = 10f;
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
			this.GetComponentInParent<Tutorial_AiNolybab> ().repathRate = 0.5f;
			//aiScript.SearchPath();
		}
	}

	void OnTriggerExit()
	{
		print (" Doei...");
		decreaseTimer = true;
	}
}
