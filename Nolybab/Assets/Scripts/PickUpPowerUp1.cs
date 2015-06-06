using UnityEngine;
using System.Collections;

public class PickUpPowerUp1 : MonoBehaviour {

	private bool canPrintMessage = false;
	private AIPath script;
	public AudioClip pickupSound;
	private AudioSource audio;
	private bool pickedUp = false;

	void Start()
	{
		audio = GetComponent<AudioSource> ();
		GetComponent<AIPathOriginal>().enabled = false;
		script = GameObject.FindGameObjectWithTag ("Nolybab").GetComponent<AIPath>();
	}


	void OnTriggerStay (Collider coll)
	{
		if (coll.tag == "Player")
		{
			if(Input.GetKeyDown(KeyCode.E))
			{
				CreateDirectionSign();
				audio.PlayOneShot(pickupSound,0.7f);
				Destroy(gameObject,10.0f);
			}
		}
	}

	void OnTriggerEnter(Collider coll)
	{
		if (coll.tag == "Player" && pickedUp == false)
		{
			canPrintMessage = true;
			pickedUp = true;

		}
		if (coll.tag == "EndLadder")
		{
			Destroy(gameObject);
		}
	}

	void OnTriggerExit(Collider coll)
	{
		if (coll.tag == "Player")
		{
			canPrintMessage = false;
		}
	}

	void CreateDirectionSign()
	{
		//Has to be done in another script, because this script will be destroyed
		//transform.GetChild (1).transform.GetChild (0).GetComponent<Animation> ().Play ("RiseFloatingBall");
		//GameObject.FindGameObjectWithTag("PowerUp1").GetComponent<Animation>().Play ("RiseFloatingBall");
		transform.GetChild (2).gameObject.SetActive (false);
		GetComponent<AIPathOriginal> ().enabled = true;
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
