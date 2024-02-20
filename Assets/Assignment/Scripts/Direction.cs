using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Direction : MonoBehaviour
{
    public GameObject pc;
    public GameObject stepButton;
    Distance distScript;
    // Start is called before the first frame update
    void Start()
    {
        //distScript = stepButton.GetComponent<Distance>();
        //first = distScript.travelPoints[0];
        //last = distScript.travelPoints.Last();
    }

    // Update is called once per frame
    void Update()
    {
        //if (first != last)
        //{
        //    float rot = Vector2.Angle(last, first);
        //    gameObject.transform.rotation = Quaternion.Euler(0, 0, rot);
        //    //should rotate the compas to match the direction based on where the player is compared to where they started the distance tracing
        //}
        //else
        //{
        //}
    }
    public void Rotate(Vector2 direct)
    {
        if (direct.x < 0) { }
        float dir = Mathf.Atan2(direct.y, direct.x) * Mathf.Rad2Deg;
        //does the actual rotation
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, dir));
    }
}
