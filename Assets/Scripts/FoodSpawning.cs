using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawning : MonoBehaviour
{

    private float SpawnTime;
    public GameObject DogBoneprefab;
    public GameObject FishBoneprefab;

    // Use this for initialization
    void Start()
    {

        //SpawnTime = Time.time + 3;
    }

    // Update is called once per frame
    void Update()
    {


        if (SpawnTime < Time.time)
        {
            Vector3 position = new Vector3(Random.Range(-3.0f, 3.0f), 12f, 0);
            Instantiate(DogBoneprefab, position, Quaternion.identity);

            Vector3 position1 = new Vector3(Random.Range(-3.0f, 3.0f), 12f, 0);
            Instantiate(FishBoneprefab, position1, Quaternion.identity);


            SpawnTime = Time.time + 10;
        }
    }
}

