using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Maze mazePrefab;

	public Maze mazeInstance;

	public void Start () {
		BeginGame();
	}
	
	public void Update () {
		if (Input.GetKeyDown(KeyCode.F1)) {
			RestartGame();
		}
	}

	private void BeginGame () {
		mazeInstance = Instantiate(mazePrefab) as Maze;
		//StartCoroutine(mazeInstance.Generate());
		mazeInstance.Generate ();
	}

	private void RestartGame () {
		//StopAllCoroutines();
		Destroy(mazeInstance.gameObject);
		BeginGame();
	}
}