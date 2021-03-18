using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightCollision : MonoBehaviour
{
    public bool isRightCollide;

    public void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Ground") || (other.gameObject.tag == "Prefab_tag"))
        {
            //Debug.Log("Nie mogę w prawo");
            isRightCollide = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if ((other.gameObject.tag == "Ground") || (other.gameObject.tag == "Prefab_tag"))
        {
            //Debug.Log("Mogę w prawo");
            isRightCollide = false;
        }
    }
    void Start()
    {
        isRightCollide = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
