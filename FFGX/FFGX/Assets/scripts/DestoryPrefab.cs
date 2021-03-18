using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryPrefab : MonoBehaviour
{
    public GameObject[] postac;
    public float wspolrzednePostaci;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        postac = GameObject.FindGameObjectsWithTag("Player");
        wspolrzednePostaci = postac[0].transform.position.z;
        if((wspolrzednePostaci - transform.position.z) > 350)
        {
            Destroy(gameObject);
        }

    }
}
