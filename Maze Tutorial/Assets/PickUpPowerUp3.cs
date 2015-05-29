﻿using UnityEngine;
using System.Collections;

public class PickUpPowerUp3 : MonoBehaviour {

	private bool canPrintMessage = false;
	private AIPath script;

	void Start()
	{
		script = GameObject.FindGameObjectWithTag ("Nolybab").GetComponent<AIPath>();
	}

	void OnTriggerStay (Collider coll)
	{
		if (coll.tag == "Player")
		{
			//Show GUI message ("Press 'E' to pickup")

			print ("Je kan m oppakken");

			if(Input.GetKeyDown(KeyCode.E))
			{
				script.increaseSanity = true;
				Destroy(gameObject);
			}
		}
	}

	void OnTriggerEnter(Collider coll)
	{
		if (coll.tag == "Player")
		{
			canPrintMessage = true;
		}
	}

	void OnTriggerExit(Collider coll)
	{
		if (coll.tag == "Player")
		{
			canPrintMessage = false;
		}
	}

	
	public void OnGUI ()
	{
		GUIStyle powerFont = new GUIStyle ();
		//powerFont.font = (Font)Resources.Load ("my_font", typeof(Font));
		powerFont.fontSize = 50;
		powerFont.normal.textColor = Color.white;

		if(canPrintMessage)
		{
			GUI.Label(new Rect(Screen.width / 100*50 +1 ,Screen.height / 20*3 ,150 ,150), "Press E to pickup".ToString(), powerFont);
		}
	}

}
