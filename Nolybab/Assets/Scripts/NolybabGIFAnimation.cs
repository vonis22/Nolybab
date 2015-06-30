using UnityEngine;
using System.Collections;

public class NolybabGIFAnimation : MonoBehaviour {

	public GameObject Noly_0;
	public GameObject Noly_1;
	public GameObject Noly_2;
	public GameObject Noly_3;
	public GameObject Noly_4;


	void Start () 
	{
		StartCoroutine (animationTimer ());
	}

	IEnumerator animationTimer()
	{
		Noly_0.SetActive (true);
		Noly_1.SetActive (false);
		Noly_2.SetActive (false);
		Noly_3.SetActive (false);
		Noly_4.SetActive (false);
		yield return new WaitForSeconds (0.1f);
		Noly_0.SetActive (false);
		Noly_1.SetActive (true);
		Noly_2.SetActive (false);
		Noly_3.SetActive (false);
		Noly_4.SetActive (false);
		yield return new WaitForSeconds (0.1f);		
		Noly_0.SetActive (false);
		Noly_1.SetActive (false);
		Noly_2.SetActive (true);
		Noly_3.SetActive (false);
		Noly_4.SetActive (false);
		yield return new WaitForSeconds (0.1f);		
		Noly_0.SetActive (false);
		Noly_1.SetActive (false);
		Noly_2.SetActive (false);
		Noly_3.SetActive (true);
		Noly_4.SetActive (false);
		yield return new WaitForSeconds (0.1f);		
		Noly_0.SetActive (false);
		Noly_1.SetActive (false);
		Noly_2.SetActive (false);
		Noly_3.SetActive (false);
		Noly_4.SetActive (true);
		yield return new WaitForSeconds (0.1f);
		StartCoroutine (animationTimer ());
	}
}
