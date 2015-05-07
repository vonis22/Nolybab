using UnityEngine;
using System.Collections;

public class BreakScript : MonoBehaviour {

	public int hp = 5;
	public GameObject col1 = null;
	public HPhandler script;
	public GameObject textMesh1;
	private TextMesh textMesh2;
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

	
	}
	void OnTriggerStay (Collider c)
	{
		if (c.tag == "Player")
		{
			col1 = GameObject.FindGameObjectWithTag("Player");

			if (col1.GetComponent<HPhandler>().miningTimer <= 0.02f)
			{
			hp -=1;
			}
		}
		else
		{
			col1 = null;
		}

		print (col1.GetComponent<HPhandler> ().miningTimer);

	}


}
