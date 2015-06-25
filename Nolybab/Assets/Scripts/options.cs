using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class options : MonoBehaviour
{
	public GameObject Sounds;
	public GameObject StartMenu;
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

	Tutorial script;
	
	public void Awake () 
	{
		//StartCoroutine (Seeker ());
		//Cursor.visible = false;
		//Screen.lockCursor = true;

		OnLevelWasLoaded ();

		backgroundMusicClip = new AudioClip[] 
		{
			backgroundMusicClip_0,
			backgroundMusicClip_1,
			backgroundMusicClip_2,
		};
	}

	public IEnumerator Seeker()
	{
		yield return new WaitForSeconds (0.1f);

		BackgroundMusic = GameObject.Find ("Background Music").GetComponent<AudioSource> ();
		BackgroundMusic.clip = backgroundMusicClip [Random.Range (0, backgroundMusicClip.Length)];
		backgroundMusic = BackgroundMusic;
		backgroundMusic.volume = BackgroundMusic.volume;

		backgroundMusic.Play ();

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
			startTune.Play ();
			Options = StartOptions;
		}

		if (Application.loadedLevel  == 1 || Application.loadedLevel  == 3)
		{
			Options = GameOptions;
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			StartCoroutine (Seeker ());
		}
	}

	void Update ()
	{
		if (Application.loadedLevel == 1 || Application.loadedLevel == 3)
		{
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

			NolybabSounds = GameObject.Find ("Nolybab Sounds").GetComponent<AudioSource> ();
			NolybabSource = GameObject.Find ("Skull").GetComponent<AudioSource> ();
			NolybabSounds.clip = NolybabSource.clip;
			NolybabSource.volume = NolybabSounds.volume;

			if (Input.GetKeyDown (KeyCode.Escape))
			{
				if (showOptions == false && toggleOptions == true)
				{
					Cursor.lockState = CursorLockMode.None;
					Cursor.visible = true;

					Options.SetActive (true);
					showOptions = true;
					toggleOptions = false;
				
					backgroundMusic.Pause ();
					TorchSound.Pause ();

					//GameObject pause = GameObject.FindGameObjectWithTag("Player");
					//((FirstPersonController)pause.GetComponent<FirstPersonController>()).enabled = false;

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
			
					//GameObject pause = GameObject.FindGameObjectWithTag("Player");
					//((FirstPersonsController)pause.GetComponent<FirstPersonController>()).enabled = true;

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

					//GameObject pause = GameObject.FindGameObjectWithTag("Player");
					//((FirstPersonController)pause.GetComponent<FirstPersonController>()).enabled = true;

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
				
					//GameObject pause = GameObject.FindGameObjectWithTag("Player");
					//((FirstPersonController)pause.GetComponent<FirstPersonController>()).enabled = true;

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

					//GameObject pause = GameObject.FindGameObjectWithTag("Player");
					//((FirstPersonController)pause.GetComponent<FirstPersonController>()).enabled = true;

					foreach (GameObject Pause in FindObjectsOfType(typeof(GameObject)))
					{
						Time.timeScale = 1;
					}

					//Cursor.visible = false;
					//Screen.lockCursor = true;
				}
			}
	
			if (Application.loadedLevel != 3)
			{
				Destroy (GameObject.FindGameObjectWithTag ("Player").GetComponent<Tutorial> ());
			}
		}
	}

	public void OptionsScreen ()
	{
		if (showOptions == false && toggleOptions == true)
		{
			StartMenu.SetActive (false);
			Options.SetActive (true);
			showOptions = true;
			toggleOptions = false;
		} 
	}

	public void Hover ()
	{
		hoverSound.Play ();
	}

	public void ControlOptions ()
	{
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
			GameObject.Find("Setting Text").GetComponent<Text>().text = "None";
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
			Options.SetActive (false);
			StartMenu.SetActive (true);
			showOptions = false;
			toggleOptions = true;
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

			//GameObject pause = GameObject.FindGameObjectWithTag("Player");
			//((FirstPersonController)pause.GetComponent<FirstPersonController>()).enabled = true;

			foreach (GameObject Pause in FindObjectsOfType(typeof(GameObject)))
			{
				Time.timeScale = 1;
			}
			//Cursor.visible = false;
			//Screen.lockCursor = true;
		}
		
		if (showControls)
		{
			Controls.SetActive (false);
			Options.SetActive (true);
			showOptions = true;
			showControls = false;
			
			mouseClick.Play ();
		}

		if (showGraphics)
		{
			Graphics.SetActive (false);
			Options.SetActive (true);
			showOptions = true;
			showGraphics = false;
			
			mouseClick.Play ();
		}
		
		if (showAudio)
		{
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
		startTune.Stop ();
		Application.LoadLevel ("Scene");
		mouseClick.Play ();
	}
	
	public void Tutorial ()
	{
		LoadingScreen.SetActive (true);
		StartMenu.SetActive (false);
		startTune.Stop ();
		Application.LoadLevel ("Tutorial");
		mouseClick.Play ();
	}
	
	public void QuitGame ()
	{
		Application.Quit ();
		mouseClick.Play ();
	}

//	public void OnLevelWasLoaded(int level)
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