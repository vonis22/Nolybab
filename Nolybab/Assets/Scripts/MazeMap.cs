using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class MazeMap : MonoBehaviour
{
	public Rect rect;
	public Material matWallMap;
	public Material matThinkMap;
	Texture2D texture;

	public float sizeMaze;
	//public Maze mazeSize;
	//public float orthographicSize;

	void Start()
	{
		//GameObject m = GameObject.FindGameObjectsWithTag ("Maze");
		//mazeSize = m.GetComponent<Maze>();
		GetComponent<Camera>().pixelRect = rect;
		texture = new Texture2D((int)rect.width,(int)rect.height,TextureFormat.ARGB32,false);
		matWallMap.mainTexture = texture;
		matThinkMap.mainTexture = texture;
		//GetComponent<Camera>().orthographicSize = sizeMaze / 2.0f;
	}

	void Update()
	{
		//print (sizeMaze);
	}

	void OnPostRender()
	{
		texture.ReadPixels(rect,0,0);
		texture.Apply();
	}
}