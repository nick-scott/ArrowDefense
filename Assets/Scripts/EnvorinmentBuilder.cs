using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnvorinmentBuilder : MonoBehaviour{
	GameObject hill;
	GameObject groundFill;
	GameObject tree;
	// Use this for initialization
	static float groundHeightInPercent = 10f;
	float realPercentage = 100 / groundHeightInPercent;

	void Start () {
		transform.position = new Vector3(UnitUtility.centerWidth(), UnitUtility.centerHeight(), 100);
		hill = transform.Find("Hill").gameObject;
		groundFill = transform.Find("GroundFill").gameObject;
		drawGround();
		Debug.Log("groundHeightInPercent: " + groundHeightInPercent);
	}

	private void drawGround()
	{
		hill.transform.position = new Vector3(UnitUtility.centerWidth(), UnitUtility.percentHeight(groundHeightInPercent)/2, transform.position.z);
		groundFill.transform.position = new Vector3(UnitUtility.centerWidth(), UnitUtility.percentHeight(groundHeightInPercent) / 4, transform.position.z);
		hill.transform.localScale = new Vector3(Screen.width*1.4f, UnitUtility.percentHeight(groundHeightInPercent), 1);
		groundFill.transform.localScale = new Vector3(Screen.width, UnitUtility.percentHeight(groundHeightInPercent) / 2, 1);
		Debug.Log("groundHeight: " + Screen.height / realPercentage);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
