using UnityEngine;
using System.Collections;

public class SeeNolybab : MonoBehaviour {


//	public Collider nolyCollider;
//	private Camera cam;
//	private Plane[] planes;
	public GameObject nolyFab;
	private Camera cam;
	public bool nolybabIsVisible;

	void Start () 
	{
		nolyFab = GameObject.FindGameObjectWithTag ("Nolybab");
		cam = GetComponent<Camera> ();
		//		cam = GetComponent<Camera>();
//		planes = GeometryUtility.CalculateFrustumPlanes (cam);
//		nolyCollider = nolyFab.GetComponent<Collider> ();
	}

	void Update () 
	{
		RaycastHit hit;
		//Ray seeRay = new Ray (new Vector3(transform.position.x,transform.position.y,transform.position.z), Vector3.forward);
		Ray seeRay = new Ray (cam.transform.position, cam.transform.forward);
		Debug.DrawRay (cam.transform.position,cam.transform.forward);
		if(Physics.Raycast(seeRay, out hit))
		   {
			if(hit.collider.tag == ("Nolybab"))
			   {
					CanSeeEnemy();
			   }
			else 
			{
				nolybabIsVisible = false;
			}
		   }
		
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
		print("Je ziet Nolybab");
		nolybabIsVisible = true;
	}
}
