using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawning : MonoBehaviour {

    public GameObject Trash;
    public GameObject[] Trashes;
    public int TrashCount = 0;

    public Transform WorldSpaceCanvas;

	// Use this for initialization
	void Start () {

        InvokeRepeating("TrashSpawn",0.1f, 0.1f);
        //TrashSpawn();
	}
	
	// Update is called once per frame
	void Update () {

        Trashes = GameObject.FindGameObjectsWithTag("Trash");


        if (TrashCount == 5)
        {
            CancelInvoke();
        }
    }

    public void TrashSpawn()
    {
        Vector3 position = new Vector3(Random.Range(-340f, 390f), -224.8f, Random.Range(268f, -108f));
        GameObject go = Instantiate(Trash, position, Quaternion.identity);
        TrashCount = TrashCount +1;

        //go.transform.parent = WorldSpaceCanvas;
        go.transform.SetParent(WorldSpaceCanvas,false);

    }

}
