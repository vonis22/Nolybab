﻿using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class Tutorial : MonoBehaviour
{
	SeeNolybab script;
	public GameObject startNotification;
	public GameObject instructionsPU1;
	public GameObject instructionsPU2;
	public GameObject instructionsPU3;
	public GameObject instructionsBW;
	public GameObject instructionsMap;
	public GameObject instructionsNolybab;

	bool snActive = false;
	bool pu1Active = false;
	bool pu2Active = false;
	bool pu3Active = false;
	bool bwActive = false;
	bool mapActive = false;
	bool nolybabActive = false;
	bool seekObjects = false;

	float Timer = 3;

	void Awake ()
	{
		StartCoroutine (Seeker ());

		if (Application.loadedLevel == 3)
		{
			startNotification.SetActive (true);
			snActive = true;
		}
	}

	IEnumerator Seeker()
	{
		yield return new WaitForSeconds (0.1f);
		script = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<SeeNolybab> ();
		seekObjects = true;
	}

	void Update ()
	{
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
			instructionsBW.SetActive (true);;
			bwActive = true;
		}
	}
}