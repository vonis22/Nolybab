using UnityEngine;
using System.Collections;

public class PickUpDiaryPage : MonoBehaviour {

	private bool canPrintMessage = false;
	private AIPath aiScript;
	private HPhandler hpScript;
	private AudioSource audio;
	public AudioClip pickupSound;
	public Texture pickUpTexture;
	public static int currentLevel = 1;

	public Texture Page1;
	public Texture Page2;
	public Texture Page3;
	public Texture Page4;
	public bool showPage;


	void Start()
	{
		StartCoroutine (DefineValues ());
		showPage = false;
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
				//transform.GetChild(0).gameObject.SetActive(false);
				showPage = true;
				canPrintMessage = false;
			

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
			showPage = false;
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
		if (showPage)
		{
			if (currentLevel == 1)
			{
				GUI.DrawTexture(new Rect(Screen.width / 100*20 , Screen.height / 100*20 ,Screen.width / 100*60,Screen.height / 100*68), Page1);
			}
			if (currentLevel == 2)
			{
				GUI.DrawTexture(new Rect(Screen.width / 100*20 , Screen.height / 100*20 ,Screen.width / 100*60,Screen.height / 100*68), Page2);
			}
			if (currentLevel == 3)
			{
				GUI.DrawTexture(new Rect(Screen.width / 100*20 , Screen.height / 100*20 ,Screen.width / 100*60,Screen.height / 100*68), Page3);
			}
			if (currentLevel == 4)
			{
				GUI.DrawTexture(new Rect(Screen.width / 100*20 , Screen.height / 100*20 ,Screen.width / 100*60,Screen.height / 100*68), Page4);
			}
		}
	}

}
