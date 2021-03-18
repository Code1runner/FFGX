using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftCollision : MonoBehaviour
{
    public bool isLeftCollide;

    public void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Ground") || (other.gameObject.tag == "Prefab_tag"))
        {
            //Debug.Log("Nie mogę w lewo");
            isLeftCollide = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if ((other.gameObject.tag == "Ground") || (other.gameObject.tag == "Prefab_tag"))
        {
            //Debug.Log("Mogę w lewo");
            isLeftCollide = false;
        }
    }
    void Start()
    {
        isLeftCollide = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
