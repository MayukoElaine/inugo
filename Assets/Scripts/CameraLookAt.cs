﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour {

    public Transform target;

    // Use this for initialization
    void Start () {
        transform.LookAt(target);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}