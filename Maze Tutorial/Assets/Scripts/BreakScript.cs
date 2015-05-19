using UnityEngine;
using System.Collections;

public class BreakScript : MonoBehaviour {

	public int hp = 5;
	public GameObject col1 = null;
	public HPhandler script;
	public GameObject textMesh1;
	private TextMesh textMesh2;
	public int damage = 1;
	private int roundMineTimerRead = 1;

	void Update () 
	{
		textMesh1.GetComponent<TextMesh> ().text = hp.ToString();
		//textMesh2.text = hp.ToString();
		if (hp <= 0)
		{
			//Brokkel af animatie
			Destroy(transform.parent.gameObject);
		}
		//print (roundMineTimerRead);
	}

	void OnTriggerEnter (Collider c)
	{
		if (c.tag == "Pickaxe")
		{
			col1 = GameObject.FindGameObjectWithTag("Pickaxe");
			print("hak");
			hp -= damage;
			//PlaySound
			//PlayParticle Animation

//			if (roundMineTimerRead == 0)
//			{
//				hp -= damage;
//			}
		}
		else
		{
			col1 = null;
		}
		//roundMineTimerRead = col1.GetComponent<HPhandler> ().roundMineTimer;

		//print (col1.GetComponent<HPhandler> ().roundMineTimer);

	}


}
