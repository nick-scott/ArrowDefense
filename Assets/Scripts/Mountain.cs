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
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        Vector3[] normals = mesh.normals;
        for (int n = 0; n < normals.Length; n++)
        {
            normals[n] = new Vector3(0, vertices[n].y, -1);
        }
        mesh.normals = normals;
        mesh.RecalculateBounds();

    }
	
	// Update is called once per frame
	void Update () {

    }
}
