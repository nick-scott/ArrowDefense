using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour
{

    GameObject treefab;

    public Transform Environment { get; set; }

    public TreeController(GameObject tree)
    {
        treefab = tree;
    }

    public void populateTreesOnObject(GameObject groundObject, float scaleVariation = 1)
    {
        for (int i = 0; i < 1000; i++)
        {
            RaycastHit hit;
            Vector3 origin = new Vector3(Screen.width / 2, Screen.height, groundObject.transform.position.z);
            Vector3 destination = getRandomPointInsideObject(groundObject.transform);
            Debug.DrawRay(origin, destination, Color.green, 5000f);
            if (Physics.Raycast(origin, destination, out hit, 2000f))
            {
                Debug.Log("Ray hit!: " + hit.point + " Object: " + hit.transform.gameObject.name);
                GameObject treeClone = GameObject.Instantiate(treefab);
                treeClone.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z - 100);
                treeClone.transform.localScale *= Random.Range(1, 1 + scaleVariation);
            }
        }
    }

    Vector3 getRandomPointInsideObject(Transform obj)
    {
        return new Vector3(
            Random.Range(-(obj.transform.localScale.x / 2),(obj.transform.localScale.x / 2)),
            obj.position.y-Environment.position.y,
            Random.Range(- (obj.transform.localScale.z / 2), (obj.transform.localScale.z / 2)));
    }
}
