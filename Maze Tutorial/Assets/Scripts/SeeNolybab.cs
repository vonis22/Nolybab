using UnityEngine;
using System.Collections;

public class SeeNolybab : MonoBehaviour {


//	public Collider nolyCollider;
//	private Camera cam;
//	private Plane[] planes;
	public GameObject nolyFab;
	private Camera cam;
	public bool nolybabIsVisible;
	private Camera FPScontrollerFabCam;
	public float fovTimer;
	void Start () 
	{
		nolyFab = GameObject.FindGameObjectWithTag ("Nolybab");
		cam = GetComponent<Camera> ();
		FPScontrollerFabCam = GameObject.FindGameObjectWithTag ("Player").transform.GetChild (0).GetComponent<Camera>();
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
				//FPScontrollerFabCam.fieldOfView = 75;
			}
		   }
		if (nolybabIsVisible)
		{
			//Fov of the player changes when he sees Nolybab
			FPScontrollerFabCam.fieldOfView += 10 * Time.deltaTime;

			print("Je ziet Nolybab");

		}
		print (FPScontrollerFabCam.fieldOfView);
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
		nolybabIsVisible = true;
	}
}
