using UnityEngine;
using System.Collections;

public class GraphicsSingleton : MonoBehaviour
{
	private static GraphicsSingleton _instance;
	
	void Awake()
	{
		//if we don't have an [_instance] set yet
		if (!_instance)
		{
			_instance = this;
			this.name = "Graphics1";
			
		}
		//otherwise, if we do, kill this thing
		else
		{
			Destroy(GameObject.Find ("Graphics"));
		}
		
		DontDestroyOnLoad(this.gameObject) ;
	}
}