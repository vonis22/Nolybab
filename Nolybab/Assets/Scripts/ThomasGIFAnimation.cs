using UnityEngine;
using System.Collections;

public class ThomasGIFAnimation : MonoBehaviour {

	public GameObject ThomasStillFab;
	public GameObject ThomasRun_1Fab;
	public GameObject ThomasRun_2Fab;

	void Start () 
	{
		StartCoroutine (animationTimer ());
	}

	IEnumerator animationTimer()
	{
			ThomasStillFab.SetActive (true);
			ThomasRun_1Fab.SetActive (false);
			ThomasRun_2Fab.SetActive (false);
			yield return new WaitForSeconds (0.1f);
			ThomasStillFab.SetActive (false);
			ThomasRun_1Fab.SetActive (true);
			ThomasRun_2Fab.SetActive (false);
			yield return new WaitForSeconds (0.1f);
			ThomasStillFab.SetActive (false);
			ThomasRun_1Fab.SetActive (false);
			ThomasRun_2Fab.SetActive (true);
			yield return new WaitForSeconds (0.1f);
			StartCoroutine (animationTimer ());
	}
}
