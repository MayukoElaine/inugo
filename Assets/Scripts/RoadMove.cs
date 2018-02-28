using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoadMove : MonoBehaviour {

    private float movespeed = 10;

    public float Training;
    public float Energy;
    public int EXP;

    public bool Level1Pass;
    public bool Level2Pass;
    public bool Level3Pass;
    public bool Level4Pass;
    public bool Level5Pass;

    public GameObject ProgressBar;
    public Image oneR;
    public Image twoR;
    public Image threeR;
    public Image fourR;
    public Image fiveR;

    public Image oneG;
    public Image twoG;
    public Image threeG;
    public Image fourG;
    public Image fiveG;

    public float delay;

    public bool Onlvl1;
    public bool Onlvl2;
    public bool Onlvl3;
    public bool Onlvl4;
    public bool Onlvl5;

    public GameObject TrainingCompleted;

    public string dogtype;
    public GameObject Shiba;
    public GameObject Hokkaido;
    public GameObject Akita;

    public AudioSource Correct;
    public AudioSource Wrong;

    // Use this for initialization
    private void Awake()
    {
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

    void Start () {
  
        Training = PlayerPrefs.GetFloat("Training");
        Energy = PlayerPrefs.GetFloat("Energy");
        EXP = PlayerPrefs.GetInt("EXP");

        Debug.Log("Training" + Training);
        Debug.Log("EXP" + EXP);
        Debug.Log("Energy" + Energy);

        

        Invoke("SetValueEnergy", 0.1f);

        transform.position = new Vector3(-0.7296638f, 4.962059f,-2.037379f);
        //DogRun = GameObject.FindObjectOfType<DogRun>().GetComponent<DogRun>();

        Onlvl1 = true;

        TrainingCompleted.SetActive(false);

        oneG.enabled = false;
        twoG.enabled = false;
        threeG.enabled = false;
        fourG.enabled = false;
        fiveG.enabled = false;

        oneR.enabled = false;
        twoR.enabled = false;
        threeR.enabled = false;
        fourR.enabled = false;
        fiveR.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        // rigid.velocity = new Vector3();
        //transform.Translate(Vector3.back * movespeed * Time.deltaTime);

        Invoke("RoadMoving",3f);

        StageManager();

        EndGame();


    }

    public void FasterSpeed()
    {
        movespeed = 20;
    }
    public void NormalSpeed()
    {
        movespeed = 10;
    }

    void SetValueEnergy()
    {
        PlayerPrefs.SetFloat("Energy", Energy - 0.4f);
    }

    void StageManager() //After Stage position
    {
        if (transform.position.z < -55.2f ) //level 1
        {
            Onlvl2 = true;
            Onlvl1 = false;

            if (Level1Pass)
            {
                //one.GetComponent<Image>().color = Color.green;
                oneG.enabled = true;
                //CorrectSFX();

            }

            else
            {
                //one.GetComponent<Image>().color = Color.red;
                oneR.enabled = true;
                WrongSFX();
            }
        }

        if (transform.position.z < -84.9f ) //level 2
        {
            Onlvl3 = true;
            Onlvl2 = false;

            if (Level2Pass)
            {
                //two.GetComponent<Image>().color = Color.green;
                twoG.enabled = true;
                CorrectSFX();
            }
            else
            {
                //two.GetComponent<Image>().color = Color.red;
                twoR.enabled = true;
                WrongSFX();
            }
        }

        if (transform.position.z < -122.4f ) //level 3
        {
            Onlvl4 = true;
            Onlvl3 = false;

            if (Level3Pass)
            {
                //three.GetComponent<Image>().color = Color.green;
                threeG.enabled = true;
                CorrectSFX();
            }
            else
            {
                //three.GetComponent<Image>().color = Color.red;
                threeR.enabled = true;
                WrongSFX();
            }
        }

        if (transform.position.z < -169.5f ) // level 4
        {
            Onlvl5 = true;
            Onlvl4 = false;

            if (Level4Pass)
            {
                //four.GetComponent<Image>().color = Color.green;
                fourG.enabled = true;
                CorrectSFX();
            }
            else
            {
                //four.GetComponent<Image>().color = Color.red;
                fourR.enabled = true;
                WrongSFX();
            }

        }

        if (transform.position.z < -233.7f  ) // level 5
        {

            PlayerPrefs.SetFloat("Training", Training + 0.2f);
            PlayerPrefs.SetInt("EXP",EXP + 30);
            TrainingCompleted.SetActive(true);

            if (Level5Pass)
            {
                //five.GetComponent<Image>().color = Color.green;
                fiveG.enabled = true;
                CorrectSFX();
            }
            else
            {
                //five.GetComponent<Image>().color = Color.red;
                fiveR.enabled = true;
                WrongSFX();
            }
        }
    }

    void EndGame()
    {
        if (transform.position.z < -269f)
        {
            StartCoroutine(LoadLevelAfterDelay(delay));
            //PlayerPrefs.SetFloat("Training", Training + 0.3f);
        }
    }

    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Sandbox");

    }

    void RoadMoving()
    {
        transform.Translate(Vector3.back * movespeed * Time.deltaTime);
    }

    void CorrectSFX()
    {
        Correct.Play();
    }

    void WrongSFX()
    {
        Wrong.Play();
    }
    
}
