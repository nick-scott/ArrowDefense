using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissileController : MonoBehaviour {

    private bool armed = false;
    Vector2 destination = new Vector2(0, 100);
    float missileSpeed = 100f;

    // Use this for initialization
    void Start () {

    }


    void Update()
    {
        if (armed)
        {
            //Debug.Log("Distance to target: " + Vector2.Distance(transform.position, destination));
            if (Vector2.Distance(transform.position, destination) < 5)
            {
                Debug.Log("Cleaning up missile");
                Destroy(transform.gameObject);
            }
            float step = missileSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, destination, step);
        }

    }

    public void launch(Vector2 origin, Vector2 destination)
    {
        Debug.Log("Misile launched from: " + origin + " to: " + destination);
        this.destination = destination;
        transform.position = origin;
        armed = true;
    }
}
