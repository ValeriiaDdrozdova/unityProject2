using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForEachExample : MonoBehaviour
{
    private GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            int count = 0;
            GameObject closestEnemy = null;
            foreach (GameObject enemy in enemies)
            {
                count += 1;
                if(closestEnemy == null)
                {
                    closestEnemy = enemy;
                }
                else if(Vector3.Magnitude(closestEnemy.transform.position - transform.position) > Vector3.Magnitude(enemy.transform.position - transform.position))
                {
                    closestEnemy = enemy;
                }
            }
            Debug.Log(count);
            Debug.Log(closestEnemy);
        }
    }
}
