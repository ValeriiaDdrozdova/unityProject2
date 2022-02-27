using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimContrl : MonoBehaviour
{
    private Animator animator;
    private CharBehaviour charBehaviour;
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        charBehaviour = GetComponent<CharBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if(charBehaviour.rigidbody.velocity.x > 0.01 || charBehaviour.rigidbody.velocity.x < -0.01)
        {
            animator.SetBool("walking", true);
        }
        else
        {
            animator.SetBool("walking", false);
        }
        
        if(charBehaviour.rigidbody.velocity.x < -0.1)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if(charBehaviour.rigidbody.velocity.x > 0.1)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        //animator.SetFloat("x.velocity", charBehaviour.rigidbody.velocity.x);
    }
}
