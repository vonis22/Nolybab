using UnityEngine;
using System.Collections;

public class PickUpPowerUp3 : MonoBehaviour {

	private bool canPrintMessage = false;
	private AIPath script;
	private AudioSource audio;
	public AudioClip pickupSound;
	public int randomRender;
	public Texture pickUpTexture;



	void Start()
	{
		audio = GetComponent<AudioSource> ();
		StartCoroutine (CheckValues ());
		randomRender = (int)Random.Range (0, 3);

		transform.GetChild(0).gameObject.SetActive(false);
		transform.GetChild(1).gameObject.SetActive(false);
		transform.GetChild(2).gameObject.SetActive(false);



		
	}
	IEnumerator CheckValues()
	{
		yield return new WaitForSeconds (0.1f);
		transform.GetChild(randomRender).gameObject.SetActive(true);
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
				audio.PlayOneShot(pickupSound,0.7f);
				script.increaseSanity = true;
				transform.GetChild(0).gameObject.SetActive(false);
				transform.GetChild(1).gameObject.SetActive(false);
				transform.GetChild(2).gameObject.SetActive(false);
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
