using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
	public GameObject OptionHandler;
	public GameObject LoadingScreen;
	public GameObject Sounds;
	public GameObject Start;
	public GameObject Options;
	public GameObject Controls;
	public GameObject Graphics;
	public GameObject Audio;
	public GameObject Checkmark;
	public GameObject RenderDistance;
	public GameObject ShadowDistance;
	
	public bool toggleOptions = true;
	public bool showOptions = false;
	public bool showControls = false;
	public bool showGraphics = false;
	public bool showAudio = false;
	
	public AudioSource mouseClick;
	public AudioSource hoverSound;

	AudioSource StartTune;
	AudioSource StartTuneSource;
	
	public Slider masterVolumeSlider;
	public Slider musicVolumeSlider;
	public Slider effectVolumeSlider;

	void Awake ()
	{
		DontDestroyOnLoad (OptionHandler);
		DontDestroyOnLoad (Sounds);
		DontDestroyOnLoad (Options);
		DontDestroyOnLoad (Controls);
		DontDestroyOnLoad (Graphics);
		DontDestroyOnLoad (Audio);
		DontDestroyOnLoad (LoadingScreen);

//		StartTune = GameObject.Find ("Start Tune").GetComponent<AudioSource> ();
//		StartTuneSource = GameObject.Find ("Startup Music").GetComponent<AudioSource> ();
//		StartTune.clip = StartTuneSource.clip;
//		StartTune.volume = StartTuneSource.volume;
	}

