using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class Distance : MonoBehaviour
{
    float distance;
    public float distSinceLast;
    public List<Vector2> travelPoints;
    public GameObject pc;
    public GameObject textobj;
    TextMeshProUGUI text;

    public GameObject compass;
    Direction dirScript;
    Animator anim;

    public GameObject ghost;
    // Start is called before the first frame update
    void Start()
    {
        text = textobj.GetComponent<TextMeshProUGUI>();
        travelPoints = new List<Vector2>();
        Vector2 current = pc.transform.position;
        travelPoints.Add(current);
        dirScript = compass.GetComponent<Direction>();
        ghost.transform.position = current;
        anim = pc.GetComponent<Animator>();
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
            Vector2 direct = last - travelPoints.First();
            direct.Normalize();
            compass.SendMessage("Rotate", direct);
        }
    }

    //resets the list with the button use and sets the first point in the travel distance list to the objects current position
    public void Restart()
    {
        anim.SetTrigger("Reset");
        travelPoints = new List<Vector2>();
        Vector2 cur = pc.transform.position;
        travelPoints.Add(cur);
        distance = 0;
        ghost.transform.position = cur;
    }
}
