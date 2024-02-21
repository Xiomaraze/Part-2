using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    Vector2 dest;
    Vector2 distance;
    float buffer;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        buffer = 0.1f;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {

            }
            else
            {
                dest = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
    }

    private void FixedUpdate()
    {
        distance = dest - (Vector2)transform.position;
        if (distance.magnitude < buffer)
        {
            distance = Vector2.zero;
        }
        rb.MovePosition(rb.position + distance.normalized * speed * Time.deltaTime);
        anim.SetFloat("Horizontal", distance.magnitude);
        //scootch towards the target destination
    }
    public void Recolor()
    {
        anim.SetTrigger("Recolor");
    }
}