//	void Update ()
//	{
////		if (Input.GetKeyDown (KeyCode.Escape))
////		{
////			if (showOptions == false && toggleOptions == true)
////			{
////				Options.SetActive (true);
////				showOptions = true;
////				toggleOptions = false;
////			} 
////			else if(showOptions == true && toggleOptions == false)
////			{
////				Options.SetActive (false);
////				showOptions = false;
////				toggleOptions = true;
////			}
////			
////			if(showControls == true)
////			{
////				Controls.SetActive (false);
////				showOptions = false;
////				showControls = false;
////				toggleOptions = true;
////			}
////			
////			if(showGraphics == true)
////			{
////				Graphics.SetActive (false);
////				showOptions = false;
////				showGraphics = false;
////				toggleOptions = true;
////			}
////			
////			if(showAudio == true)
////			{
////				Audio.SetActive (false);
////				showOptions = false;
////				showAudio = false;
////				toggleOptions = true;
////			}
////		}
//	}
//
//	public void OptionsScreen ()
//	{
//		if (showOptions == false && toggleOptions == true)
//		{
//			Options.SetActive (true);
//			showOptions = true;
//			toggleOptions = false;
//		} 
//	}
//	
//	public void Hover ()
//	{
//		hoverSound.Play ();
//	}
//	
//	public void ControlOptions ()
//	{
//		Options.SetActive (false);
//		Controls.SetActive (true);
//		showOptions = false;
//		showControls = true;
//		
//		mouseClick.Play ();
//	}
//	
//	public void SensitivityOptions (float sensitivity)
//	{
//		//GameObject slider = GameObject.Find ("Player");
//		//FirstPersonController script = slider.GetComponent<FirstPersonController>();
//		//script.sensitivity = sensitivity;
//	}
//	
//	public void GraphicOptions ()
//	{
//		Options.SetActive (false);
//		Graphics.SetActive (true);
//		showOptions = false;
//		showGraphics = true;
//		
//		mouseClick.Play ();
//	}
//	
//	public void QualityOptions (int Quality)
//	{
//		QualitySettings.SetQualityLevel (Quality,true);
//		int qualityLevel = QualitySettings.GetQualityLevel ();
//		
//		if(qualityLevel == 5)
//		{
//			QualitySettings.SetQualityLevel (6,true);
//			
//			if (QualitySettings.masterTextureLimit != 0)
//			{
//				QualitySettings.masterTextureLimit = 0;
//			}
//			
//			if (QualitySettings.vSyncCount != 1);
//			{
//				QualitySettings.vSyncCount = 1;
//			}
//			
//			if (QualitySettings.antiAliasing != 2)
//			{
//				QualitySettings.antiAliasing = 2;
//			}
//	
////			if (Camera.main.farClipPlane != 10)
////			{
////				Camera.main.farClipPlane = 10;
////				RenderDistance.GetComponent<Slider>().value = 10;
////			}
//			
//			if (QualitySettings.shadowDistance != 150)
//			{
//				QualitySettings.shadowDistance = 150;
//				ShadowDistance.GetComponent<Slider>().value = 150;
//			}
//			
//			QualitySettings.SetQualityLevel (5,true);
//			
//			GameObject.Find("Quality Text").GetComponent<Text>().text = "High";
//			GameObject.Find("Texture Text").GetComponent<Text>().text = "High";
//			GameObject.Find("Setting Text").GetComponent<Text>().text = "2X";
//			Checkmark.SetActive(true);
//		}
//		
//		if(qualityLevel == 3)
//		{
//			QualitySettings.SetQualityLevel (6,true);
//			
//			if (QualitySettings.masterTextureLimit != 1)
//			{
//				QualitySettings.masterTextureLimit = 0;
//			}
//			
//			if (QualitySettings.vSyncCount != 1);
//			{
//				QualitySettings.vSyncCount = 1;
//			}
//			
//			if (QualitySettings.antiAliasing != 2)
//			{
//				QualitySettings.antiAliasing = 2;
//			}
//			
////			if (Camera.main.farClipPlane != 10)
////			{
////				Camera.main.farClipPlane = 10;
////				RenderDistance.GetComponent<Slider>().value = 10;
////			}
//			
//			if (QualitySettings.shadowDistance != 40)
//			{
//				QualitySettings.shadowDistance = 40;
//				ShadowDistance.GetComponent<Slider>().value = 40;
//			}
//			
//			QualitySettings.SetQualityLevel (3,true);
//			
//			GameObject.Find("Quality Text").GetComponent<Text>().text = "Medium";
//			GameObject.Find("Texture Text").GetComponent<Text>().text = "Medium";
//			GameObject.Find("Setting Text").GetComponent<Text>().text = "None";
//			Checkmark.SetActive(true);
//		}
//		
//		if(qualityLevel == 0)
//		{
//			QualitySettings.SetQualityLevel (6,true);
//			
//			if (QualitySettings.masterTextureLimit != 0)
//			{
//				QualitySettings.masterTextureLimit = 2;
//			}
//			
//			if (QualitySettings.vSyncCount != 0);
//			{
//				QualitySettings.vSyncCount = 0;
//			}
//			
//			if (QualitySettings.antiAliasing != 0)
//			{
//				QualitySettings.antiAliasing = 0;
//			}
//			
////			if (Camera.main.farClipPlane != 5)
////			{
////				Camera.main.farClipPlane = 5;
////				RenderDistance.GetComponent<Slider>().value = 5;
////			}
//			
//			if (QualitySettings.shadowDistance != 15)
//			{
//				QualitySettings.shadowDistance = 15;
//				ShadowDistance.GetComponent<Slider>().value = 15;
//			}
//			
//			QualitySettings.SetQualityLevel (0,true);
//			
//			GameObject.Find("Quality Text").GetComponent<Text>().text = "Low";
//			GameObject.Find("Texture Text").GetComponent<Text>().text = "Low";
//			GameObject.Find("Setting Text").GetComponent<Text>().text = "None";
//			Checkmark.SetActive(false);
//		}
//	}
//	
//	public void TextureQualityOptions (int textureQuality)
//	{
//		QualitySettings.SetQualityLevel (6,true);
//		QualitySettings.masterTextureLimit = textureQuality;
//		
//		if(QualitySettings.masterTextureLimit == 0)
//		{
//			GameObject.Find("Texture Text").GetComponent<Text>().text = "High";
//			GameObject.Find("Quality Text").GetComponent<Text>().text = "Custom";
//		}
//		
//		if(QualitySettings.masterTextureLimit == 1)
//		{
//			GameObject.Find("Texture Text").GetComponent<Text>().text = "Medium";
//			GameObject.Find("Quality Text").GetComponent<Text>().text = "Custom";
//		}
//		
//		if(QualitySettings.masterTextureLimit == 2)
//		{
//			GameObject.Find("Texture Text").GetComponent<Text>().text = "Low";
//			GameObject.Find("Quality Text").GetComponent<Text>().text = "Custom";
//		}
//	}
//	
//	public void VSyncOptions ()
//	{
//		QualitySettings.SetQualityLevel (6,true);
//		
//		if( QualitySettings.vSyncCount == 1)
//		{
//			QualitySettings.vSyncCount = 0;
//			Checkmark.SetActive(false);
//			GameObject.Find("Quality Text").GetComponent<Text>().text = "Custom";
//		}
//		else if (QualitySettings.vSyncCount == 0)
//		{
//			QualitySettings.vSyncCount = 1;
//			Checkmark.SetActive(true);
//			GameObject.Find("Quality Text").GetComponent<Text>().text = "Custom";
//		}
//	}
//	
//	public void AntiAliasingOptions (int antiAliasing)
//	{
//		QualitySettings.SetQualityLevel (6,true);
//		QualitySettings.antiAliasing = antiAliasing;
//		
//		if(QualitySettings.antiAliasing == 0)
//		{
//			GameObject.Find("Setting Text").GetComponent<Text>().text = "None";
//			GameObject.Find("Quality Text").GetComponent<Text>().text = "Custom";
//		}
//		
//		if(QualitySettings.antiAliasing == 2)
//		{
//			GameObject.Find("Setting Text").GetComponent<Text>().text = "2X";
//			GameObject.Find("Quality Text").GetComponent<Text>().text = "Custom";
//		}
//		
//		if(QualitySettings.antiAliasing == 4)
//		{
//			GameObject.Find("Setting Text").GetComponent<Text>().text = "4X";
//			GameObject.Find("Quality Text").GetComponent<Text>().text = "Custom";
//		}
//		
//		if(QualitySettings.antiAliasing == 8)
//		{
//			GameObject.Find("Setting Text").GetComponent<Text>().text = "8X";
//			GameObject.Find("Quality Text").GetComponent<Text>().text = "Custom";
//		}
//	}
//	
//	public void RenderDistanceOptions (float renderDistance)
//	{
//		QualitySettings.SetQualityLevel (6,true);
//		Camera.main.farClipPlane = renderDistance;
//		GameObject.Find("Quality Text").GetComponent<Text>().text = "Custom";
//	}
//	
//	public void ShadowDistanceOptions (float shadowDistance)
//	{
//		QualitySettings.SetQualityLevel (6,true);
//		QualitySettings.shadowDistance = shadowDistance;
//		GameObject.Find("Quality Text").GetComponent<Text>().text = "Custom";
//	}
//	
//	public void AudioOptions ()
//	{
//		Options.SetActive (false);
//		Audio.SetActive (true);
//		showOptions = false;
//		showAudio = true;
//		
//		mouseClick.Play ();
//	}
//	
//	public void ChangeMasterVolume ()
//	{
//		if (masterVolumeSlider.value != 0)
//		{
//			musicVolumeSlider.maxValue = masterVolumeSlider.value;
//			effectVolumeSlider.maxValue = masterVolumeSlider.value;
//			
//			if(masterVolumeSlider.value != 100)
//			{
//				musicVolumeSlider.value = masterVolumeSlider.value;
//				effectVolumeSlider.value = masterVolumeSlider.value;
//			}
//		}
//	}
//	
//	public void Back ()
//	{
//		if (showOptions)
//		{
//			Options.SetActive (false);
//			showOptions = false;
//			toggleOptions = true;
//			Start.SetActive (true);
//			
//			mouseClick.Play ();
//		}
//		
//		if (showControls)
//		{
//			Controls.SetActive (false);
//			Options.SetActive (true);
//			showOptions = true;
//			showControls = false;
//			
//			mouseClick.Play ();
//		}
//		
//		if (showGraphics)
//		{
//			Graphics.SetActive (false);
//			Options.SetActive (true);
//			showOptions = true;
//			showGraphics = false;
//			
//			mouseClick.Play ();
//		}
//		
//		if (showAudio)
//		{
//			Audio.SetActive (false);
//			Options.SetActive (true);
//			showOptions = true;
//			showAudio = false;
//			
//			mouseClick.Play ();
//		}
//	}
	
//	public void Play ()
//	{
//		LoadingScreen.SetActive (true);
//		Application.LoadLevel ("Scene");
//		mouseClick.Play ();
//	}
//	
//	public void Tutorial ()
//	{
//		LoadingScreen.SetActive (true);
//		Application.LoadLevel ("Tutorial");
//		mouseClick.Play ();
//	}
//	
//	public void QuitGame ()
//	{
//		Application.Quit ();
//		mouseClick.Play ();
//	}

//	void OnLevelWasLoaded(int level)
//	{
//		if (level == 3)
//		{
//			LoadingScreen.SetActive (false);
//		}
//
//		if (level == 1)
//		{
//			LoadingScreen.SetActive (false);
//		}
//	}
}