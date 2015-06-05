using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {


	void Start () 
	{
		
	}
	

	void Update () 
	{
		
	}

	void OnTriggerEnter (Collider coll)
	{
		if(coll.tag == "Player")
		{
			//Player is game over
			print ("You are dead....");
			Application.LoadLevel("GameOver");
		}
	}

}
