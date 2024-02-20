using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.UI;
using UnityEngine;

public class Distance : MonoBehaviour
{
    float distance;
    public float distSinceLast;
    public List<Vector2> travelPoints;
    public GameObject pc;
    public GameObject textobj;
    TextMesh text;
    // Start is called before the first frame update
    void Start()
    {
        text = textobj.GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Steps Taken: " + distance.ToString();
    }

    private void FixedUpdate()
    {
        Vector2 last = travelPoints.Last();
        float dist = Vector2.Distance(last, pc.transform.position);
        if (dist > distSinceLast)
        {
            travelPoints.Add(pc.transform.position);
            distance += dist;
        }
    }

    //resets the list with the button use and sets the first point in the travel distance list to the objects current position
    public void Restart()
    {
        travelPoints = new List<Vector2>();
        Vector2 cur = pc.transform.position;
        travelPoints.Add(cur);
        distance = 0;
    }
}
