using UnityEngine;
using System.Collections;

public class SeeNolybab : MonoBehaviour {

	public float interval =2.5f;
	private GameObject nolyFab;

//	public Collider nolyCollider;
//	private Camera cam;
//	private Plane[] planes;




	void Start () 
	{

		//		cam = GetComponent<Camera>();
//		planes = GeometryUtility.CalculateFrustumPlanes (cam);
//		nolyCollider = nolyFab.GetComponent<Collider> ();
	}

	void Update () 
	{
		CanSeeEnemy ();
		//Vector3 fwd = transform.TransformDirection(Vector3.forward);
		//Vector3 fwd = nolyFab.position;

	//	if (Physics.Raycast(transform.position, fwd, 10))
	//	{
	//		print("There is something in front of the object!");
	//	}

//		if (GeometryUtility.TestPlanesAABB(planes, nolyCollider.bounds))
//		{
//			print (nolyFab.name + " has been detected!");
//		}
//		else
//		{
//			print ("Nothing has been detected");
//		}
	}

	void CanSeeEnemy()
	{
		Vector3 here = transform.position;
	}
}
