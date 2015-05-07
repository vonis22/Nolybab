using UnityEngine;
using System.Collections;

public class HPhandler : MonoBehaviour {

	public bool canMine = false;
	public float miningDelay;
	public float miningTimer;
	public bool mining = false;
	public int wallStrength = 3;

	// Use this for initialization
	void Start () 
	{
		miningTimer = miningDelay;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (canMine == true && Input.GetKeyDown(KeyCode.E) && miningTimer == miningDelay)
		{
			mining = true;
		}
		
		if (mining == true)
		{
			miningTimer -= Time.deltaTime;
			
			//wallstrength moet misschien per muur in een script oid, anders destroy je alle muren tegelijk
			if (miningTimer <= 0.0f)
			{
				//Destroy (c.gameObject);
				miningTimer = miningDelay;
				mining = false;
			}
		}
		//print (canMine);
		
		//print (miningTimer);
	}

	public void OnTriggerEnter (Collider c)
	{
		if (c.tag == "BreakWall")
		{
			canMine = true;
		}
	}

	public void OnTriggerExit (Collider c)
	{
		if (c.tag == "BreakWall")
		{
			canMine = false;
		}
	}


}
