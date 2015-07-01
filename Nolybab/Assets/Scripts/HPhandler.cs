using UnityEngine;
using System.Collections;

public class HPhandler : MonoBehaviour {


	public bool hammerActive = false;
	public float hammerUses = 5;

	public bool paused = false;

	void Start () 
	{
	}
	

	void Update () 
	{
		if (hammerActive)
		{
		//Hamer is active
		//GameObject.FindGameObjectWithTag("Pickaxe").SetActive(false);
		//GameObject.FindGameObjectWithTag("Sledgehammer").SetActive(true);
		transform.GetChild(3).gameObject.SetActive(false);
		transform.GetChild(4).gameObject.SetActive(true);
		} else
		{
		//Pickaxe is active
		transform.GetChild(3).gameObject.SetActive(true);
		transform.GetChild(4).gameObject.SetActive(false);
		//GameObject.Find("Pickaxe").SetActive(true);
		//GameObject.Find("Sledgehammer").SetActive(false);;
		}

		if (hammerUses <= 0)
		{
			StartCoroutine(BackToPickaxe());
		}

		if (Input.GetKey(KeyCode.Q) && paused == false)
		{
			transform.GetChild(0).transform.GetChild (0).gameObject.SetActive(true);
		}
		else
		{
			transform.GetChild(0).transform.GetChild (0).gameObject.SetActive(false);
		}

		if (Input.GetKeyDown (KeyCode.Escape))
		{
			if (paused)
			{
				paused = false;
			}
			else
			{
				paused = true;
			}
		}


}
	IEnumerator BackToPickaxe ()
	{
		yield return new WaitForSeconds (1);
		hammerActive = false;
		hammerUses = 5;
	}
}
