using UnityEngine;
using System.Collections;

public class LadderCollider : MonoBehaviour
{
	private GameManager GMScript;
	options script;
	
	void OnTriggerEnter (Collider coll)
	{
		if (coll.tag == "Player")
		{
			GameManager.levelsCleared += 1;
			
			if (Application.loadedLevel == 3)
			{
				Application.LoadLevel("Start");
				
				script = GameObject.Find ("OptionHandler1").GetComponent<options> ();
				((options)script.GetComponent<options> ()).reloader = true;
			}
			
			if (Application.loadedLevel == 1)
			{
				Application.LoadLevel ("Scene");
				
				script = GameObject.Find ("OptionHandler1").GetComponent<options> ();
				((options)script.GetComponent<options> ()).reloader = true;
			}
			
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