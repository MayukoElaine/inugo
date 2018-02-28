using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogLookRotation : MonoBehaviour {

    public Transform target;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 relativePos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        transform.rotation = rotation;
       // this.transform.rotation = (0, rotation, 0);
    }
}
