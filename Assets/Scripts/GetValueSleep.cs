using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetValueSleep : MonoBehaviour {

    public float Energy;
    public float Fullness;
    public float Hygiene;
    public float Fun;
    public float Training;

    public float HungryValue = 0.5f;
    public float DirtyValue = 0.8f;
    public float RelaxValue = 0.3f;


    // Use this for initialization
    void Start () {

        Energy = PlayerPrefs.GetFloat("Energy");
        Fullness = PlayerPrefs.GetFloat("Fullness");
        Hygiene = PlayerPrefs.GetFloat("Hygiene");
        Fun = PlayerPrefs.GetFloat("Fun");
        Training = PlayerPrefs.GetFloat("Training");

        //Debug.Log("Energy" + Energy);

    }
	
	// Update is called once per frame
	void Update () {

        PlayerPrefs.SetFloat("Energy",1f);
        PlayerPrefs.SetFloat("Fullness", Fullness - HungryValue);
        PlayerPrefs.SetFloat("Hygiene", Hygiene - DirtyValue);
        PlayerPrefs.SetFloat("Fun", 0f);
        PlayerPrefs.SetFloat("Training", Training - RelaxValue);

    }
}
