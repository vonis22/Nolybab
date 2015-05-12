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

	[Range(0f, 1f)]
	public float doorProbability;

	public MazeWall[] wallPrefabs;
	public List<MazeCell> activeCells;// = new List<MazeCell>();
	public MazeCell[,] cells;
	private bool playerSpawned = false;

	private Transform firstChild;
	private Transform lastChild;
	public Transform lastChildChild;
	private Vector3 firstChildCoords;
	private Vector3 lastChildCoords;
	public GameObject stairsPrefab;
	public GameObject endStairs;

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

		cameraChange = mapCam.GetComponent<MazeMap>();
		firstChild = transform.GetChild(0);
		lastChildChild = transform.GetChild ((size.x * size.z) - 1).GetChild (0);
		Destroy (lastChildChild.gameObject);
		lastChild = transform.GetChild ((size.x * size.z) - 1);
		firstChildCoords = firstChild.transform.position;
		lastChildCoords = lastChild.transform.position;
		Instantiate (stairsPrefab, firstChildCoords, Quaternion.identity);
		Instantiate (endStairs, lastChildCoords, Quaternion.identity);

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
		Instantiate (playerPrefab,firstChildCoords,Quaternion.identity);
		cameraChange.GetComponent<Camera>().orthographicSize = size.x / 2.0f;
		Instantiate (mapCam);

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

		print (firstChild);
		print (lastChild);
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