using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiloController {


    public void fireMissile(bool fromLeft, Vector2 location)
    {
        Vector2 origin = new Vector2(Screen.width + 20, Screen.height/10);
        if (fromLeft)
        {
            origin.x = -20;
        }
        GameObject missileObject = GameObject.Instantiate(GameObject.Find("Missile"));
        MissileController missile = missileObject.GetComponent<MissileController>();
        missile.launch(origin, location);
    }
}
