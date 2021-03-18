using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoins : MonoBehaviour
{
    public GameObject[] coins;
    public GameObject spawnedCoin;
    public GameObject procedurralTerrain;
    public float[] coinposition = new float[3] { 2.98f, 9.98f, 16.98f };
    
    int BuildNr=0;
    bool BuildOK = true;
    bool isBuilding;
    void Start()
    {
        
    }
    void Update()
    {
        isBuilding = procedurralTerrain.GetComponent<ProceduralTerrain>().isBuilding;
        
        if (isBuilding && BuildOK)
        {
            Debug.Log(BuildNr);
            Debug.Log("coinOK");
            for (int i = ((BuildNr) * 299); i < ((BuildNr) * 299 + 299); i++)
            {
                spawnedCoin = (GameObject)coins[Random.Range(0, 2)];
                Instantiate(spawnedCoin, new Vector3(coinposition[Random.Range(0, 2)], 2.44f, i+5), Quaternion.identity);
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
