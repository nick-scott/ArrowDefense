using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour {

	private bool armed = false;
	Vector2 destination = new Vector2(0, 100);
	float missileSpeed = 100f;
    ParticleSystem smoke;
    ParticleSystem fire;
    ParticleSystem explosion;
    // Use this for initialization
    void Start () {
        smoke = transform.Find("SmokeEffect").GetComponent<ParticleSystem>();
        fire = transform.Find("FlamesParticleEffect").GetComponent<ParticleSystem>();
        explosion = transform.Find("BigExplosionEffect").GetComponent<ParticleSystem>();
        explosion.Stop(true);
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log("Missile Armed: " + armed);
		if (armed)
		{
			Debug.Log("Distance to target: " + Vector2.Distance(transform.position, destination));
			if (Vector2.Distance(transform.position, destination) < 10)
			{
                explode();
			}
			float step = missileSpeed * Time.deltaTime;
			transform.position = Vector2.MoveTowards(transform.position, destination, step);
		}
	}

    public void launch(Vector2 origin, Vector2 destination)
    {
        Debug.Log("Misile launched from: " + origin + " to: " + destination);
        armed = true;
        this.destination = destination;
        transform.position = origin;
        smoke.Play(true);
        fire.Play(true);
        explosion.Stop(true);
    }

    private void explode()
    {
        if (smoke.isPlaying)
        {
            smoke.Stop(true);
        }
        if (fire.isPlaying)
        {
            fire.Stop(true);
        }
        explosion.Play(true);
        armed = false;
    }
}
