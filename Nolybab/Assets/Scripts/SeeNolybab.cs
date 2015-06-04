using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class SeeNolybab : MonoBehaviour {


//	public Collider nolyCollider;
//	private Camera cam;
//	private Plane[] planes;
	public GameObject nolyFab;
	private Camera cam;
	public bool nolybabIsVisible;
	private Camera FPScontrollerFabCam;
	private MotionBlur motionControl;
	public float fovTimer;
	void Start () 
	{
		nolyFab = GameObject.FindGameObjectWithTag ("Nolybab");
		cam = GetComponent<Camera> ();
		FPScontrollerFabCam = GameObject.FindGameObjectWithTag ("Player").transform.GetChild (0).GetComponent<Camera>();
		motionControl = GameObject.FindGameObjectWithTag ("Player").transform.GetChild (0).GetComponent<MotionBlur> ();
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
			if(hit.collider.tag == ("GameOver"))
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
			// Effects apply as well...
			if (FPScontrollerFabCam.fieldOfView < 120)
			{
				FPScontrollerFabCam.fieldOfView += 50 * Time.deltaTime;
				if (motionControl.blurAmount < 0.8f){
					motionControl.blurAmount += Time.deltaTime;
				}
			}
			else
			{
				FPScontrollerFabCam.fieldOfView = 120;
				motionControl.blurAmount = 0.8f;
			}
			print("Je ziet Nolybab");

		}
		else
		{
			//MotionBlur Regeneration
			if (motionControl.blurAmount > 0)
			{
				motionControl.blurAmount -= Time.deltaTime;
			}
			if (motionControl.blurAmount <= 0)
			{
				motionControl.blurAmount = 0;
			}

			// Field of view Regeneration
			if (FPScontrollerFabCam.fieldOfView > 75)
			{
				FPScontrollerFabCam.fieldOfView -= 10 * Time.deltaTime;
			}
			if (FPScontrollerFabCam.fieldOfView <= 75)
			{ 
				FPScontrollerFabCam.fieldOfView = 75;
			}
		}
		//print (FPScontrollerFabCam.fieldOfView);
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
