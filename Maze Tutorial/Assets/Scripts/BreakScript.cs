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

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		textMesh1.GetComponent<TextMesh> ().text = hp.ToString();
		//textMesh2.text = hp.ToString();
		if (hp <= 0)
		{
			Destroy(transform.parent.gameObject);
		}
		//print (roundMineTimerRead);
	
	}
	void OnTriggerStay (Collider c)
	{

		if (c.tag == "Pickaxe")
		{
			col1 = GameObject.FindGameObjectWithTag("Pickaxe");
			print("hak");
			if (roundMineTimerRead == 0)
			{
				hp -= damage;
			}
		}
		else
		{
			col1 = null;
		}
		//roundMineTimerRead = col1.GetComponent<HPhandler> ().roundMineTimer;

		//print (col1.GetComponent<HPhandler> ().roundMineTimer);

	}


}
