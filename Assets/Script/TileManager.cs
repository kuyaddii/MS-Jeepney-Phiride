using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public GameObject[] hillsPrefabs;
    public float zSpawn = 0;
    public float tilelength = 25;
    public int numberoftiles = 3;
    public Transform PlayerTransform;
    void Start()
    {
       for(int i = 0; i < numberoftiles; i++)
        {
            if (i == 0)
                SpawnTile(0);
             else
                SpawnTile(2);
                SpawnTile(1);
               
            // SpawnTile(Random.Range(1, tilePrefabs.Length));  
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerTransform.position.z > zSpawn - (numberoftiles * tilelength))
        {
            if (PlayerManager.numberofcoins >= 100)
            {
                PlayerController.forwardspeed = 5;
                PlayerController.forwardspeed += 1.0f;
                hills(Random.Range(1, tilePrefabs.Length));
            }
            else
               SpawnTile(Random.Range(1, tilePrefabs.Length));
        }
       
    }
    public void SpawnTile(int tileIndex)
    {
        Instantiate(tilePrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
        zSpawn += tilelength;
       
    }
    public void hills(int tilesIndex)
    {
        Instantiate(hillsPrefabs[tilesIndex], transform.forward * zSpawn, transform.rotation);
        zSpawn += tilelength;
       
    }
}
