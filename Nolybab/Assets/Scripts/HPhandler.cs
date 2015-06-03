using UnityEngine;
using System.Collections;

public class HPhandler : MonoBehaviour {

//	public bool canMine = false;
//	public float miningDelay;
//	public float miningTimer;
//	public int roundMineTimer;
//	public bool mining = false;
	public bool hammerActive = false;
	public float hammerUses = 5;
	// Use this for initialization
	void Start () 
	{
		//miningTimer = miningDelay;
	}
	
	// Update is called once per frame
	void Update () 
	{

		
			if (hammerActive)
			{
				//Hamer is Actief
			//GameObject.FindGameObjectWithTag("Pickaxe").SetActive(false);
			//GameObject.FindGameObjectWithTag("Sledgehammer").SetActive(true);
				transform.GetChild(3).gameObject.SetActive(false);
				transform.GetChild(4).gameObject.SetActive(true);
			} else
			{
			//Pickaxe is actief
			transform.GetChild(3).gameObject.SetActive(true);
			transform.GetChild(4).gameObject.SetActive(false);
			//GameObject.Find("Pickaxe").SetActive(true);
			//GameObject.Find("Sledgehammer").SetActive(false);;
			}

		if (hammerUses <= 0)
		{
			StartCoroutine(BackToPickaxe());
		}


}
	IEnumerator BackToPickaxe ()
	{
		yield return new WaitForSeconds (1);
		hammerActive = false;
		hammerUses = 5;
	}
}
