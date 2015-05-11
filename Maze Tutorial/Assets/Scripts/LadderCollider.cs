using UnityEngine;
using System.Collections;

public class LadderCollider : MonoBehaviour
{
	void OnTriggerEnter (Collider coll)
	{
		if (coll.tag == "Player")
		{
			Application.LoadLevel("Scene");
			//print ("Enter");
		}
	}

	void OnTriggerExit (Collider coll)
	{
		if (coll.tag == "Player")
		{
			//print ("ExitLeave");
		}
	}
}