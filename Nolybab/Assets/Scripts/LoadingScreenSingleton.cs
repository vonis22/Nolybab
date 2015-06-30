using UnityEngine;
using System.Collections;

public class LoadingScreenSingleton : MonoBehaviour
{
	private static LoadingScreenSingleton _instance;
	
	void Awake()
	{
		//if we don't have an [_instance] set yet
		if (!_instance)
		{
			_instance = this;
			this.name = "Loading Screen1";
			
		}
		//otherwise, if we do, kill this thing
		else
		{
			Destroy(GameObject.Find ("Loading Screen"));
		}
		
		DontDestroyOnLoad(this.gameObject) ;
	}
}