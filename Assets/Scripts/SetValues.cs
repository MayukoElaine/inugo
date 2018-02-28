using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetValues : MonoBehaviour {

    private float Energy;
    private float Fullness;
    private float Hygiene;
    private float Fun;
    private float Training;
    private int EXP;
    private int Level;

    private string Shiba;
    private string Hokkaido;
    private string Akita;

    // Use this for initialization
    void Start () {

        PlayerPrefs.SetFloat("Energy",0.5f);
        PlayerPrefs.SetFloat("Fullness", 0.3f);
        PlayerPrefs.SetFloat("Hygiene", 0.4f);
        PlayerPrefs.SetFloat("Fun", 0f);
        PlayerPrefs.SetFloat("Training", 0.1f);
        PlayerPrefs.SetInt("EXP", 0);
        PlayerPrefs.SetInt("Level",1);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChooseShiba()
    {
        PlayerPrefs.SetString("DogType","Shiba");
    }

    public void ChooseHokkaido()
    {
        PlayerPrefs.SetString("DogType", "Hokkaido");
    }

    public void ChooseAkita()
    {
        PlayerPrefs.SetString("DogType", "Akita");
    }
}
