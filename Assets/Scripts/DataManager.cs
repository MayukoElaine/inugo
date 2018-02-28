using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DataManager : MonoBehaviour {

    public float Energy;
    public float Fullness;
    public float Hygiene;
    public float Fun;
    public float Training;

    public int EXP;
    public int Level;
    public string dogtype;

    public LoadSceneOnClick LoadSceneOnclick;

    // Use this for initialization
    void Start () {
        Energy = PlayerPrefs.GetFloat("Energy");
        Fullness = PlayerPrefs.GetFloat("Fullness");
        Hygiene = PlayerPrefs.GetFloat("Hygiene");
        Fun = PlayerPrefs.GetFloat("Fun");
        Training = PlayerPrefs.GetFloat("Training");
        EXP = PlayerPrefs.GetInt("EXP");
        Level = PlayerPrefs.GetInt("Level");
        dogtype = PlayerPrefs.GetString("DogType");

        Debug.Log("EXP" + EXP);
        Debug.Log("Level"+ Level);

        LoadSceneOnclick = GameObject.FindObjectOfType<LoadSceneOnClick>().GetComponent<LoadSceneOnClick>();

    }
	
	// Update is called once per frame
	void Update () {


    }

    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
    }


    public void FirstTimeClick()
    {
        if (Level == 1 && EXP == 0)
        {

        }
        else
            LoadSceneOnclick.LoadByIndex(1);



    }
}
