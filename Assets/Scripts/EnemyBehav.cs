using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehav : MonoBehaviour
{
    public int hp;
    public GameObject deathPart;
    private bool hit;
    public float hitRadius = 0.1f;
    public LayerMask whatIsHit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hit = Physics2D.OverlapCircle(transform.position, hitRadius, whatIsHit);
        if (hit)
        {
            ReciveDamage(1);
            GameObject[] bullets = GameObject.FindGameObjectsWithTag("bullet");
            GameObject closestbullet = null;
            foreach (GameObject bullet in bullets)
            {
                if (closestbullet == null)
                {
                    closestbullet = bullet;
                }
                else if (Vector3.Magnitude(closestbullet.transform.position - transform.position) > Vector3.Magnitude(bullet.transform.position - transform.position))
                {
                    closestbullet = bullet;
                }
            }

            if (closestbullet != null)
            {
                Destroy(closestbullet);
            }
        }

        if (hp <= 0)
        {
            GameObject newDeathPart = Instantiate(deathPart, transform);
            newDeathPart.transform.parent = null;
            Destroy(gameObject);
        }
    }

    public void ReciveDamage(int damage)
    {
        hp -= damage;
    }


}
