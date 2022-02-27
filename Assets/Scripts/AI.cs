using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AI : MonoBehaviour
{
    public AIDestinationSetter aiDestinationSetter;
    public Transform patrolPoint1, patrolPoint2, player;
    private int currentState;
    public float distance;
    private bool goingToFirstPoint;

    // Start is called before the first frame update
    void Start()
    {
        aiDestinationSetter = GetComponent<AIDestinationSetter>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        patrolPoint1.parent = null;
        patrolPoint2.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        currentState = BehaviourType();
        if(currentState == 0)
        {
            if(goingToFirstPoint && Vector3.Magnitude(patrolPoint1.position - transform.position) > 0.1f)
            {
                aiDestinationSetter.target = patrolPoint1;
            }
            else
            {
                goingToFirstPoint = false;
            }

            if(!goingToFirstPoint && Vector3.Magnitude(patrolPoint2.position - transform.position) > 0.1f)
            {
                aiDestinationSetter.target = patrolPoint2;
            }
            else
            {
                goingToFirstPoint = true;
            }
        }
        else if(currentState == 1)
        {
            aiDestinationSetter.target = player;
        }
    }

    private int BehaviourType()
    {
        int type = 0;
        Vector3 vectorDistance = player.position - transform.position;
        if (Vector3.Magnitude(vectorDistance) > distance)
        {
            type = 0;
        }
        else
        {
            type = 1;
        }

        return type;
    }
}
