using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour {

	private bool isPaused;
    public GameObject missilePrefab;
    public GameObject enemyMissilePrefab;
    SiloController silo;
    // Use this for initialization
    float lastMissileTime = 0;
    float nextMissileTime = 3;
    void Start () {
        silo = new SiloController().setMissile(missilePrefab);
    }
	
	// Update is called once per frame
	void Update () {
		if(Time.time > lastMissileTime + nextMissileTime)
        {
            Instantiate(enemyMissilePrefab)
                .GetComponent<EnemyMissileController>()
                .launch(new Vector2(0,Screen.height), new Vector2(Screen.width, 0));
            lastMissileTime = Time.time;
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
