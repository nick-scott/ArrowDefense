using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiloController {

    public GameObject Missile { private get; set; }


    public void fireMissile(bool fromLeft, Vector2 location)
    {
        Vector2 origin = new Vector2(Screen.width + 20, Screen.height/10);
        if (fromLeft)
        {
            origin.x = -20;
        }
        GameObject missileObject = GameObject.Instantiate(Missile);
        MissileController missile = missileObject.GetComponent<MissileController>();
        missile.launch(origin, location);
    }

    public SiloController setMissile(GameObject missilePrefab)
    {
        this.Missile = missilePrefab;
        return this;
    }
}
