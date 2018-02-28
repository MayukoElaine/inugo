using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBubble : MonoBehaviour {

	// Use this for initialization
	void Start () {

        DestroyBubbleAfterSec();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void DestroyBubbleAfterSec()
    {
        if (this.gameObject.tag == "Bubble")
        {
            Destroy(this.gameObject, 1f);
        }
        else
            Destroy(this.gameObject, 3f);
    }
}
