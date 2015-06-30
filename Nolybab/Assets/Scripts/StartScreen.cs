using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
	public GameObject OptionHandler;
	public GameObject LoadingScreen;
	public GameObject Sounds;
	public GameObject Options;
	public GameObject Controls;
	public GameObject Graphics;
	public GameObject Audio;
	public GameObject FPSController;
	public GameObject OculusController;

	void Awake ()
	{
		DontDestroyOnLoad (OptionHandler);
		DontDestroyOnLoad (Sounds);
		DontDestroyOnLoad (Options);
		DontDestroyOnLoad (Controls);
		DontDestroyOnLoad (Graphics);
		DontDestroyOnLoad (Audio);
		DontDestroyOnLoad (LoadingScreen);
		DontDestroyOnLoad (FPSController);
		DontDestroyOnLoad (OculusController);
	}
}