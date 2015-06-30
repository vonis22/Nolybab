using UnityEngine;
using System.Collections;

public class ControlsSingleton : MonoBehaviour
{
	private static ControlsSingleton _instance;
	
	void Awake()
	{
		//if we don't have an [_instance] set yet
		if (!_instance)
		{
			_instance = this;
			this.name = "Controls1";
			
		}
		//otherwise, if we do, kill this thing
		else
		{
			Destroy(GameObject.Find ("Controls"));
		}
		
		DontDestroyOnLoad(this.gameObject) ;
	}
}