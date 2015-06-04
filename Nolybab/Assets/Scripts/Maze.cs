using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Maze : MonoBehaviour {

	public MazeMap cameraChange;
	public GameObject mapCam;

	public IntVector2 size;

	public MazeCell cellPrefab;

	public float generationStepDelay;

	public MazePassage passagePrefab;
	public GameObject playerPrefab;
	public MazeDoor doorPrefab;
	public GameObject A_prefab;
	[Range(0f, 1f)]
	public float doorProbability;

	public MazeWall[] wallPrefabs;
	public List<MazeCell> activeCells;// = new List<MazeCell>();
	public MazeCell[,] cells;
	private bool playerSpawned = false;

	private Transform firstChild;
	private Transform firstChildChild;
	public Transform lastChild;
	public Transform lastChildChild;

	private Vector3 firstChildCoords;
	private Vector3 lastChildCoords;
	private Vector3 nolyChildCoords;
	private Vector3 randomSpawnCoords;
	public Vector3 RandomPowerupCoordinates1;
	public Vector3 RandomPowerupCoordinates2;
	public Vector3 RandomPowerupCoordinates3;
	public Vector3 firstChildChildCoords;


	public GameObject nolyfab;
	public GameObject stairsPrefab;
	public GameObject endStairs;
	public GameObject powerUp1;
	public GameObject powerUp2;
	public GameObject powerUp3;
	public GameObject mapWallprefab;

	public IntVector2 RandomCoordinates {
		get {
			return new IntVector2(Random.Range(0, size.x), Random.Range(0, size.z));
		}
	}

	public bool ContainsCoordinates (IntVector2 coordinate) {
		return coordinate.x >= 0 && coordinate.x < size.x && coordinate.z >= 0 && coordinate.z < size.z;
	}

	public MazeCell GetCell (IntVector2 coordinates) {
		return cells[coordinates.x, coordinates.z];
	}

	public void Start()
	{
		RandomPowerupCoordinates1 = transform.GetChild(Random.Range (0, (size.x * size.z - 1))).transform.position;
		RandomPowerupCoordinates2 = transform.GetChild(Random.Range (0, (size.x * size.z - 1))).transform.position;
		RandomPowerupCoordinates3 = transform.GetChild(Random.Range (0, (size.x * size.z - 1))).transform.position;

		cameraChange = mapCam.GetComponent<MazeMap>();
		firstChild = transform.GetChild(0);
		firstChildChild = transform.GetChild(0).GetChild(6);
		firstChildChildCoords = transform.GetChild(0).GetChild(6).transform.position;
		lastChildChild = transform.GetChild ((size.x * size.z) - 1).GetChild (0);
		Destroy (lastChildChild.gameObject);
		lastChild = transform.GetChild ((size.x * size.z) - 1);
		firstChildCoords = firstChild.transform.position;
		lastChildCoords = lastChild.transform.position;
		nolyChildCoords = transform.GetChild ((size.x * size.z) -2).transform.position;
		Instantiate (stairsPrefab, firstChildCoords, Quaternion.identity);
		Instantiate (endStairs,new Vector3(lastChildCoords.x,(lastChildCoords.y - 0.055f),lastChildCoords.z), Quaternion.identity);

		Instantiate (powerUp1, RandomPowerupCoordinates1, Quaternion.identity);
		Instantiate (powerUp2, RandomPowerupCoordinates2, Quaternion.identity);
		Instantiate (powerUp3, RandomPowerupCoordinates3, Quaternion.identity);
	}

	public void Generate () 
	{
		//WaitForSeconds delay = new WaitForSeconds(generationStepDelay);

		cells = new MazeCell[size.x, size.z];
		activeCells = new List<MazeCell>();
		DoFirstGenerationStep(activeCells);
		while (activeCells.Count > 0) 
		{
			//yield return delay;
			DoNextGenerationStep(activeCells);
		}
	}

	public void SpawnPlayer()
	{
		//Instantiate (playerPrefab,firstChildCoords,Quaternion.identity);
		GameObject.FindGameObjectWithTag ("Player").transform.position = new Vector3(firstChildCoords.x,0.4f,firstChildCoords.z);
		cameraChange.GetComponent<Camera>().orthographicSize = size.x / 2.0f;
		Instantiate (mapCam);
		Instantiate (A_prefab);
		Instantiate (nolyfab, nolyChildCoords, Quaternion.identity);
		Destroy (firstChildChild.gameObject);
		Instantiate (mapWallprefab, firstChildChildCoords, Quaternion.identity);


	}
	private void DoFirstGenerationStep (List<MazeCell> activeCells) {

		activeCells.Add(CreateCell(RandomCoordinates));
	}

	private void DoNextGenerationStep (List<MazeCell> activeCells) {
		int currentIndex = activeCells.Count - 1;
		MazeCell currentCell = activeCells[currentIndex];
		if (currentCell.IsFullyInitialized) {
			activeCells.RemoveAt(currentIndex);
			return;
		}
		MazeDirection direction = currentCell.RandomUninitializedDirection;
		IntVector2 coordinates = currentCell.coordinates + direction.ToIntVector2();
		if (ContainsCoordinates(coordinates)) {
			MazeCell neighbor = GetCell(coordinates);
			if (neighbor == null) {
				neighbor = CreateCell(coordinates);
				CreatePassage(currentCell, neighbor, direction);
				activeCells.Add(neighbor);
			}
			else {
				CreateWall(currentCell, neighbor, direction);
			}
		}
		else {
			CreateWall(currentCell, null, direction);
		}
	}

	private MazeCell CreateCell (IntVector2 coordinates) {
		MazeCell newCell = Instantiate(cellPrefab) as MazeCell;
		cells[coordinates.x, coordinates.z] = newCell;
		newCell.coordinates = coordinates;
		newCell.name = "Maze Cell " + coordinates.x + ", " + coordinates.z;
		newCell.transform.parent = transform;
		newCell.transform.localPosition = new Vector3(coordinates.x - size.x * 0.5f + 0.5f, 0f, coordinates.z - size.z * 0.5f + 0.5f);
		return newCell;
	}
	
	public void Update ()
	{
		//int bound0 = cells.GetUpperBound (0);
		//int bound1 = cells.GetLowerBound (1);

		/*for (int i = 0; i <=bound0; i++)
		{
			for(int x = 0; x <= bound1; x++)
			{
				print (cells[i,1]);
			}
		}*/

	//	print (firstChild);
		//print (lastChild);
		//cameraChange.sizeMaze = size.x;
		//cameraChange.GetComponent<Camera>().orthographicSize = size.x / 2.0f;

		if ( activeCells.Count == 0 && playerSpawned == false)
		{
			SpawnPlayer();
			playerSpawned = true;
		}


	}

	private void CreatePassage (MazeCell cell, MazeCell otherCell, MazeDirection direction) {
		MazePassage prefab = Random.value < doorProbability ? doorPrefab : passagePrefab;
		MazePassage passage = Instantiate(prefab) as MazePassage;
		passage.Initialize(cell, otherCell, direction);
		passage = Instantiate(prefab) as MazePassage;
		passage.Initialize(otherCell, cell, direction.GetOpposite());
	}

	private void CreateWall (MazeCell cell, MazeCell otherCell, MazeDirection direction) {
		MazeWall wall = Instantiate(wallPrefabs[Random.Range(0, wallPrefabs.Length)]) as MazeWall;
		wall.Initialize(cell, otherCell, direction);
		if (otherCell != null) {
			wall = Instantiate(wallPrefabs[Random.Range(0, wallPrefabs.Length)]) as MazeWall;
			wall.Initialize(otherCell, cell, direction.GetOpposite());
		}
	}
}