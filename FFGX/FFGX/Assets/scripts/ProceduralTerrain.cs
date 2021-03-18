using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ProceduralTerrain : MonoBehaviour
{
    public GameObject terrain;
    public bool isBuilding;
    public int PrefabsNr = 8;
    public GameObject[] myPrefabs;
    public GameObject[] grounds;
    public GameObject groundPrefab;
    public GameObject spawnedPrefab;
    public float TimerForBuild = 0;
    public bool BuildOK, DestoryOK;
    public int BuildNr;
    public float FurthestZ=0;
    public Vector3 wspolrzedne;

    //coins
    public GameObject[] coins;
    public GameObject spawnedCoin;
    public float[] coinposition = new float[3] { 2.98f, 9.98f, 16.98f };
    void Start()
    {
        BuildOK = true;
        BuildNr = 0;
        for(int i = 0; i < 8; i++)
        {
            //Instantiate(myPrefabs[i], new Vector3(0, 0, 0), Quaternion.identity);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        isBuilding = terrain.GetComponent<ThirdPersonMovement>().buildTerrain;
        if (isBuilding && BuildOK)
        {
            Debug.Log("procedrualoK");
            Instantiate(groundPrefab, new Vector3(0, 0,(BuildNr)*299), Quaternion.identity);
            //spawn coinow
            for (int i = ((BuildNr) * 299); i < ((BuildNr) * 299 + 299); i+=5)
            {
                spawnedCoin = (GameObject)coins[Random.Range(0, 2)];
                Instantiate(spawnedCoin, new Vector3(coinposition[Random.Range(0, 3)], 2.44f, i), Quaternion.identity);
            }
            //koniec spawnu coinow

            wspolrzedne = new Vector3(0,0,299 * BuildNr);
            for(int i = 0; i < 6; i++)
            {
                
                grounds = GameObject.FindGameObjectsWithTag("Prefab_tag");
                foreach (GameObject element in grounds)
                {
                    if (element.transform.position.z > FurthestZ)
                    {
                        FurthestZ = element.transform.position.z;
                    }
                }
               // Debug.Log(FurthestZ);
                spawnedPrefab =(GameObject) myPrefabs[Random.Range(0, 7)];
               
                Instantiate(spawnedPrefab, new Vector3(10, 14,FurthestZ + 20), Quaternion.identity);
            }

            BuildNr++;
        }
        if (isBuilding)
        {
            BuildOK = false;
        }
        else
        {
            BuildOK = true;
        }
    }
}
