using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformToParent : MonoBehaviour {

    public Transform panel;
    //public Transform trashparent;

	// Use this for initialization
	void Start () {
        panel = this.transform.GetChild(1);
       // trashparent = this.transform.GetChild(0);
	}
	
	// Update is called once per frame
	void Update () {
        panel.transform.position = this.transform.position;
        //trashparent.transform.position = this.transform.position;
	}


}
