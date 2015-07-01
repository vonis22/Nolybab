using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class options : MonoBehaviour
{
	public GameObject Sounds;
	public GameObject StartMenu;
	public GameObject StartMenuButtons;
	public GameObject Options;
	public GameObject Controls;
	public GameObject Graphics;
	public GameObject Audio;
	public GameObject Checkmark;
	public GameObject RenderDistance;
	public GameObject ShadowDistance;
	public GameObject LoadingScreen;
	public GameObject StartOptions;
	public GameObject GameOptions;
	public GameObject Title;
	
	public GameObject FPSController;
	public GameObject OculusController;
	
	public bool toggleOptions = true;
	public bool showMenu = false;
	public bool showOptions = false;
	public bool showControls = false;
	public bool showGraphics = false;
	public bool showAudio = false;
	
	public AudioSource backgroundMusic;
	public AudioSource mouseClick;
	public AudioSource hoverSound;
	public AudioSource startTune;
	
	AudioSource BackgroundMusic;
	AudioSource LevelMusicSource;
	AudioSource ControllerSounds;
	AudioSource ControllerSource;
	AudioSource BreakWall;
	AudioSource BreakWallSource;
	AudioSource RealWall;
	AudioSource RealWallSource;
	AudioSource Powerup1Sound;
	AudioSource Powerup1Source;
	AudioSource Powerup2Sound;
	AudioSource Powerup2Source;
	AudioSource Powerup3Sound;
	AudioSource Powerup3Source;
	AudioSource TorchSound;
	AudioSource TorchSource;
	AudioSource NolybabSounds;
	AudioSource NolybabSource;
	AudioSource WatchMapSound;
	AudioSource WatchMapSource;
	AudioSource GameOverSound;
	AudioSource GameOverSource;
	
	AudioClip WatchMapSoundClip;
	
	public Slider masterVolumeSlider;
	public Slider musicVolumeSlider;
	public Slider effectVolumeSlider;
	
	public AudioClip[] backgroundMusicClip;
	public AudioClip backgroundMusicClip_0;
	public AudioClip backgroundMusicClip_1;
	public AudioClip backgroundMusicClip_2;
	
	public AudioClip backgroundMusicPart1;
	public AudioClip backgroundMusicPart2;
	
	bool secondClip = false;
	bool thirdClip = false;
	
	mapSound WatchMapScript;
	
	Tutorial script;
	SeeNolybab nolybabScript;
	FirstPersonController fpsScript;
	Tutorial tutorialScript;
	
	bool oculusCheck = false;
	public bool restarter = false;
	public bool reloader = false;
	
	public void Awake () 
	{
		OnLevelWasLoaded ();
	}
	
	public IEnumerator Seeker()
	{
		yield return new WaitForSeconds (0.1f);
		backgroundMusicClip = new AudioClip[] 
		{
			backgroundMusicClip_0,
			backgroundMusicClip_1,
			backgroundMusicClip_2,
		};
		
		BackgroundMusic = GameObject.Find ("Background Music").GetComponent<AudioSource> ();
		BackgroundMusic.clip = backgroundMusicClip [Random.Range (0, backgroundMusicClip.Length)];
		backgroundMusic = BackgroundMusic;
		backgroundMusic.volume = BackgroundMusic.volume;
		
		backgroundMusic.Play ();

		NolybabSounds = GameObject.Find ("Nolybab Sounds").GetComponent<AudioSource> ();
		NolybabSource = GameObject.Find ("Skull").GetComponent<AudioSource> ();
		NolybabSounds.clip = NolybabSource.clip;
		NolybabSource.volume = NolybabSounds.volume;

		foreach (AudioSource TorchSource in FindObjectsOfType(typeof(AudioSource)))
		{
			if (TorchSource.name == ("Fire_Wall_Torch"))
			{
				TorchSound = GameObject.Find ("Torch Sound").GetComponent<AudioSource> ();
				TorchSource.GetComponent<AudioSource> ();
				TorchSound.clip = TorchSource.clip;
				TorchSource.volume = TorchSound.volume;
				
				TorchSound.Play ();
			}
		}
		
		yield return new WaitForSeconds (backgroundMusic.clip.length);
		secondClip = true;
		
		if (secondClip)
		{
			backgroundMusic.clip = backgroundMusicPart1;
			backgroundMusic.Play ();
		}
		
		yield return new WaitForSeconds (backgroundMusic.clip.length);
		thirdClip = true;
		
		if (thirdClip)
		{
			backgroundMusic.clip = backgroundMusicPart2;
			backgroundMusic.loop = true;
			backgroundMusic.Play ();
		}
	}
	
	void OnLevelWasLoaded ()
	{
		if (Application.loadedLevel == 0)
		{
			StartOptions.SetActive (true);
			StartOptions.SetActive (false);
			GameOptions.SetActive (true);
			GameOptions.SetActive (false);
			Controls.SetActive (true);
			Controls.SetActive (false);
			Graphics.SetActive (true);
			Graphics.SetActive (false);
			Audio.SetActive (true);
			Audio.SetActive (false);
			LoadingScreen.SetActive (true);
			LoadingScreen.SetActive (false);
			OculusController.SetActive (true);
			OculusController.SetActive(false);
			FPSController.SetActive(true);
			FPSController.SetActive (false);
			
			StartMenu.SetActive (true);
			
			Options = StartOptions;
			Options.SetActive (true);
			Options.SetActive (false);
			
			startTune.Play ();
			
			StopAllCoroutines();
			
			//nolybabScript = GameObject.Find("FirstPersonCharacter").GetComponent<SeeNolybab>();
			//((SeeNolybab)nolybabScript.GetComponent<SeeNolybab>()).FPScontrollerFabCam.fieldOfView = 75;
		}
		
		if (Application.loadedLevel  == 1 || Application.loadedLevel  == 3)
		{
			Options = GameOptions;
			LoadingScreen.SetActive (false);
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			StartCoroutine (Seeker ());
		}
	}
	
	void Update ()
	{
		if (Application.loadedLevel == 0)
		{
			Title = GameObject.Find ("Title");
			
			if (!oculusCheck)
			{
				FPSController.SetActive (true);
				OculusController.SetActive (false);
				
				nolybabScript = GameObject.Find("FirstPersonCharacter").GetComponent<SeeNolybab>();
				((SeeNolybab)nolybabScript.GetComponent<SeeNolybab>()).enabled = false;
				
				fpsScript = GameObject.Find("FPSController1").GetComponent<FirstPersonController>();
				((FirstPersonController)fpsScript.GetComponent<FirstPersonController>()).enabled = false;
				
				Camera mainFCP = GameObject.Find("FirstPersonCharacter").GetComponent<Camera>();
				mainFCP.farClipPlane = RenderDistance.GetComponent<Slider>().value;
				
			}
			
			if (oculusCheck)
			{
				FPSController.SetActive (false);
				OculusController.SetActive(true);
				
				nolybabScript = GameObject.Find("LeftEyeAnchor").GetComponent<SeeNolybab>();
				((SeeNolybab)nolybabScript.GetComponent<SeeNolybab>()).enabled = false;
				
				nolybabScript = GameObject.Find("RightEyeAnchor").GetComponent<SeeNolybab>();
				((SeeNolybab)nolybabScript.GetComponent<SeeNolybab>()).enabled = false;
				
				fpsScript = GameObject.Find("FPSController - VR11").GetComponent<FirstPersonController>();
				((FirstPersonController)fpsScript.GetComponent<FirstPersonController>()).enabled = false;
				
				Camera leftEyeFCP = GameObject.Find("LeftEyeAnchor").GetComponent<Camera>();
				Camera rightEyeFCP = GameObject.Find("RightEyeAnchor").GetComponent<Camera>();
				
				leftEyeFCP.farClipPlane = RenderDistance.GetComponent<Slider>().value;
				rightEyeFCP.farClipPlane = leftEyeFCP.farClipPlane;
				
			}
		}
		
		if (Application.loadedLevel == 1 || Application.loadedLevel == 3)
		{
			if (!oculusCheck)
			{
				nolybabScript = GameObject.Find("FirstPersonCharacter").GetComponent<SeeNolybab>();
				((SeeNolybab)nolybabScript.GetComponent<SeeNolybab>()).enabled = true;
				
				fpsScript = GameObject.Find("FPSController1").GetComponent<FirstPersonController>();
				((FirstPersonController)fpsScript.GetComponent<FirstPersonController>()).enabled = true;
			}
			
			if (oculusCheck)
			{
				nolybabScript = GameObject.Find("LeftEyeAnchor").GetComponent<SeeNolybab>();
				((SeeNolybab)nolybabScript.GetComponent<SeeNolybab>()).enabled = true;
				
				nolybabScript = GameObject.Find("RightEyeAnchor").GetComponent<SeeNolybab>();
				((SeeNolybab)nolybabScript.GetComponent<SeeNolybab>()).enabled = true;
				
				fpsScript = GameObject.Find("FPSController - VR11").GetComponent<FirstPersonController>();
				((FirstPersonController)fpsScript.GetComponent<FirstPersonController>()).enabled = true;
			}
			
			foreach (AudioSource BreakWallSource in FindObjectsOfType(typeof(AudioSource)))
			{
				if (BreakWallSource.tag == ("BreakWall"))
				{
					BreakWall = GameObject.Find ("Break Wall").GetComponent<AudioSource> ();
					BreakWallSource.GetComponent<AudioSource> ();
					BreakWall.clip = BreakWallSource.clip;
					BreakWallSource.volume = BreakWall.volume;
				}
			}
			
			foreach (AudioSource RealWallSource in FindObjectsOfType(typeof(AudioSource)))
			{
				if (RealWallSource.tag == ("RealWall"))
				{
					RealWall = GameObject.Find ("Real Wall").GetComponent<AudioSource> ();
					RealWallSource.GetComponent<AudioSource> ();
					RealWall.clip = RealWallSource.clip;
					RealWallSource.volume = RealWall.volume;
				}
			}
			
			ControllerSounds = GameObject.Find ("Controller Sounds").GetComponent<AudioSource> ();
			ControllerSource = GameObject.FindWithTag ("Player").GetComponent<AudioSource> ();
			ControllerSounds.clip = ControllerSource.clip;
			ControllerSource.volume = ControllerSounds.volume;
			
			if (GameObject.Find ("Powerup 1(Clone)") != null)
			{
				Powerup1Sound = GameObject.Find ("Powerup 1 Sound").GetComponent<AudioSource> ();
				Powerup1Source = GameObject.Find ("Powerup 1(Clone)").GetComponent<AudioSource> ();
				Powerup1Sound.clip = Powerup1Source.clip;
				Powerup1Source.volume = Powerup1Sound.volume;
			}
			
			if (GameObject.Find ("Powerup 2(Clone)") != null)
			{
				Powerup2Sound = GameObject.Find ("Powerup 2 Sound").GetComponent<AudioSource> ();
				Powerup2Source = GameObject.Find ("Powerup 2(Clone)").GetComponent<AudioSource> ();
				Powerup2Sound.clip = Powerup2Source.clip;
				Powerup2Source.volume = Powerup2Sound.volume;
			}
			
			if (GameObject.Find ("Powerup 3(Clone)") != null)
			{
				Powerup3Sound = GameObject.Find ("Powerup 3 Sound").GetComponent<AudioSource> ();
				Powerup3Source = GameObject.Find ("Powerup 3(Clone)").GetComponent<AudioSource> ();
				Powerup3Sound.clip = Powerup3Source.clip;
				Powerup3Source.volume = Powerup3Sound.volume;
			}
			

			
			if (!oculusCheck)
			{
				WatchMapSound = GameObject.Find ("Watch Map Sound").GetComponent<AudioSource> ();
				WatchMapSource = GameObject.Find ("FirstPersonCharacter").GetComponent<AudioSource> ();
				WatchMapScript = GameObject.Find ("FirstPersonCharacter").GetComponent<mapSound> ();
				WatchMapSoundClip = WatchMapScript.mapSoundClip;
				WatchMapSound.clip = WatchMapSoundClip;
				WatchMapSource.volume = WatchMapSound.volume;
			}
			print(Time.timeScale);
			if (Input.GetKeyDown (KeyCode.Escape))
			{
				if (Time.timeScale == 1)
				{
					Time.timeScale = 0;
				}
				else 
				{
					Time.timeScale = 1;
				}

				if (showOptions == false && toggleOptions == true)
				{
					Cursor.lockState = CursorLockMode.None;
					Cursor.visible = true;
					
					Options.SetActive (true);
					showOptions = true;
					toggleOptions = false;
					
					backgroundMusic.Pause ();
					TorchSound.Pause ();
					foreach (GameObject Pause in FindObjectsOfType(typeof(GameObject)))
					{
						Time.timeScale = 0;
					}
					
					//Cursor.visible = true;
					//Screen.lockCursor = false;
				} else if (showOptions == true && toggleOptions == false)
				{
					Cursor.lockState = CursorLockMode.Locked;
					Cursor.visible = false;
					
					Options.SetActive (false);
					showOptions = false;
					toggleOptions = true;
					
					backgroundMusic.UnPause ();
					TorchSound.UnPause ();
					
					foreach (GameObject Pause in FindObjectsOfType(typeof(GameObject)))
					{
						Time.timeScale = 1;
					}
					
					//Cursor.visible = false;
					//Screen.lockCursor = true;
				}
				
				if (showControls == true)
				{
					Cursor.lockState = CursorLockMode.Locked;
					Cursor.visible = false;
					
					Controls.SetActive (false);
					showOptions = false;
					showControls = false;
					toggleOptions = true;
					
					backgroundMusic.UnPause ();
					TorchSound.UnPause ();
					
					foreach (GameObject Pause in FindObjectsOfType(typeof(GameObject)))
					{
						Time.timeScale = 1;
					}
					
					//Cursor.visible = false;
					//Screen.lockCursor = true;
				}
				
				if (showGraphics == true)
				{
					Cursor.lockState = CursorLockMode.Locked;
					Cursor.visible = false;
					
					Graphics.SetActive (false);
					showOptions = false;
					showGraphics = false;
					toggleOptions = true;
					
					backgroundMusic.UnPause ();
					TorchSound.UnPause ();
					
					foreach (GameObject Pause in FindObjectsOfType(typeof(GameObject)))
					{
						Time.timeScale = 1;
					}
					
					//Cursor.visible = false;
					//Screen.lockCursor = true;
				}
				
				if (showAudio == true)
				{
					Cursor.lockState = CursorLockMode.Locked;
					Cursor.visible = false;
					
					Audio.SetActive (false);
					showOptions = false;
					showAudio = false;
					toggleOptions = true;
					
					backgroundMusic.UnPause ();
					TorchSound.UnPause ();
					
					foreach (GameObject Pause in FindObjectsOfType(typeof(GameObject)))
					{
						Time.timeScale = 1;
					}
					
					//Cursor.visible = false;
					//Screen.lockCursor = true;
				}
			}
		}
		
		if (Application.loadedLevel == 3)
		{
			if (reloader)
			{
				if (!oculusCheck)
				{
					nolybabScript = GameObject.Find("FirstPersonCharacter").GetComponent<SeeNolybab>();
					((SeeNolybab)nolybabScript.GetComponent<SeeNolybab>()).enabled = false;
					
					fpsScript = GameObject.Find("FPSController1").GetComponent<FirstPersonController>();
					((FirstPersonController)fpsScript.GetComponent<FirstPersonController>()).enabled = false;
					
					tutorialScript = GameObject.Find("FPSController1").GetComponent<Tutorial>();
					//((Tutorial)tutorialScript.GetComponent<Tutorial>()).enabled = false;
					Destroy (tutorialScript);
					
					FPSController.transform.position = new Vector3 (0,0.125f,0);
					FPSController.transform.localEulerAngles = new Vector3 (0,0,0);
				}
				
				if (oculusCheck)
				{
					nolybabScript = GameObject.Find("LeftEyeAnchor").GetComponent<SeeNolybab>();
					((SeeNolybab)nolybabScript.GetComponent<SeeNolybab>()).enabled = false;
					
					nolybabScript = GameObject.Find("RightEyeAnchor").GetComponent<SeeNolybab>();
					((SeeNolybab)nolybabScript.GetComponent<SeeNolybab>()).enabled = false;
					
					fpsScript = GameObject.Find("FPSController - VR11").GetComponent<FirstPersonController>();
					((FirstPersonController)fpsScript.GetComponent<FirstPersonController>()).enabled = false;
					
					tutorialScript = GameObject.Find("FPSController - VR11").GetComponent<Tutorial>();
					//((Tutorial)tutorialScript.GetComponent<Tutorial>()).enabled = false;
					Destroy(tutorialScript);
					
					OculusController.transform.position = new Vector3 (0,0.125f,0);
					OculusController.transform.localEulerAngles = new Vector3 (0,0,0);
				}
				
				Screen.lockCursor = false;
				
				backgroundMusic.Stop ();
				TorchSound.Stop ();
				
				StopAllCoroutines();
				
				nolybabScript = GameObject.Find("FirstPersonCharacter").GetComponent<SeeNolybab>();
				((SeeNolybab)nolybabScript.GetComponent<SeeNolybab>()).FPScontrollerFabCam.fieldOfView = 75;
			}
		}
		
		if (Application.loadedLevel == 1)
		{
			if (!oculusCheck)
			{
				tutorialScript = GameObject.Find("FPSController1").GetComponent<Tutorial>();
				//((Tutorial)tutorialScript.GetComponent<Tutorial>()).enabled = false;
				Destroy(tutorialScript);
			}
			
			if (oculusCheck)
			{
				tutorialScript = GameObject.Find("FPSController - VR11").GetComponent<Tutorial>();
				//((Tutorial)tutorialScript.GetComponent<Tutorial>()).enabled = false;
				Destroy(tutorialScript);
			}
			
			if (reloader)
			{
				backgroundMusic.Stop ();
				TorchSound.Stop ();
				
				//StopAllCoroutines();
				//StartCoroutine(Seeker ());
				
				nolybabScript = GameObject.Find("FirstPersonCharacter").GetComponent<SeeNolybab>();
				((SeeNolybab)nolybabScript.GetComponent<SeeNolybab>()).FPScontrollerFabCam.fieldOfView = 75;
				
				reloader = false;
			}
		}
		
		if (Application.loadedLevel == 2)
		{
			if (!oculusCheck)
			{
				nolybabScript = GameObject.Find("FirstPersonCharacter").GetComponent<SeeNolybab>();
				((SeeNolybab)nolybabScript.GetComponent<SeeNolybab>()).enabled = false;
				
				fpsScript = GameObject.Find("FPSController1").GetComponent<FirstPersonController>();
				((FirstPersonController)fpsScript.GetComponent<FirstPersonController>()).enabled = false;
				
				tutorialScript = GameObject.Find("FPSController1").GetComponent<Tutorial>();
				//((Tutorial)tutorialScript.GetComponent<Tutorial>()).enabled = false;
				Destroy(tutorialScript);
				
				FPSController.transform.position = new Vector3 (0,0.125f,0);
				FPSController.transform.localEulerAngles = new Vector3 (0,0,0);
			}
			
			if (oculusCheck)
			{
				nolybabScript = GameObject.Find("LeftEyeAnchor").GetComponent<SeeNolybab>();
				((SeeNolybab)nolybabScript.GetComponent<SeeNolybab>()).enabled = false;
				
				nolybabScript = GameObject.Find("RightEyeAnchor").GetComponent<SeeNolybab>();
				((SeeNolybab)nolybabScript.GetComponent<SeeNolybab>()).enabled = false;
				
				fpsScript = GameObject.Find("FPSController - VR11").GetComponent<FirstPersonController>();
				((FirstPersonController)fpsScript.GetComponent<FirstPersonController>()).enabled = false;
				
				tutorialScript = GameObject.Find("FPSController - VR11").GetComponent<Tutorial>();
				//((Tutorial)tutorialScript.GetComponent<Tutorial>()).enabled = false;
				Destroy(tutorialScript);
				
				OculusController.transform.position = new Vector3 (0,0.125f,0);
				OculusController.transform.localEulerAngles = new Vector3 (0,0,0);
			}
			
			backgroundMusic.Stop ();
			TorchSound.Stop ();
			
			GameOverSound = GameObject.Find ("Game Over Sound").GetComponent<AudioSource> ();
			GameOverSource = GameObject.Find ("Main Camera").GetComponent<AudioSource> ();
			GameOverSound.clip = GameOverSource.clip;
			GameOverSource.volume = GameOverSound.volume;
			
			StopAllCoroutines();
			nolybabScript = GameObject.Find("FirstPersonCharacter").GetComponent<SeeNolybab>();
			((SeeNolybab)nolybabScript.GetComponent<SeeNolybab>()).FPScontrollerFabCam.fieldOfView = 75;
		}
	}
	
	public void OptionsScreen ()
	{
		if (showOptions == false && toggleOptions == true)
		{
			foreach (Transform child in Options.transform)
			{
				Vector3 position = new Vector3 (192, 0, 0);
				child.localPosition += position;
			}
			
			StartMenuButtons.SetActive (false);
			Options.SetActive (true);
			showOptions = true;
			toggleOptions = false;
			
			mouseClick.Play ();
		}
	}
	
	public void Hover ()
	{
		hoverSound.Play ();
	}
	
	public void ControlOptions ()
	{
		if (Application.loadedLevel == 0)
		{
			foreach (Transform child in Controls.transform)
			{
				Vector3 position = new Vector3 (192, 0, 0);
				child.localPosition += position;
			}
		}
		
		Options.SetActive (false);
		Controls.SetActive (true);
		showOptions = false;
		showControls = true;
		
		mouseClick.Play ();
	}
	
	public void SensitivityOptions (float sensitivity)
	{
		GameObject slider = GameObject.Find ("Player");
		//FirstPersonController script = slider.GetComponent<FirstPersonController>();
		//script.sensitivity = sensitivity;
	}
	
	public void GraphicOptions ()
	{
		if (Application.loadedLevel == 0)
		{
			foreach (Transform child in Graphics.transform)
			{
				Vector3 position = new Vector3 (192, 0, 0);
				child.localPosition += position;
			}
		}
		
		Options.SetActive (false);
		Graphics.SetActive (true);
		showOptions = false;
		showGraphics = true;
		
		mouseClick.Play ();
	}
	
	public void QualityOptions (int Quality)
	{
		QualitySettings.SetQualityLevel (Quality,true);
		int qualityLevel = QualitySettings.GetQualityLevel ();
		
		if(qualityLevel == 5)
		{
			QualitySettings.SetQualityLevel (6,true);
			
			if (QualitySettings.masterTextureLimit != 0)
			{
				QualitySettings.masterTextureLimit = 0;
			}
			
			if (QualitySettings.vSyncCount != 1);
			{
				QualitySettings.vSyncCount = 1;
			}
			
			if (QualitySettings.antiAliasing != 2)
			{
				QualitySettings.antiAliasing = 2;
			}
			
			if (Camera.main.farClipPlane != 10)
			{
				Camera.main.farClipPlane = 10;
				RenderDistance.GetComponent<Slider>().value = 10;
			}
			
			if (QualitySettings.shadowDistance != 150)
			{
				QualitySettings.shadowDistance = 150;
				ShadowDistance.GetComponent<Slider>().value = 150;
			}
			
			QualitySettings.SetQualityLevel (5,true);
			
			GameObject.Find("Quality Text").GetComponent<Text>().text = "High";
			GameObject.Find("Texture Text").GetComponent<Text>().text = "High";
			GameObject.Find("Setting Text").GetComponent<Text>().text = "2X";
			Checkmark.SetActive(true);
		}
		
		if(qualityLevel == 3)
		{
			QualitySettings.SetQualityLevel (6,true);
			
			if (QualitySettings.masterTextureLimit != 1)
			{
				QualitySettings.masterTextureLimit = 1;
			}
			
			if (QualitySettings.vSyncCount != 1);
			{
				QualitySettings.vSyncCount = 1;
			}
			
			if (QualitySettings.antiAliasing != 2)
			{
				QualitySettings.antiAliasing = 2;
			}
			
			if (Camera.main.farClipPlane != 10)
			{
				Camera.main.farClipPlane = 10;
				RenderDistance.GetComponent<Slider>().value = 10;
			}
			
			if (QualitySettings.shadowDistance != 40)
			{
				QualitySettings.shadowDistance = 40;
				ShadowDistance.GetComponent<Slider>().value = 40;
			}
			
			QualitySettings.SetQualityLevel (3,true);
			
			GameObject.Find("Quality Text").GetComponent<Text>().text = "Medium";
			GameObject.Find("Texture Text").GetComponent<Text>().text = "Medium";
			GameObject.Find("Setting Text").GetComponent<Text>().text = "2X";
			Checkmark.SetActive(true);
		}
		
		if(qualityLevel == 0)
		{
			QualitySettings.SetQualityLevel (6,true);
			
			if (QualitySettings.masterTextureLimit != 0)
			{
				QualitySettings.masterTextureLimit = 2;
			}
			
			if (QualitySettings.vSyncCount != 0);
			{
				QualitySettings.vSyncCount = 0;
			}
			
			if (QualitySettings.antiAliasing != 0)
			{
				QualitySettings.antiAliasing = 0;
			}
			
			if (Camera.main.farClipPlane != 5)
			{
				Camera.main.farClipPlane = 5;
				RenderDistance.GetComponent<Slider>().value = 5;
			}
			
			if (QualitySettings.shadowDistance != 15)
			{
				QualitySettings.shadowDistance = 15;
				ShadowDistance.GetComponent<Slider>().value = 15;
			}
			
			QualitySettings.SetQualityLevel (0,true);
			
			GameObject.Find("Quality Text").GetComponent<Text>().text = "Low";
			GameObject.Find("Texture Text").GetComponent<Text>().text = "Low";
			GameObject.Find("Setting Text").GetComponent<Text>().text = "None";
			Checkmark.SetActive(false);
		}
	}
	
	public void TextureQualityOptions (int textureQuality)
	{
		QualitySettings.SetQualityLevel (6,true);
		QualitySettings.masterTextureLimit = textureQuality;
		
		if(QualitySettings.masterTextureLimit == 0)
		{
			GameObject.Find("Texture Text").GetComponent<Text>().text = "High";
			GameObject.Find("Quality Text").GetComponent<Text>().text = "Custom";
		}
		
		if(QualitySettings.masterTextureLimit == 1)
		{
			GameObject.Find("Texture Text").GetComponent<Text>().text = "Medium";
			GameObject.Find("Quality Text").GetComponent<Text>().text = "Custom";
		}
		
		if(QualitySettings.masterTextureLimit == 2)
		{
			GameObject.Find("Texture Text").GetComponent<Text>().text = "Low";
			GameObject.Find("Quality Text").GetComponent<Text>().text = "Custom";
		}
	}
	
	public void VSyncOptions ()
	{
		QualitySettings.SetQualityLevel (6,true);
		
		if( QualitySettings.vSyncCount == 1)
		{
			QualitySettings.vSyncCount = 0;
			Checkmark.SetActive(false);
			GameObject.Find("Quality Text").GetComponent<Text>().text = "Custom";
		}
		else if (QualitySettings.vSyncCount == 0)
		{
			QualitySettings.vSyncCount = 1;
			Checkmark.SetActive(true);
			GameObject.Find("Quality Text").GetComponent<Text>().text = "Custom";
		}
	}
	
	public void AntiAliasingOptions (int antiAliasing)
	{
		QualitySettings.SetQualityLevel (6,true);
		QualitySettings.antiAliasing = antiAliasing;
		
		if(QualitySettings.antiAliasing == 0)
		{
			GameObject.Find("Setting Text").GetComponent<Text>().text = "None";
			GameObject.Find("Quality Text").GetComponent<Text>().text = "Custom";
		}
		
		if(QualitySettings.antiAliasing == 2)
		{
			GameObject.Find("Setting Text").GetComponent<Text>().text = "2X";
			GameObject.Find("Quality Text").GetComponent<Text>().text = "Custom";
		}
		
		if(QualitySettings.antiAliasing == 4)
		{
			GameObject.Find("Setting Text").GetComponent<Text>().text = "4X";
			GameObject.Find("Quality Text").GetComponent<Text>().text = "Custom";
		}
		
		if(QualitySettings.antiAliasing == 8)
		{
			GameObject.Find("Setting Text").GetComponent<Text>().text = "8X";
			GameObject.Find("Quality Text").GetComponent<Text>().text = "Custom";
		}
	}
	
	public void RenderDistanceOptions (float renderDistance)
	{
		QualitySettings.SetQualityLevel (6,true);
		Camera.main.farClipPlane = renderDistance;
		GameObject.Find("Quality Text").GetComponent<Text>().text = "Custom";
	}
	
	public void ShadowDistanceOptions (float shadowDistance)
	{
		QualitySettings.SetQualityLevel (6,true);
		QualitySettings.shadowDistance = shadowDistance;
		GameObject.Find("Quality Text").GetComponent<Text>().text = "Custom";
	}
	
	public void AudioOptions ()
	{
		if (Application.loadedLevel == 0)
		{
			foreach (Transform child in Audio.transform)
			{
				Vector3 position = new Vector3 (192, 0, 0);
				child.localPosition += position;
			}
		}
		
		Options.SetActive (false);
		Audio.SetActive (true);
		showOptions = false;
		showAudio = true;
		
		mouseClick.Play ();
	}
	
	public void ChangeMasterVolume ()
	{
		if (masterVolumeSlider.value != 0)
		{
			musicVolumeSlider.maxValue = masterVolumeSlider.value;
			effectVolumeSlider.maxValue = masterVolumeSlider.value;
			
			if(masterVolumeSlider.value != 100)
			{
				musicVolumeSlider.value = masterVolumeSlider.value;
				effectVolumeSlider.value = masterVolumeSlider.value;
			}
		}
	}
	
	public void Back ()
	{
		if (showOptions && Application.loadedLevel == 0)
		{
			foreach (Transform child in Options.transform)
			{
				Vector3 position = new Vector3 (192, 0, 0);
				child.localPosition -= position;
			}
			
			Options.SetActive (false);
			StartMenuButtons.SetActive (true);
			showOptions = false;
			toggleOptions = true;
			
			mouseClick.Play ();
		}
		
		if (showOptions && Application.loadedLevel == 1 || showOptions && Application.loadedLevel == 3)
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			
			Options.SetActive (false);
			showOptions = false;
			toggleOptions = true;
			
			mouseClick.Play ();
			backgroundMusic.UnPause ();
			TorchSound.UnPause();
			
			foreach (GameObject Pause in FindObjectsOfType(typeof(GameObject)))
			{
				Time.timeScale = 1;
			}
			//Cursor.visible = false;
			//Screen.lockCursor = true;
		}
		
		if (showControls)
		{
			if (Application.loadedLevel == 0)
			{
				foreach (Transform child in Controls.transform)
				{
					Vector3 position = new Vector3 (192, 0, 0);
					child.localPosition -= position;
				}
			}
			
			Controls.SetActive (false);
			Options.SetActive (true);
			showOptions = true;
			showControls = false;
			
			mouseClick.Play ();
		}
		
		if (showGraphics)
		{
			if (Application.loadedLevel == 0)
			{
				foreach (Transform child in Graphics.transform)
				{
					Vector3 position = new Vector3 (192, 0, 0);
					child.localPosition -= position;
				}
			}
			
			Graphics.SetActive (false);
			Options.SetActive (true);
			showOptions = true;
			showGraphics = false;
			
			mouseClick.Play ();
		}
		
		if (showAudio)
		{
			if (Application.loadedLevel == 0)
			{
				foreach (Transform child in Audio.transform)
				{
					Vector3 position = new Vector3 (192, 0, 0);
					child.localPosition -= position;
				}
			}
			
			Audio.SetActive (false);
			Options.SetActive (true);
			showOptions = true;
			showAudio = false;
			
			mouseClick.Play ();
		}
	}
	
	public void Play ()
	{
		LoadingScreen.SetActive (true);
		StartMenu.SetActive (false);
		Title.SetActive (false);
		startTune.Stop ();
		mouseClick.Play ();
		Application.LoadLevelAsync ("Scene");
	}
	
	public void Tutorial ()
	{
		LoadingScreen.SetActive (true);
		StartMenu.SetActive (false);
		Title.SetActive (false);
		startTune.Stop ();
		mouseClick.Play ();
		
		if (!oculusCheck)
		{
			FPSController.AddComponent<Tutorial> ();
			
			tutorialScript = GameObject.Find("FPSController1").GetComponent<Tutorial> ();
			((Tutorial)tutorialScript.GetComponent<Tutorial>()).reload = true;
		}
		
		if (oculusCheck)
		{
			OculusController.AddComponent<Tutorial> ();
			
			tutorialScript = GameObject.Find("FPSController - VR11").GetComponent<Tutorial> ();
			((Tutorial)tutorialScript.GetComponent<Tutorial>()).reload = true;
		}
		
		Application.LoadLevelAsync ("Tutorial");
	}
	
	public void QuitGame ()
	{
		Application.Quit ();
		mouseClick.Play ();
	}
	
	public void OculusRift ()
	{
		if(GameObject.Find ("Oculus Rift Toggle").GetComponent<Toggle>().isOn == true)
		{
			oculusCheck = true;
		}
		
		if(GameObject.Find ("Oculus Rift Toggle").GetComponent<Toggle>().isOn == false)
		{
			oculusCheck = false;
		}
	}
}