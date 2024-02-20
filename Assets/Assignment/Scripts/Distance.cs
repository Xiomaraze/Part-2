using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Distance : MonoBehaviour
{
    float distance;
    public float distSinceLast;
    public List<Vector2> travelPoints;
    public GameObject pc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 last = travelPoints.Last();
        float dist = Vector2.Distance(last, transform.position);
        if (dist > distSinceLast)
        {
            travelPoints.Add(transform.position);
            distance += dist;
        }
    }

    //resets the list with the button use and sets the first point in the travel distance list to the objects current position
    public void Restart()
    {
        travelPoints = new List<Vector2>();
        Vector2 cur = transform.position;
        travelPoints.Add(cur);
        distance = 0;
    }
}
