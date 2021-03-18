using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchGFX : MonoBehaviour
{
    public Vector3 GFXPosition = new Vector3(0, -0.5f, 0);
    public Vector3 originalPosition;
    public Vector3 originalHeight;
    public Vector3 reducedHeight = new Vector3(1,0.5f,1);

    void Start()
    {
        originalHeight = gameObject.transform.localScale;
        originalPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            gameObject.transform.localScale = reducedHeight;
            //gameObject.transform.position = GFXPosition;
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            //gameObject.transform.position = originalPosition;
            gameObject.transform.localScale = originalHeight;
        }
    }
}
