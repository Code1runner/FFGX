using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelControls : MonoBehaviour
{
    static Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("isJumping");
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            anim.SetTrigger("isSliding");
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            anim.SetTrigger("isGoingRight");
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
                anim.SetTrigger("isGoingLeft");
        }
        
    }
}
