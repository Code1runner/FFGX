using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisonGameObject : MonoBehaviour
{
    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "Ground")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            Debug.Log("Dotykam ziemi");
        }

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Ground")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Dotykam ziemi");
        }
    }
}
