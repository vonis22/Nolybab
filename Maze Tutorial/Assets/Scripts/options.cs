using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class options : MonoBehaviour
{
	public GameObject Sounds;
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
	
	public AudioSource backgroundMusic;
	public AudioSource mouseClick;
	public AudioSource hoverSound;

	AudioSource BackgroundMusic;
	AudioSource LevelMusicSource;
	AudioSource ControllerSounds;
	AudioSource ControllerSource;
	AudioSource BreakWall;
	AudioSource BreakWallSource;
	AudioSource RealWall;
	AudioSource RealWallSource;

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
	
	public void Awake () 
	{
		//Instantiate(Sounds, new Vector3(0,0,0), Quaternion.identity);
		//Instantiate(Options, new Vector3(0,0,0), Quaternion.identity);
		//Instantiate(Controls, new Vector3(0,0,0), Quaternion.identity);
		//Instantiate(Graphics, new Vector3(0,0,0), Quaternion.identity);
		//Instantiate(Audio, new Vector3(0,0,0), Quaternion.identity);
	
		StartCoroutine (Seeker ());
		//Cursor.visible = false;
		//Screen.lockCursor = true;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

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

		backgroundMusic.Play ();

		//ControllerSounds & source
		ControllerSounds = GameObject.Find ("Controller Sounds").GetComponent<AudioSource> ();
		ControllerSource = GameObject.FindWithTag ("Player").GetComponent<AudioSource> ();
		ControllerSounds.clip = ControllerSource.clip;
		ControllerSource.volume = ControllerSounds.volume;

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
	
	void Update ()
	{
		foreach(AudioSource BreakWallSource in FindObjectsOfType(typeof(AudioSource)))
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

				//GameObject pause = GameObject.FindGameObjectWithTag("Player");
				//((FirstPersonController)pause.GetComponent<FirstPersonController>()).enabled = false;

				foreach (GameObject Pause in FindObjectsOfType(typeof(GameObject)))
				{
					Time.timeScale = 0;
				}

				//Cursor.visible = true;
				//Screen.lockCursor = false;
			} 
			else if(showOptions == true && toggleOptions == false)
			{
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;

				Options.SetActive (false);
				showOptions = false;
				toggleOptions = true;
				
				backgroundMusic.UnPause ();

				//GameObject pause = GameObject.FindGameObjectWithTag("Player");
				//((FirstPersonsController)pause.GetComponent<FirstPersonController>()).enabled = true;

				foreach (GameObject Pause in FindObjectsOfType(typeof(GameObject)))
				{
					Time.timeScale = 1;
				}

				//Cursor.visible = false;
				//Screen.lockCursor = true;
			}
			
			if(showControls == true)
			{
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;

				Controls.SetActive (false);
				showOptions = false;
				showControls = false;
				toggleOptions = true;

				backgroundMusic.UnPause ();

				//GameObject pause = GameObject.FindGameObjectWithTag("Player");
				//((FirstPersonController)pause.GetComponent<FirstPersonController>()).enabled = true;

				foreach (GameObject Pause in FindObjectsOfType(typeof(GameObject)))
				{
					Time.timeScale = 1;
				}

				//Cursor.visible = false;
				//Screen.lockCursor = true;
			}

			if(showGraphics == true)
			{
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;

				Graphics.SetActive (false);
				showOptions = false;
				showGraphics = false;
				toggleOptions = true;
				
				backgroundMusic.UnPause ();
				
				//GameObject pause = GameObject.FindGameObjectWithTag("Player");
				//((FirstPersonController)pause.GetComponent<FirstPersonController>()).enabled = true;

				foreach (GameObject Pause in FindObjectsOfType(typeof(GameObject)))
				{
					Time.timeScale = 1;
				}

				//Cursor.visible = false;
				//Screen.lockCursor = true;
			}
			
			if(showAudio == true)
			{
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;

				Audio.SetActive (false);
				showOptions = false;
				showAudio = false;
				toggleOptions = true;

				backgroundMusic.UnPause ();

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
	
	public void QuitGame ()
	{
		Application.Quit ();
		
		mouseClick.Play ();
	}
	
	public void Back ()
	{
		if (showOptions)
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;

			Options.SetActive (false);
			showOptions = false;
			toggleOptions = true;
			
			mouseClick.Play ();
			backgroundMusic.UnPause ();

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
}