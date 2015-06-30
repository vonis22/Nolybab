using UnityEngine;
using System.Collections;

public class FPSControllerSingleton : MonoBehaviour
{
	private static FPSControllerSingleton _instance;
	
	void Awake()
	{
		//if we don't have an [_instance] set yet
		if (!_instance)
		{
			_instance = this;
			this.name = "FPSController1";
			
		}
		//otherwise, if we do, kill this thing
		else
		{
			Destroy(GameObject.Find ("FPSController"));
		}
		
		DontDestroyOnLoad(this.gameObject) ;
	}
}