using UnityEngine;
using System.Collections;

public class AudioSingleton : MonoBehaviour
{
	private static AudioSingleton _instance;
	
	void Awake()
	{
		//if we don't have an [_instance] set yet
		if (!_instance)
		{
			_instance = this;
			this.name = "Audio1";
			
		}
		//otherwise, if we do, kill this thing
		else
		{
			Destroy(GameObject.Find ("Audio"));
		}
		
		DontDestroyOnLoad(this.gameObject) ;
	}
}	