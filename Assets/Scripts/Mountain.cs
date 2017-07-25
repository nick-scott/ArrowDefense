using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mountain : MonoBehaviour {

    public Color textureColour = new Color(1, 1, 1, 1);

	// Use this for initialization
	void Start () {
        var texture = new Texture2D(1, 1, TextureFormat.ARGB32, false);
        texture.SetPixel(1, 1, textureColour);
        texture.Apply();
        GetComponent<Renderer>().material.mainTexture = texture;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
