using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundTouch : MonoBehaviour
{
    public bool isGrounded;
    
    public void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Ground") || (other.gameObject.tag == "Prefab_tag"))
        {
            //Debug.Log("OnTriggerEnter");
            isGrounded = true;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if ((other.gameObject.tag == "Ground") || (other.gameObject.tag == "Prefab_tag"))
        {
            //Debug.Log("OnTriggerExit");
            isGrounded = false;
        }
    }

    void Start()
    {
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded)
        {
            Debug.Log("dotykam ziemie");
        }
        else
        {
            Debug.Log("nie dotykam ziemi");
        }

        if (Input.GetButton("Jump"))
        {
            //Debug.Log("zaczynam skakać");
        }
    }
}
