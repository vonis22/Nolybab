using UnityEngine;
using System.Collections;

public class SeeNolybab : MonoBehaviour {

	public Transform nolyFab;
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
		//Vector3 fwd = transform.TransformDirection(Vector3.forward);
		Vector3 fwd = nolyFab.position;

		if (Physics.Raycast(transform.position, fwd, 10))
		{
			print("There is something in front of the object!");
		}

//		if (GeometryUtility.TestPlanesAABB(planes, nolyCollider.bounds))
//		{
//			print (nolyFab.name + " has been detected!");
//		}
//		else
//		{
//			print ("Nothing has been detected");
//		}
	}
}
