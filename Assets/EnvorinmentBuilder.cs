using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvorinmentBuilder : MonoBehaviour{
	GameObject ground;
	GameObject tree;
	// Use this for initialization
	static float groundHeightInPercent = 10f;
	float realPercentage = 100 / groundHeightInPercent;

	void Start () {
		transform.position = new Vector3(Screen.width / 2, Screen.height / 2, 100);
		ground = transform.Find("Ground").gameObject;
		//tree = transform.FindChild("Tree").gameObject;
		drawGround();
		//drawTrees(1);
		Debug.Log("groundHeightInPercent: " + groundHeightInPercent);
	}

	private void drawGround()
	{
		ground.transform.position = new Vector3(Screen.width / 2, (Screen.height / realPercentage) / 2, transform.position.z);
		ground.transform.localScale = new Vector3(Screen.width*1.4f, (Screen.height / realPercentage)+100, 1);
		Debug.Log("groundHeight: " + Screen.height / realPercentage);
	}
	
	private void drawTrees(float treeDensity)
	{
		GameObject treeClone = GameObject.Instantiate(tree);
		treeClone.transform.parent = transform;
		treeClone.transform.position = new Vector3(Screen.width / 2, (Screen.height / realPercentage) / 2, -1);
		treeClone.transform.localScale = new Vector3(10, 10, 1);
		treeClone.SetActive(true);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
