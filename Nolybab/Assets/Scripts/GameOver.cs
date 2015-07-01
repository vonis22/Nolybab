using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {


	void OnTriggerEnter (Collider coll)
	{
		if(coll.tag == "Player")
		{
			//Player is game over
			print ("You are dead....");
			if(OVRPlayerController.playingWithOculus)
			{
				Application.LoadLevel("OculusGameOver1");
			}
			else
			{
				Application.LoadLevel("GameOver");
			}
		}
	}

}
