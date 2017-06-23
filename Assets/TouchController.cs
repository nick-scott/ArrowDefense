using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController: MonoBehaviour {


    SiloController silo;
    Camera camera;
    // Use this for initialization
    void Start () {
        silo = new SiloController();
        //Screen.SetResolution(Screen.width, Screen.height, true);
        camera = this.GetComponent<Camera>();
        //float aspectRatio = Screen.width / Screen.height;
        Debug.Log("Width: " + Screen.width + " Height: " + Screen.height);
        camera.projectionMatrix = Matrix4x4.Ortho(0, Screen.width, 0, Screen.height, 0.3f, 1000f);
        
    }

	// Update is called once per frame
	void Update() {
		for (int i = 0; i < Input.touchCount; ++i) {
			Touch touch = Input.GetTouch(i);
			if (touch.phase.Equals(TouchPhase.Began))
			{
                touchEvent(touch.position);
			}
		}
        if (Input.GetMouseButtonDown(0))
        {
            touchEvent(Input.mousePosition);
        }
    }

    public void touchEvent(Vector2 location)
    {
        Debug.Log("Touch at: " + location);
        if (location.x < Screen.width / 2)
        {
            Debug.Log("Left Silo :" + silo);
            silo.fireMissile(true, location);

        }
        else
        {
            Debug.Log("Right Silo");
            silo.fireMissile(false, location);
        }
    }
}
