using UnityEngine;
using System.Collections;

public class SoundsSingleton : MonoBehaviour
{
	private static SoundsSingleton _instance;
	
	void Awake()
	{
		//if we don't have an [_instance] set yet
		if (!_instance)
		{
			_instance = this;
			this.name = "Sounds1";
			
		}
		//otherwise, if we do, kill this thing
		else
		{
			Destroy(GameObject.Find ("Sounds"));
		}
		
		DontDestroyOnLoad(this.gameObject) ;
	}
}