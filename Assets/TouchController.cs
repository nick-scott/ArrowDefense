using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController: MonoBehaviour {


    SiloController silo; 
	// Use this for initialization
	void Start () {
        silo = new SiloController();
        //Screen.SetResolution(Screen.width, Screen.height, true);
        Camera camera = this.GetComponent<Camera>();
        //float aspectRatio = Screen.width / Screen.height;
        Debug.Log("Width: " + Screen.width + " Height: " + Screen.height);
        camera.projectionMatrix = Matrix4x4.Ortho(0, Screen.width, 0, Screen.height, 0.3f, 1000f);
        
    }

	// Update is called once per frame
	void Update() {
		//RaycastHit hit = new RaycastHit();
		for (int i = 0; i < Input.touchCount; ++i) {
			Touch touch = Input.GetTouch(i);
			if (touch.phase.Equals(TouchPhase.Began))
			{
				Debug.Log("Touch at: " + touch.position);
				if(touch.position.x < Screen.width / 2)
				{
					Debug.Log("Left Silo :" + silo);
                    silo.fireMissile(true, touch.position);

				}
				else
				{
					Debug.Log("Right Silo");
                    silo.fireMissile(false, touch.position);
                }
                // Construct a ray from the current touch coordinates
                //Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
				//if (Physics.Raycast(ray, out hit))
				//	hit.transform.gameObject.SendMessage("OnMouseDown");
			}
		}   
	}
}
