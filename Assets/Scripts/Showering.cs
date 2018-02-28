using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Showering : MonoBehaviour {

    public GameObject Bubbles;

    public GameObject showerPanel;

    private DragHandler dragHandler;

    private GameObject SpawnedBubbles;
 

    void Start()
    {

    }
	
	// Update is called once per frame
	void Update () {
        
        //BubbleSpawn();

        //SpawnedBubbles = GameObject.FindGameObjectWithTag("Bubble");

        //Destroy(SpawnedBubbles, 1f);
    }

    public void BubbleSpawn()
    {
       
        Vector3 position = new Vector3(Random.Range(-20.0f, 20.0f), Random.Range(-50.0f, 50.0f),0);

        GameObject newBubble = Instantiate(Bubbles, position, Quaternion.identity) as GameObject;
        newBubble.transform.SetParent(showerPanel.transform, false);
        
    }
}
