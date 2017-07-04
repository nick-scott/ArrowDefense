using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour {

	private bool armed = false;
	private bool exploded = false;
	Vector2 destination = new Vector2(0, 100);
	float missileSpeed = 100f;
	ParticleSystem smoke;
	ParticleSystem fire;
	ParticleSystem explosion;
	public AudioClip[] missileExplosions;
	public AudioClip[] missileLaunches;

	// Use this for initialization
	void Start () {
		smoke = transform.Find("SmokeEffect").GetComponent<ParticleSystem>();
		fire = transform.Find("FlamesParticleEffect").GetComponent<ParticleSystem>();
		explosion = transform.Find("BigExplosionEffect").GetComponent<ParticleSystem>();
		smoke.Play(true);
		fire.Play(true);
		explosion.Stop(true);
		//_audio = transform.GetComponent<AudioSource>();        
	}

	// Update is called once per frame
	void Update () {
		if (armed)
		{
			//Debug.Log("Distance to target: " + Vector2.Distance(transform.position, destination));
			if (Vector2.Distance(transform.position, destination) < 5)
			{
				explode();
			}
			float step = missileSpeed * Time.deltaTime;
			transform.position = Vector2.MoveTowards(transform.position, destination, step);
		}
		if(exploded && !explosion.isPlaying)
		{
			Debug.Log("Cleaning up missile");
			Destroy(transform.gameObject);
		}
	}

	public void launch(Vector2 origin, Vector2 destination)
	{
		Debug.Log("Misile launched from: " + origin + " to: " + destination);
		this.destination = destination;
		transform.position = origin;
		arm();
	}

	private void explode()
	{
		smoke.Stop(true);
		fire.Stop(true);
		explosion.Play(true);
		armed = false;
		exploded = true;
		AudioManager.instance.PlayRandomSound (GetComponent<AudioSource>(), missileExplosions, 0.5f);
		Debug.Log("Missile Armed: " + armed);
		//_audio.Stop();
		//Object[] missileExplosion = Resources.LoadAll("Sounds/PlayerMissile/Explosion", typeof(AudioClip));
		//_audio.clip = (AudioClip)missileExplosion[Random.Range(0, missileExplosion.Length)];
        //_audio.PlayDelayed(0.5f);
	}

	private void arm()
	{
		if (smoke)
		{
			smoke.Play(true);
		}
		if (fire)
		{
			fire.Play(true);
		}
		if (explosion)
		{
			explosion.Stop(true);
		}
		armed = true;
		AudioManager.instance.PlayRandomSound (GetComponent<AudioSource>(), missileLaunches, 0f);
		Debug.Log("Missile Armed: " + armed);
		//AudioSource audio = transform.GetComponent<AudioSource>();
		//Object[] missileLaunch = Resources.LoadAll("Sounds/PlayerMissile/Launch", typeof(AudioClip));
		//audio.PlayOneShot((AudioClip)missileLaunch[Random.Range(0, missileLaunch.Length)], 0.5f);
	}

	public bool hasExploded()
	{
		return exploded;
	}
}
