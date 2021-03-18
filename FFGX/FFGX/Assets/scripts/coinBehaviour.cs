using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinBehaviour : MonoBehaviour
{
    public GameObject score;
    private void Start()
    {
        score = GameObject.FindGameObjectWithTag("score");
        transform.Rotate(90, 0, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup();
        }

        if (other.CompareTag("Prefab_tag"))
        {
            GoUp();
        }

        void Pickup()
        {
            score.GetComponent<ScoreDisplay>().coins += 10;
            Destroy(gameObject);
        }

        void GoUp()
        {
            transform.position = transform.position + new Vector3(0,6,0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0 , 100 * Time.deltaTime);
    }
}
