using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BreakScript : MonoBehaviour {

	public int hp = 5;
	public GameObject col1 = null;
	public GameObject textMesh1;
	private TextMesh textMesh2;
	public int damage = 1;
	private int roundMineTimerRead = 1;

	private HPhandler hpScript;

	//AudioClips
	public AudioClip breakSound_0;
	public AudioClip breakSound_1;
	public AudioClip breakSound_2;
	public AudioClip breakSound_3;
	public AudioClip breakSound_4;
	public AudioClip breakSound_5;
	public AudioClip breakSound_6;
	public AudioClip breakSound_7;
	public AudioClip SledgehammerSound;
	public AudioClip crumblingWall;

	//Array of the sounds
	public AudioClip[] breakSounds;

	void Start ()
	{
		StartCoroutine (checkHPScript ());
		breakSounds = new AudioClip[] {
			breakSound_0,
			breakSound_1,
			breakSound_2,
			breakSound_3,
			breakSound_4,
			breakSound_5,
			breakSound_6,
			breakSound_7
		};


	}

	IEnumerator checkHPScript ()
	{
		yield return new WaitForSeconds (0.1f);
		hpScript = GameObject.FindGameObjectWithTag("Player").GetComponent<HPhandler>();
	}
	void Update () 
	{
		textMesh1.GetComponent<TextMesh> ().text = hp.ToString();
		//textMesh2.text = hp.ToString();
		if (hp <= 0)
		{
			crumbleKill();
			//Brokkel af animatie
		}
	}

	void crumbleKill()
	{
		transform.parent.GetChild (1).gameObject.SetActive (false);
		GetComponent<Collider> ().enabled = false;
		Destroy(transform.parent.gameObject, crumblingWall.length);
	}

	void PlaySound()
	{
		if (hp > 0) {
			GetComponent<AudioSource> ().clip = breakSounds [Random.Range (5, breakSounds.Length)];
		} else {
			GetComponent<AudioSource> ().clip = crumblingWall;
		}

		GetComponent<AudioSource>().Play();

	}

	void OnTriggerEnter (Collider c)
	{
		if (c.tag == "Pickaxe")
		{
			//Wall gets damaged
			hp -= damage;

			//Sound will be played
			PlaySound();

			//Play Particle Animation
		}

		if (c.tag == "Sledgehammer")
		{
			//print ("Sledgehammer hit wall");
			//Wall gets damaged
			hp -= damage * 100;
			hpScript.hammerUses -= 0.5f;
			//Sound will be played
			GetComponent<AudioSource>().clip = SledgehammerSound;

			GetComponent<AudioSource>().Play();
			//Play Particle Animation
		}
	}
}
