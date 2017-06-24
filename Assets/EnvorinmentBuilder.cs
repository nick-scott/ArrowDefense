using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvorinmentBuilder : MonoBehaviour {
    GameObject ground;
    // Use this for initialization
    float groundHeightInPercent = 10f;
    void Start () {
        transform.position = new Vector3(Screen.width / 2, Screen.height / 2, 100);
        ground = transform.FindChild("Ground").gameObject;
        drawGround();
        Debug.Log("groundHeightInPercent: " + groundHeightInPercent);
    }

    private void drawGround()
    {
        float realPercentage = 100 / groundHeightInPercent;
        ground.transform.position = new Vector3(Screen.width / 2, (Screen.height / realPercentage) /2, 100);
        ground.transform.localScale = new Vector3(Screen.width, Screen.height / realPercentage, 100);
        Debug.Log("realPercentage: " + realPercentage);
        Debug.Log("groundHeight: " + Screen.height / realPercentage);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
