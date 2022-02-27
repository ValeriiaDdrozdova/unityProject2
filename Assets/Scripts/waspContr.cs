using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waspContr : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vectorDistance = player.transform.position - transform.position;
        float distance = vectorDistance.magnitude;
        if(distance < 1f)
        {
            player.GetComponent<CharBehaviour>().RecieveDamage();
            Destroy(gameObject);
        }
    }
}
