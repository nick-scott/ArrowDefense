using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchController: MonoBehaviour {
	
	RectTransform pauseButton;
    GameEngine gameEngine;
    //Camera camera;
    // Use this for initialization
    void Start () {
        //Screen.SetResolution(Screen.width, Screen.height, true);
        //camera = this.GetComponent<Camera>();
        //float aspectRatio = Screen.width / Screen.height;
        Debug.Log("Width: " + Screen.width + " Height: " + Screen.height);
        this.GetComponent<Camera>().projectionMatrix = Matrix4x4.Ortho(0, Screen.width, 0, Screen.height, 0.3f, 1000f);
        gameEngine = GameObject.Find("GameEngine").GetComponent<GameEngine>();
		pauseButton = GameObject.Find("PauseButton").GetComponent<RectTransform> ();
    }

	// Update is called once per frame
	void Update() {
		for (int i = 0; i < Input.touchCount; ++i) {
			Touch touch = Input.GetTouch(i);
			if (touch.phase.Equals(TouchPhase.Began))
			{
                gameEngine.touchEvent(touch.position);
			}
		}
        if (Input.GetMouseButtonDown(0))
        {
			//check mouse position is above ingame UI
			if(Input.mousePosition.y > (pauseButton.position.y + ((pauseButton.rect.height / 2) + 20))){
				gameEngine.touchEvent(Input.mousePosition);
			}
        }
    }
}
