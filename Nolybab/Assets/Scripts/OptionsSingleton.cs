using UnityEngine;
using System.Collections;

public class OptionsSingleton : MonoBehaviour
{
	private static OptionsSingleton _instance;

	void Awake()
	{
		//if we don't have an [_instance] set yet
		if (!_instance)
		{
			_instance = this;
			this.name = "OptionHandler1";

		}
		//otherwise, if we do, kill this thing
		else
		{
			Destroy(GameObject.Find ("OptionHandler"));
		}
		
		DontDestroyOnLoad(this.gameObject) ;
	}
}