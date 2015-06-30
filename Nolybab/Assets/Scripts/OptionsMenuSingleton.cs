using UnityEngine;
using System.Collections;

public class OptionsMenuSingleton : MonoBehaviour
{
	private static OptionsMenuSingleton _instance;
	
	void Awake()
	{
		//if we don't have an [_instance] set yet
		if (!_instance)
		{
			_instance = this;
			this.name = "StartOptions1";
			
		}
		//otherwise, if we do, kill this thing
		else
		{
			Destroy(GameObject.Find ("StartOptions"));
		}
		
		DontDestroyOnLoad(this.gameObject) ;
	}
}