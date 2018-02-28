using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildBroom : MonoBehaviour {

    private BroomManager broomManager;
  
    

	// Use this for initialization
	void Start () {
        broomManager = GetComponentInParent<BroomManager>();
   

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Hidebroom()
    {
        broomManager.HideBroom();
    
       
    }
}
