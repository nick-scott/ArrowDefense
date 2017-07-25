using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnvorinmentBuilder : MonoBehaviour
{

    public GameObject hillPrefab;
    public float numHills = 1;
    float hillDepth = 500f;
    public float groundHeightInPercent = 10f;

    // Use this for initialization

    void Start()
    {
        buildHills();
    }

    void buildHills()
    {
        float realPercentage = 100 / groundHeightInPercent;

        transform.position = new Vector3(UnitUtility.centerWidth(), UnitUtility.centerHeight(), 100);
        GameObject mainHill = Instantiate(hillPrefab, transform);
        //groundFill = transform.Find("GroundFill").gameObject;
        float groundHeight = UnitUtility.percentHeight(groundHeightInPercent);
        mainHill.transform.position = new Vector3(UnitUtility.centerWidth(), -550 + transform.position.y, hillDepth);
        mainHill.transform.localScale = new Vector3(Screen.width*2, hillDepth, hillDepth);

        for(int i = 1; i < numHills; i++)
        {
            makeSuperficialHill();
        }
        Debug.Log("groundHeightInPercent: " + groundHeightInPercent);
    }

    GameObject makeSuperficialHill()
    {
        return null;
    }
}
