using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class CharBehaviour : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public FixedJoystick joystick;
    public GameObject wasp;
    public Transform spawn;
    public ParticleSystem particleSystem;
    public AudioContrl audioContrl;
    public GameObject bullet;
    public Transform rbullet, lbullet;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !audioContrl.player.isPlaying)
        {
            audioContrl.PunchSound();
        }

        if (Input.GetMouseButtonDown(1))
        {
            GameObject newbullet; 
            if (spriteRenderer.flipX)
            {
                newbullet = Instantiate(bullet, lbullet);
                newbullet.GetComponent<bullet>().direction = -1;
            }
            else
            {
                newbullet = Instantiate(bullet, rbullet);
                newbullet.GetComponent<bullet>().direction = 1;
            }
        }

        if(joystick.Horizontal > 0)
        {
            rigidbody.velocity = new Vector2(1f, rigidbody.velocity.y);
        }
        if(joystick.Horizontal < 0)
        {
            rigidbody.velocity = new Vector2(-1f, rigidbody.velocity.y);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rigidbody.velocity = new Vector2(1f, rigidbody.velocity.y);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.velocity = new Vector2(-1f, rigidbody.velocity.y);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce (new Vector2(0f, 200f));
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameObject lastEnemy = Instantiate(wasp, spawn);
        }
    }

    public void Jump()
    {
        rigidbody.AddForce(new Vector2(0f, 200f));
    }

    public void RecieveDamage()
    {
        particleSystem.Play();
    }


}
