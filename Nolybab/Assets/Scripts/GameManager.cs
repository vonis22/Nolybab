using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Maze mazePrefab;
	public Maze mazeInstance;
	public GameObject playerPrefab;

	public float floorTimer = 60.0f; 
	public static bool lockCursor;
	public void Start () 
	{
		// UNCOMMENT onderste line voor locked cursor
		//Screen.lockCursor = true;
		Physics.IgnoreLayerCollision (10, 11);
		
		BeginGame();
	}
	
	public void Update () 
	{
		floorTimer -= Time.deltaTime;
		//print (floorTimer);

		if (Input.GetKeyDown(KeyCode.F1)) 
		{
			RestartGame();
		}
	}

	private void BeginGame () 
	{
		mazeInstance = Instantiate(mazePrefab) as Maze;
		//StartCoroutine(mazeInstance.Generate());
		mazeInstance.Generate ();
	}

	private void RestartGame () 
	{
		//StopAllCoroutines();
		Destroy(mazeInstance.gameObject);
		BeginGame();
	}
}