using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour {

	private bool isPaused;
    SiloController silo;
    // Use this for initialization
    float lastMissileTime = 0;
    float nextMissileTime = 0;
    void Start () {
        silo = new SiloController();
    }
	
	// Update is called once per frame
	void Update () {
		if(Time.time > lastMissileTime + nextMissileTime)
        {

        }
	}

    public void touchEvent(Vector2 location)
    {
		if(!isPaused){
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

	public void Pause(){
		isPaused = true;
	}
	public void Resume(){
		isPaused = false;
	}
}
