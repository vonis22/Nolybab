using UnityEngine;
using System.Collections;

public class WallChangeScript : MonoBehaviour {
	private AIPath aiScript;
	private Renderer rend;
	public Color changeTo;
	public float redValue = 255;
	public float greenValue = 255;
	public float blueValue = 255;
	public float alphaValue = 255;
	// Use this for initialization
	void Start () {

		rend = GetComponent<Renderer>();
		rend.material.shader = Shader.Find("Standard");

		StartCoroutine (CheckValues ());

	}

	IEnumerator CheckValues ()
	{
		yield return new WaitForSeconds (0.00001f);

	}

	// Update is called once per frame
	void Update () {

		aiScript = GameObject.FindGameObjectWithTag ("Nolybab").GetComponent<AIPath> ();
		redValue = 255;
		changeTo = new Color((redValue / 255) ,(greenValue / 255) ,(blueValue/ 255) ,alphaValue);
		rend.material.SetColor("_Color",changeTo);
		alphaValue = 0.0f;


		//print (aiScript.sanity);
		if (aiScript.sanity <=0)
		{
			redValue = 255;
			greenValue -= 50 * Time.deltaTime;
			blueValue -= 50 * Time.deltaTime;
			// Walls Change color to RED
			//R 255
			//G 0
			//B 0


		}
		else 
		{
			if(greenValue < 255 && blueValue < 255)
			{
				greenValue += 50*Time.deltaTime;
				blueValue += 50*Time.deltaTime;
			}//Walls are Normal Color
			//R 255
			//G 255
			//B 255

		}
	
	}
}
