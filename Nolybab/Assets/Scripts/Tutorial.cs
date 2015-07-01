using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class Tutorial : MonoBehaviour
{
	SeeNolybab script;
	public GameObject startNotification;
	public GameObject instructionsPA;
	public GameObject instructionsPU1;
	public GameObject instructionsPU2;
	public GameObject instructionsPU3;
	public GameObject instructionsBW;
	public GameObject instructionsMap;
	public GameObject instructionsMap2;
	public GameObject instructionsNolybab;
	public GameObject instructionsNolybab2;
	public GameObject instructionsDiary;
	public GameObject endNotification;
	
	bool snActive = false;
	bool paActive = false;
	bool pu1Active = false;
	bool pu2Active = false;
	bool pu3Active = false;
	bool bwActive = false;
	bool mapActive = false;
	bool map2Active = false;
	bool nolybabActive = false;
	bool nolybab2Active = false;
	bool endActive = false;
	bool diaryActive = false;
	bool seekObjects = false;
	
	public bool reload = false;
	bool startTimer = false;
	
	float Timer = 3;
	float paTimer = 0.1f;
	
	void Awake ()
	{
	}
	
	void Start ()
	{
		//		startNotification = GameObject.Find ("Start Notification");
		//		instructionsPU1 = GameObject.Find ("Instructions Powerup 1");
		//		instructionsPU2 = GameObject.Find ("Instructions Powerup 2");
		//		instructionsPU3 = GameObject.Find ("Instructions Powerup 3");
		//		instructionsBW = GameObject.Find ("Instructions Breakable Wall");
		//		instructionsMap = GameObject.Find ("Instructions Map");
		//		instructionsNolybab = GameObject.Find ("Instructions Nolybab");
		//		
		//		instructionsPU1.SetActive (false);
		//		instructionsPU2.SetActive (false);
		//		instructionsPU3.SetActive (false);
		//		instructionsBW.SetActive (false);
		//		instructionsMap.SetActive (false);
		//		instructionsNolybab.SetActive (false);
		//		
		//		//startNotification.SetActive (true);
		//		snActive = true;
		//
		//		StartCoroutine (Seeker ());
	}
	
	IEnumerator Seeker()
	{
		yield return new WaitForSeconds (0.1f);
		script = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<SeeNolybab> ();
		seekObjects = true;
	}
	
	void Reload ()
	{
		startNotification = GameObject.Find ("Start Notification");
		instructionsPA = GameObject.Find ("Instructions Pickaxe");
		instructionsPU1 = GameObject.Find ("Instructions Powerup 1");
		instructionsPU2 = GameObject.Find ("Instructions Powerup 2");
		instructionsPU3 = GameObject.Find ("Instructions Powerup 3");
		instructionsBW = GameObject.Find ("Instructions Breakable Wall");
		instructionsMap = GameObject.Find ("Instructions Map");
		instructionsMap2 = GameObject.Find ("Instructions Map2");
		instructionsNolybab = GameObject.Find ("Instructions Nolybab");
		instructionsNolybab2 = GameObject.Find ("Instructions Nolybab2");
		instructionsDiary = GameObject.Find ("Instructions Diary");
		endNotification = GameObject.Find ("End Notification");
		
		instructionsPA.SetActive (false);
		instructionsPU1.SetActive (false);
		instructionsPU2.SetActive (false);
		instructionsPU3.SetActive (false);
		instructionsBW.SetActive (false);
		instructionsMap.SetActive (false);
		instructionsMap2.SetActive (false);
		instructionsNolybab.SetActive (false);
		instructionsNolybab2.SetActive (false);
		instructionsDiary.SetActive (false);
		endNotification.SetActive (false);
		
		//startNotification.SetActive (true);
		snActive = true;
		
		StartCoroutine (Seeker ());
	}
	
	void Update ()
	{
		if (reload)
		{
			Reload ();
			reload = false;
		}
		
		if (startTimer)
		{
			paTimer -= Time.deltaTime;
			instructionsPA.SetActive (true);
			paActive = true;
		}
		
		if (snActive && startNotification != null)
		{
			//			Timer -= Time.deltaTime;
			
			//			if (Timer <= 0)
			//			{
			//				startNotification.SetActive (false);
			//				snActive = false;
			//				Destroy(startNotification);
			//				Timer = 3;
			//			}
			
			if (Input.GetKeyDown (KeyCode.F))
			{
				startNotification.SetActive (false);
				snActive = false;
				Destroy (startNotification);
				
				startTimer = true;
			}
		}
		
		if (paActive && instructionsPA != null && paTimer <= 0)
		{
			//			Timer -= Time.deltaTime;
			
			//			if (Timer <= 0)
			//			{
			//				instructionsPA.SetActive (false);
			//				paActive = false;
			//				Destroy(instructionsPA);
			//				Timer = 3;
			//			}
			
			if (Input.GetKeyDown (KeyCode.F))
			{
				instructionsPA.SetActive (false);
				paActive = false;
				Destroy (instructionsPA);
				startTimer = false;
				paTimer = 1;
			}
		}
		
		if (pu1Active && instructionsPU1 != null)
		{
			//			Timer -= Time.deltaTime;
			
			//			if (Timer <= 0)
			//			{
			//				instructionsPU1.SetActive (false);
			//				pu1Active = false;
			//				Destroy(instructionsPU1);
			//				Timer = 3;
			//			}
			
			if (Input.GetKeyDown (KeyCode.F))
			{
				instructionsPU1.SetActive (false);
				pu1Active = false;
				Destroy (instructionsPU1);
			}
		}
		
		if (pu2Active && instructionsPU2 != null)
		{
			//			Timer -= Time.deltaTime;
			
			//			if (Timer <= 0)
			//			{
			//				instructionsPU2.SetActive (false);
			//				pu2Active = false;
			//				Destroy(instructionsPU2);
			//				Timer = 3;
			//			}
			
			if (Input.GetKeyDown (KeyCode.F))
			{
				instructionsPU2.SetActive (false);
				pu2Active = false;
				Destroy (instructionsPU2);
			}
		}
		
		if (pu3Active && instructionsPU3 != null)
		{
			//			Timer -= Time.deltaTime;
			
			//			if (Timer <= 0)
			//			{
			//				instructionsPU3.SetActive (false);
			//				pu3Active = false;
			//				Destroy(instructionsPU3);
			//				Timer = 3;
			//			}
			
			if (Input.GetKeyDown (KeyCode.F))
			{
				instructionsPU3.SetActive (false);
				pu3Active = false;
				Destroy (instructionsPU3);
			}
		}
		
		if (bwActive && instructionsBW != null)
		{
			//			Timer -= Time.deltaTime;
			
			//			if (Timer <= 0)
			//			{
			//				instructionsBW.SetActive (false);
			//				bwActive = false;
			//				Destroy(instructionsBW);
			//				Timer = 3;
			//			}
			
			if (Input.GetKeyDown (KeyCode.F))
			{
				instructionsBW.SetActive (false);
				bwActive = false;
				Destroy (instructionsBW);
			}
		}
		
		if (map2Active && instructionsMap2 != null)
		{
			//			Timer -= Time.deltaTime;
			
			//			if (Timer <= 0)
			//			{
			//				instructionsMap2.SetActive (false);
			//				map2Active = false;
			//				Destroy(instructionsMap2);
			//				Timer = 3;
			//			}
			
			if (Input.GetKeyDown (KeyCode.F))
			{
				instructionsMap2.SetActive (false);
				map2Active = false;
				Destroy (instructionsMap2);
			}
		}
		
		if (nolybab2Active && instructionsNolybab2 != null)
		{
			//			Timer -= Time.deltaTime;
			
			//			if (Timer <= 0)
			//			{
			//				instructionsNolybab2.SetActive (false);
			//				nolybab2Active = false;
			//				Destroy(instructionsNolybab2);
			//				Timer = 3;
			//			}
			
			if (Input.GetKeyDown (KeyCode.F))
			{
				instructionsNolybab2.SetActive (false);
				nolybab2Active = false;
				Destroy (instructionsNolybab2);
			}
		}
		
		if (diaryActive && instructionsDiary != null)
		{
			//			Timer -= Time.deltaTime;
			
			//			if (Timer <= 0)
			//			{
			//				instructionsDiary.SetActive (false);
			//				DiaryActive = false;
			//				Destroy(instructionsDiary);
			//				Timer = 3;
			//			}
			
			if (Input.GetKeyDown (KeyCode.F))
			{
				instructionsDiary.SetActive (false);
				diaryActive = false;
				Destroy (instructionsDiary);
			}
		}
		
		if (endActive && endNotification != null )
		{
			//			Timer -= Time.deltaTime;
			
			//			if (Timer <= 0)
			//			{
			//				endNotification.SetActive (false);
			//				endActive = false;
			//				Destroy(endNotification);
			//				Timer = 3;
			//			}
			
			if (Input.GetKeyDown (KeyCode.F))
			{
				endNotification.SetActive (false);
				endActive = false;
				Destroy (endNotification);
			}
		}
		
		if (seekObjects)
		{
			if (script.seeMap && instructionsMap != null)
			{
				instructionsMap.SetActive (true);
				mapActive = true;
			}
			
			//			if (mapActive)
			//			{
			//				Timer -= Time.deltaTime;
			//				
			//				if (Timer <= 0)
			//				{
			//					instructionsMap.SetActive (false);
			//					mapActive = false;
			//					Destroy(instructionsMap);
			//					Timer = 3;
			//				}
			//			}
			
			if (Input.GetKeyDown (KeyCode.F) && mapActive)
			{
				instructionsMap.SetActive (false);
				mapActive = false;
				Destroy (instructionsMap);
				
				instructionsMap2.SetActive (true);
				map2Active = true;
			}
		}
		
		if (seekObjects)
		{
			if (script.nolybabIsVisible && instructionsNolybab != null)
			{
				instructionsNolybab.SetActive (true);
				nolybabActive = true;
			}
			
			//			if (nolybabActive)
			//			{
			//				Timer -= Time.deltaTime;
			//			
			//				if (Timer <= 0)
			//				{
			//					instructionsNolybab.SetActive (false);
			//					nolybabActive = false;
			//					Destroy(instructionsNolybab);
			//					Timer = 3;
			//				}
			//			}
			
			if (Input.GetKeyDown (KeyCode.F) && nolybabActive)
			{
				instructionsNolybab.SetActive (false);
				nolybabActive = false;
				Destroy (instructionsNolybab);
				
				instructionsNolybab2.SetActive (true);
				nolybab2Active = true;
			}
		}
		
		if (seekObjects)
		{
			if (script.seeDiary && instructionsDiary != null)
			{
				instructionsDiary.SetActive (true);
				diaryActive = true;
			}
			
			if (Input.GetKeyDown (KeyCode.F) && diaryActive)
			{
				instructionsDiary.SetActive (false);
				diaryActive = false;
				Destroy (instructionsDiary);
			}
		}
	}
	
	void OnTriggerStay (Collider coll)
	{
		if (coll.gameObject.name == "Powerup 1(Clone)" && Input.GetKeyDown(KeyCode.E))
		{
			instructionsPU1.SetActive (true);
			pu1Active = true;
		}
		
		if (coll.gameObject.name == "Powerup 2(Clone)" && Input.GetKeyDown(KeyCode.E))
		{
			instructionsPU2.SetActive (true);
			pu2Active = true;
		}
		
		if (coll.gameObject.name == "Powerup 3(Clone)" && Input.GetKeyDown(KeyCode.E))
		{
			instructionsPU3.SetActive (true);
			pu3Active = true;
		}
		
		if (coll.gameObject.tag == "BreakWall" && instructionsBW != null)
		{
			instructionsBW.SetActive (true);
			bwActive = true;
		}
		
		if (coll.gameObject.name == "EndPopUpTrigger" && endNotification != null)
		{
			endNotification.SetActive (true);
			endActive = true;
		}
	}
}