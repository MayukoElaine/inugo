using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroomManager : MonoBehaviour {

    public CleaningManager CleaningManager;

    public GameObject broomModel;

    // Use this for initialization
    void Start() {
        
        broomModel = transform.GetChild(0).gameObject;
        broomModel.SetActive(false);
    }

    // Update is called once per frame
    void Update() {

    }

    public void Clean()
    {
        gameObject.SetActive(true);
        broomModel.SetActive(true);
       
    }

    public void HideBroom()
    {
        gameObject.SetActive(false);
        CleaningManager.AddClean();

    }
}

