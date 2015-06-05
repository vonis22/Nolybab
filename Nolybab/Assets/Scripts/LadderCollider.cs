using UnityEngine;
using System.Collections;

public class LadderCollider : MonoBehaviour
{
	private GameManager GMScript;
	void OnTriggerEnter (Collider coll)
	{
		if (coll.tag == "Player")
		{
			GameManager.levelsCleared += 1;
			Application.LoadLevel("Scene");
			print ("Enter");
		}
	}

	void OnTriggerExit (Collider coll)
	{
		if (coll.tag == "Player")
		{
			print ("ExitLeave");
		}
	}
}