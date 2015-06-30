using UnityEngine;
using System.Collections;

public class GameOptionsSingleton : MonoBehaviour
{
	private static GameOptionsSingleton _instance;
	
	void Awake()
	{
		//if we don't have an [_instance] set yet
		if (!_instance)
		{
			_instance = this;
			this.name = "Options1";
			
		}
		//otherwise, if we do, kill this thing
		else
		{
			Destroy(GameObject.Find ("Options"));
		}
		
		DontDestroyOnLoad(this.gameObject) ;
	}
}