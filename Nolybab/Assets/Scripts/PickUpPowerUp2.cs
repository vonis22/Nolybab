using UnityEngine;
using System.Collections;

public class PickUpPowerUp2 : MonoBehaviour {

	private bool canPrintMessage = false;
	private AIPath aiScript;
	private HPhandler hpScript;
	private AudioSource audio;
	public AudioClip pickupSound;
	public Texture pickUpTexture;


	void Start()
	{
		StartCoroutine (DefineValues ());

		audio = GetComponent<AudioSource> ();
	}
	IEnumerator DefineValues()
	{
		yield return new WaitForSeconds (0.1f);
		aiScript = GameObject.FindGameObjectWithTag ("Nolybab").GetComponent<AIPath>();
		hpScript = GameObject.FindGameObjectWithTag ("Player").GetComponent<HPhandler> ();
	}
	void OnTriggerStay (Collider coll)
	{
		if (coll.tag == "Player")
		{
			if(Input.GetKeyDown(KeyCode.E))
			{
				audio.PlayOneShot(pickupSound,0.7f);
				SwitchAxe();
				transform.GetChild(0).gameObject.SetActive(false);
				Destroy(gameObject,pickupSound.length);
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

	void SwitchAxe()
	{
		print ("You will get a sledgehammer now");
		//Pickaxe becomes inactive Hammer becomes active
		hpScript.hammerActive = true;
		//startHammerTimer here
	}
	
	public void OnGUI ()
	{
		GUIStyle powerFont = new GUIStyle ();
		//powerFont.font = (Font)Resources.Load ("my_font", typeof(Font));
		powerFont.fontSize = 50;
		powerFont.normal.textColor = Color.white;

		if(canPrintMessage)
		{
			GUI.DrawTexture(new Rect(Screen.width / 100*50 , Screen.height / 20*15 ,75,75), pickUpTexture);  
			//GUI.Label(new Rect(Screen.width / 100*50 +1 ,Screen.height / 20*3 ,150 ,150), "Press E to pickup".ToString(), powerFont);
		}
	}

}
