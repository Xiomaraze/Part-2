using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    Rigidbody2D rigbody;
    public float moveSpeed;
    Vector2 direction;
    Vector2 move;
    public float weaponDestroy;
    float objAge;
    // Start is called before the first frame update
    void Start()
    {
        rigbody = GetComponent<Rigidbody2D>();
        move = new Vector2(Screen.width, 0);
        direction = GetComponent<Rigidbody2D>().position;
    }

    private void FixedUpdate()
    {
        direction = move - (Vector2)transform.position;
        rigbody.MovePosition(rigbody.position + direction.normalized * moveSpeed * Time.deltaTime);
        objAge += Time.deltaTime;
        if (objAge >= weaponDestroy)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.tag == "Player")
        //{

        //} left these lines in for the chance of hitting things not the player also destroys the weapon
        collision.gameObject.SendMessage("TakeDamage", 1, SendMessageOptions.DontRequireReceiver);
        Destroy(gameObject);
    }
}
