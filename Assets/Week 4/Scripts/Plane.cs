using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Plane : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Vector2> points;
    public float newPointThreshold = 0.2f;
    Vector2 lastPos;
    LineRenderer lineRenderer;
    Vector2 currentPos;
    Rigidbody2D rigbody;
    public float speed = 1;
    public AnimationCurve landing;
    float landingtimer;

    public bool landed = false;
    
    public float collisionDist;

    SpriteRenderer spriteRenderer;
    public Sprite s1;
    public Sprite s2;
    public Sprite s3;
    public Sprite s4;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
        rigbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        speed = Random.Range(1, 3);
        float ranSprite = Random.Range(1, 4);
        if (ranSprite < 2)
        {
            spriteRenderer.sprite = s1;
        }
        else if((ranSprite >= 2) && (ranSprite < 3))
        {
            spriteRenderer.sprite = s2;
        } //note for later, greater that 2 seconds less than 3
        else if((ranSprite >= 3)  && (ranSprite < 4))
        {
            spriteRenderer.sprite = s3;
        }
        else
        {
            spriteRenderer.sprite = s4;
        }
    }

    private void FixedUpdate()
    {
        currentPos = new Vector2(transform.position.x, transform.position.y);
        if (points.Count > 0 )
        {
            Vector2 direction = points[0] - currentPos;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            rigbody.rotation = -angle;
        }
        rigbody.MovePosition(rigbody.position + (Vector2)transform.up * speed * Time.deltaTime);
    }

    private void Update()
    {
        if (landed)
        {
            landingtimer += 0.1f * Time.deltaTime;
            float interpolation = landing.Evaluate(landingtimer);
            if (transform.localScale.z < 0.1f)
            {
                Destroy(gameObject);
            }
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero * 0.75f, interpolation);
        }
        if (points.Count > 0)
        {
            if (Vector2.Distance(currentPos, points[0]) < newPointThreshold)
            {
                points.RemoveAt(0);
                for (int i = 0; i < lineRenderer.positionCount - 2; i++)
                {
                    lineRenderer.SetPosition(i, lineRenderer.GetPosition(i+1));
                }
                lineRenderer.positionCount--;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        spriteRenderer.color = Color.red;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        float dist = Vector3.Distance(gameObject.transform.position, other.transform.position);
        if (dist <= collisionDist)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        spriteRenderer.color = Color.white;
    }

    private void OnMouseDown()
    {
        points = new List<Vector2>();
        Vector2 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        points.Add(currentPosition);
        lastPos = currentPosition;
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
    }

    private void OnMouseDrag()
    {
        Vector2 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //unity may declare frustration on trying to assign a vector 3 to a vector 2, force it by appending (Vector2) before Camera
        if (Vector2.Distance(currentPosition, lastPos) > newPointThreshold)
        {
            points.Add(currentPosition);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition (lineRenderer.positionCount -1, currentPosition);
            lastPos = currentPosition;
        }
    }
}
