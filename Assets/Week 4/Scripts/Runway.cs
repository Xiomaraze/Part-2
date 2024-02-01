using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runway : MonoBehaviour
{
    // Start is called before the first frame update
    BoxCollider2D boxCollider;
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Plane plane = collision.GetComponent<Plane>();
    //    if (boxCollider.OverlapPoint(collision.transform.position))
    //    {
    //        plane.landed = true;
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Plane plane = collision.gameObject.GetComponent<Plane>();
        if (boxCollider.OverlapPoint(collision.gameObject.transform.position))
        {
            plane.landed = true;
        } //something in here is not triggering correctly and i dont know why
        //i forgot to actually attach the script to the runway
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
