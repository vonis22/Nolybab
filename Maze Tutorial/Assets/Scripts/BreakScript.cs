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

	//AudioClips
	public AudioClip breakSound_0;
	public AudioClip breakSound_1;
	public AudioClip breakSound_2;
	public AudioClip breakSound_3;
	public AudioClip breakSound_4;
	public AudioClip breakSound_5;
	public AudioClip breakSound_6;
	public AudioClip breakSound_7;


	void Start ()
	{
	}
	void Update () 
	{

		textMesh1.GetComponent<TextMesh> ().text = hp.ToString();
		//textMesh2.text = hp.ToString();
		if (hp <= 0)
		{
			StartCoroutine (crumbleKill ());
			//Brokkel af animatie
		}

		//print (roundMineTimerRead);
	}
	IEnumerator crumbleKill()
	{
		yield return new WaitForSeconds (2);
		Destroy(transform.parent.gameObject);
	}

	void OnTriggerEnter (Collider c)
	{
		if (c.tag == "Pickaxe")
		{
			col1 = GameObject.FindGameObjectWithTag("Pickaxe");
			print("hak");
			hp -= damage;
			GetComponent<AudioSource> ().clip = breakSound_0;
			GetComponent<AudioSource>().Play();
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
