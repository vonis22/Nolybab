using UnityEngine;
using System.Collections;

public class FPSvr1Singleton : MonoBehaviour
{
	private static FPSvr1Singleton _instance;
	
	void Awake()
	{
		//if we don't have an [_instance] set yet
		if (!_instance)
		{
			_instance = this;
			this.name = "FPSController - VR11";
			
		}
		//otherwise, if we do, kill this thing
		else
		{
			Destroy(GameObject.Find ("FPSController - VR 1"));
		}
		
		DontDestroyOnLoad(this.gameObject) ;
	}
}	