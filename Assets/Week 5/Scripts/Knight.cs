using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    Rigidbody2D rig;
    Animator animator;
    Vector2 destination; //position
    Vector2 direction; //direction
    public float speed = 3;
    bool hurt;
    public float hp;
    public float maxHp = 5;
    bool dead;
    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        hurt = false;
        hp = maxHp;
        dead = false;
    }

    // Update is called once per frame
    void Update() //input taken in update
    {
        if ((Input.GetMouseButtonDown(0)) && hurt==false)
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            animator.SetFloat("Movement", direction.magnitude);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Attack();
        }
    }

    private void FixedUpdate() //movement and collision in fixed update
    {
        if (dead) return;
        direction = destination - (Vector2)transform.position;
        if (direction.magnitude < 0.1)
        {
            direction = Vector2.zero; //checks if the player is close enough to the destination that they have arrived and turns the movement to 0
        }
        rig.MovePosition(rig.position + direction.normalized * speed * Time.deltaTime); //normalized to ensure player doesnt teleport and instead moves at "standard" player movement speed
    }

    private void OnMouseDown()
    {
        if (dead) return;
        hurt = true;
        gameObject.SendMessage("TakeDamage", 1, SendMessageOptions.DontRequireReceiver);
    }

    private void OnMouseUp()
    {
        hurt = false;
    }

    public void TakeDamage(float dmg)
    {
        Debug.Log("calling damage");
        hp -= dmg;
        hp = Mathf.Clamp(hp, 0, maxHp);
        if (hp <= 0)
        {
            animator.SetTrigger("Death");
            dead = true;
        }
        else
        {
            animator.SetTrigger("TakeDamage");
        }
    }

    public void Attack()
    {
        animator.SetTrigger("Attack");
    }
}
