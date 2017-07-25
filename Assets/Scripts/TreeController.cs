using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour {

    public GameObject Tree { private get; set; }

    public static void populateTreesOnObject(GameObject groundObject)
    {
        RaycastHit hit;
        Physics.Raycast(new Vector3(Screen.width / 2, Screen.height, 0), groundObject.transform.position, out hit);
    }


}
