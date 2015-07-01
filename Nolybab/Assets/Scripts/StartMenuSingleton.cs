using UnityEngine;
using System.Collections;

public class StartMenuSingleton : MonoBehaviour
{
	private static StartMenuSingleton _instance;
	
	void Awake()
	{

		//if we don't have an [_instance] set yet
		if (!_instance)
		{
			_instance = this;
			this.name = "StartMenu1";
			
		}
		//otherwise, if we do, kill this thing
		else
		{
			Destroy(GameObject.Find ("StartMenu"));
		}
		
		DontDestroyOnLoad(this.gameObject) ;
	}
}