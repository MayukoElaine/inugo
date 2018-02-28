using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CleaningManager : MonoBehaviour {

    public float Cleanliness;
    public Image CleanlinessBar;
    private TrashSpawning TrashSpawning;
    private float AddAmount;

    public float delay;

    public float Training;
    public float Energy;
    public int EXP;

    public GameObject TrainingCompleted;

    public string dogtype;
    public GameObject Shiba;
    public GameObject Hokkaido;
    public GameObject Akita;

    // Use this for initialization
    void Start () {
        Cleanliness = 0f;
        TrashSpawning = GetComponent<TrashSpawning>();
        Training = PlayerPrefs.GetFloat("Training");
        Energy = PlayerPrefs.GetFloat("Energy");
        EXP = PlayerPrefs.GetInt("EXP");

        Debug.Log("Training"+ Training);
        Debug.Log("Energy" + Energy);
        Debug.Log("EXP" + EXP);

        TrainingCompleted.SetActive(false);

        dogtype = PlayerPrefs.GetString("DogType");


        if (dogtype == "Shiba")
        {
            Shiba.SetActive(true);
            Hokkaido.SetActive(false);
            Akita.SetActive(false);

            PlayerPrefs.SetString("DogType", "Shiba");

        }

        else if (dogtype == "Hokkaido")
        {
            Hokkaido.SetActive(true);
            Shiba.SetActive(false);
            Akita.SetActive(false);

            PlayerPrefs.SetString("DogType", "Hokkaido");

        }

        else if (dogtype == "Akita")
        {
            Akita.SetActive(true);
            Hokkaido.SetActive(false);
            Shiba.SetActive(false);

            PlayerPrefs.SetString("DogType", "Akita");
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (Cleanliness == 1f)
        {
            StartCoroutine(LoadLevelAfterDelay(delay));
            //Debug.Log("Switch Scene");

            PlayerPrefs.SetFloat("Training", Training + 0.3f);
            PlayerPrefs.SetFloat("Energy", Energy - 0.4f);
            PlayerPrefs.SetInt("EXP", EXP + 30);

            TrainingCompleted.SetActive(true);
            
        }
 
    }

    public void AddClean()
    {
        AddAmount = 1f / TrashSpawning.TrashCount;
        Cleanliness = Cleanliness + AddAmount;
        CleanlinessBar.fillAmount = Cleanliness;
    }

    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Sandbox");

    }
}
