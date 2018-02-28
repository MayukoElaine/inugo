using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DogManager : MonoBehaviour {

    public float Energy;
    public float Fullness;
    public float Hygiene ;
    public float Fun ;
    public float Training;

    public Image I_energy;
    public Image I_fullness;
    public Image I_hygiene;
    public Image I_fun;
    public Image I_training;
    public Image I_EXP;
    public Text Lvl;

    //private float IncreaseSpeed = 0.01f;
    //private float DecreaseSpeed = 0.1f;

    public Image I_fun2;
    public GameObject FunBar;
    public Image I_Hygiene2;
    public GameObject HygieneBar;

    private GameObject Dog;
    public GameObject FoodBowl;
    public GameObject WaterBowl;

    private Vector3 FoodPosition;
    private Vector3 WaterPosition;
    private Vector3 DogOriPosition;

    private Animator DogAnim;

    private Quaternion LookRotation;
    private Vector3 RotateDirection;

    public bool isEaten = false;
    public bool isEating = false;
    public bool isDrank = false;
    public bool isDrinking = false;

    private Quaternion LookAtCamera;
    private Vector3 RotateCameraDirection;
    public Camera Camera;

    public int EXP;
    public int Level;
    public int[] toLevelUp;
    public float expfloat;

    public string dogtype;
    public GameObject Shiba;
    public GameObject Hokkaido;
    public GameObject Akita;

    public GameObject ShibaButton;
    public GameObject HokkaidoButton;
    public GameObject AkitaButton;

    public bool isLowEnergy;
    public Text LowEnergyText;

    public GameObject DeductEnergyEff;
    public GameObject DeductFullnessEff;
    public GameObject DeductHygieneEff;
    public GameObject DeductTrainngEff;
    public GameObject DeductFunEff;
    public GameObject AddEnergyEff;
    public GameObject AddFullnessEff;
    public GameObject AddHygieneEff;
    public GameObject AddTrainingEff;
    public GameObject AddFunEff;
    public GameObject AddEXPEff;

    // Use this for initialization

    void Start () {

        ShibaButton.SetActive(false);
        HokkaidoButton.SetActive(false);
        AkitaButton.SetActive(false);

#region compare class
        int OldEXP = PlayerPrefs.GetInt("OldEXP");
        float OldEnergy = PlayerPrefs.GetFloat("OldEnergy");
        float OldFullness = PlayerPrefs.GetFloat("OldFullness");
        float OldHygiene = PlayerPrefs.GetFloat("OldHygiene");
        float OldFun = PlayerPrefs.GetFloat("OldFun");
        float OldTraining = PlayerPrefs.GetFloat("OldTraining");

        #endregion

        /*
        if (Energy < PlayerPrefs.GetFloat("Energy"))
        {
            Debug.Log("-Energy");
            Instantiate(DeductEnergy);
        }
        else if (Energy > PlayerPrefs.GetFloat("Energy"))
        {
            Debug.Log("+Energy");
        }*/

        Energy = PlayerPrefs.GetFloat("Energy");
        Fullness = PlayerPrefs.GetFloat("Fullness");
        Hygiene = PlayerPrefs.GetFloat("Hygiene");
        Fun = PlayerPrefs.GetFloat("Fun");
        Training = PlayerPrefs.GetFloat("Training");
        EXP = PlayerPrefs.GetInt("EXP");
        Level = PlayerPrefs.GetInt("Level");

        #region Compare

        //exp
        if (EXP > OldEXP)
        {
            Instantiate(AddEXPEff);
            //AddEXPEff.transform.SetParent(Shiba.transform);
        }
        PlayerPrefs.SetInt("OldEXP", EXP);

        //energy
        if (Energy > OldEnergy)
        {
            Instantiate(AddEnergyEff);
        }
        else if (Energy < OldEnergy)
        {
            Instantiate(DeductEnergyEff);
        }
        PlayerPrefs.SetFloat("OldEnergy",Energy);

        //hygiene
        if (Hygiene > OldHygiene)
        {
            Instantiate(AddHygieneEff);
        }
        else if (Hygiene < OldHygiene)
        {
            Instantiate(DeductHygieneEff);
        }
        PlayerPrefs.SetFloat("OldHygiene", Hygiene);

        //fun
        if (Fun > OldFun)
        {
            //Instantiate
        }


        #endregion

        Debug.Log("Energy" + Energy);
        //Debug.Log("Fullness" + Fullness);
        //Debug.Log("Hygiene" + Hygiene);
        //Debug.Log("Fun" + Fun);
        Debug.Log("Training" + Training);
        Debug.Log("EXP" + EXP);

        dogtype = PlayerPrefs.GetString("DogType");


        if (dogtype == "Shiba")
        {
            Shiba.SetActive(true);
            Hokkaido.SetActive(false);
            Akita.SetActive(false);

            PlayerPrefs.SetString("DogType", "Shiba");

            ShibaButton.SetActive(true);

        }

        else if (dogtype == "Hokkaido")
        {
            Hokkaido.SetActive(true);
            Shiba.SetActive(false);
            Akita.SetActive(false);

            PlayerPrefs.SetString("DogType", "Hokkaido");

            HokkaidoButton.SetActive(true);

        }

        else if (dogtype == "Akita")
        {
            Akita.SetActive(true);
            Hokkaido.SetActive(false);
            Shiba.SetActive(false);

            PlayerPrefs.SetString("DogType", "Akita");

            AkitaButton.SetActive(true);
        }

        FunBar.SetActive(false);

        Dog = GameObject.FindGameObjectWithTag("Player");
        DogAnim = Dog.GetComponent<Animator>();

        DogOriPosition = Dog.transform.position;

        Dog.GetComponent<DogLookRotation>().enabled = true;

        StayZero();

        LowEnergy();
        LowEnergyText.enabled = false;

        if (Level == 1 && EXP == 0)
        {
            EXP++;
        }
    }

    // Update is called once per frame
    void Update() {

        I_energy.fillAmount = Energy;
        I_fullness.fillAmount = Fullness;
        I_hygiene.fillAmount = Hygiene;
        I_fun.fillAmount = Fun;
        I_fun2.fillAmount = Fun;
        I_training.fillAmount = Training;
        I_EXP.fillAmount = expfloat;
        Lvl.text = Level.ToString();

        //expfloat = (float)EXP / toLevelUp[Level];

        if (Fullness >= 1f)
        {
            Fullness = 1f;
        }

        FoodPosition = FoodBowl.transform.position;
        WaterPosition = WaterBowl.transform.position;

        if (Dog.transform.position == FoodPosition)
        {
            DogAnim.SetBool("IsEat", true);
            DogAnim.SetBool("IsWalk", false);

            isEating = true;
            

        }
        else if (Dog.transform.position == WaterPosition)
        {
            DogAnim.SetBool("IsDrink", true);
            DogAnim.SetBool("IsWalk", false);

            isDrinking = true;
        }
        else if (Dog.transform.position == DogOriPosition)
        {
            DogAnim.SetBool("IsIdle", true);
            DogAnim.SetBool("IsWalk", false);

            Dog.GetComponent<DogLookRotation>().enabled = true;

            if (isEating)
            {
                isEaten = true;
                isEating = false;

            }

            else if (isDrinking)
            {
                isDrank = true;
                isDrinking = false;
            }

        }

        RotateDirection = (DogOriPosition - transform.position);
        LookRotation = Quaternion.LookRotation(RotateDirection);

        RotateCameraDirection = (Camera.transform.position - DogOriPosition);
        LookAtCamera = Quaternion.LookRotation(RotateCameraDirection);

        MaxValueOne();

        LevelUp();

        PlayerPrefs.SetInt("EXP",EXP);

        WhenEXPmax();

        if (Level != 10)
        {
            expfloat = (float)EXP / toLevelUp[Level];
        }
        else if (Level ==10 && EXP ==1000)
        {
            expfloat = 1f;
        }

    }


    public void ShowFunFillBar()
    {
        FunBar.SetActive(true);
    }

    public void UnShowFunFillBar()
    {
        FunBar.SetActive(false);
    }

    public void ShowHygieneFillBar()
    {
        HygieneBar.SetActive(true);
    }

    public void UnShowHygieneFillBar()
    {
        HygieneBar.SetActive(false);

    }

    public void AddFun()
    {
        I_fun2.fillAmount = Fun;
        I_fun.fillAmount = Fun;
        Fun = Fun + 0.1f;
    }

    public void AddHygiene()
    {
        I_Hygiene2.fillAmount = Hygiene;
        I_hygiene.fillAmount = Hygiene;
        Hygiene += 0.05f;

        AddCleaanEff();
    }
  
    public void MovetoFood()
    {
        if (Fullness != 1)
        {
            Dog.transform.position = Vector3.MoveTowards(Dog.transform.position, FoodPosition, 0.05f);
            DogAnim.SetBool("IsWalk", true);
            DogAnim.SetBool("IsIdle", false);
            isEaten = false;
        }


    }

    public void MovetoWater()
    {
        if (Fullness != 1)
        {
            Dog.transform.position = Vector3.MoveTowards(Dog.transform.position, WaterPosition, 0.01f);
            DogAnim.SetBool("IsWalk", true);
            DogAnim.SetBool("IsIdle", false);
            isDrank = false;

        }
    }

    public void ReturnPosition()
    {
        Invoke("RotateBack", 1f);
        Invoke("WalkingBack", 2f);
        //Invoke("RotateBack",1f);
        
    }

    public void RotateBack()
    {
 
        Dog.GetComponent<DogLookRotation>().enabled = false;

        Dog.transform.rotation = Quaternion.RotateTowards(transform.rotation, LookRotation, Time.deltaTime * 0.1f);

        //DogAnim.SetBool("IsWalk", true);
       // DogAnim.SetBool("IsEat", false);
       // DogAnim.SetBool("IsDrink", false);

    }
    
    public void WalkingBack()
    {
        Dog.transform.position = Vector3.MoveTowards(Dog.transform.position, DogOriPosition, 0.01f);

        DogAnim.SetBool("IsWalk", true);
        DogAnim.SetBool("IsEat", false);
        DogAnim.SetBool("IsDrink",false);
    }

    void StayZero()
    {
        if (Energy <= 0)
        {
            PlayerPrefs.SetFloat("Energy", Energy = 0);
        }
        if (Fullness <= 0)
        {
            PlayerPrefs.SetFloat("Fullness", Fullness = 0);
        }
        if (Hygiene <= 0)
        {
            PlayerPrefs.SetFloat("Hygiene", Hygiene = 0);
        }
        if (Fun <= 0)
        {
            PlayerPrefs.SetFloat("Fun", Fun = 0);
        }
        if (Training <= 0)
        {
            PlayerPrefs.SetFloat("Training", Training = 0);
        }
    }

    void MaxValueOne()
    {
        if (Hygiene >= 1)
        {
            Hygiene = 1;
        }
        if (Fun >= 1)
        {
            Fun = 1;
        }
        if (Training >= 1)
        {
            Training = 1;
        }
        if (expfloat == 1)
        {

        }
    }

    void LevelUp()
    {
        if (EXP != 1000)
        {
            if (EXP >= toLevelUp[Level])
            {
                Level++;
                //EXP = 0;
            }
        }
    }

    public void ExperienceToAdd(int expToAdd)
    {
        EXP += expToAdd;

        PlayerPrefs.SetInt("OldEXP", EXP);
    }

    void WhenEXPmax()
    {
        if (EXP >= 1000)
        {
            expfloat = 1f;
            PlayerPrefs.SetInt("EXP",1000);
        }
    }

    void LowEnergy()
    {
        if (Energy < 0.4f)
        {
            isLowEnergy = true;
        }
        else
            isLowEnergy = false;
    }

    public void LowEnergyAppear()
    {
        LowEnergyText.enabled = true;

    }

    public void LowEnergyDissapear()
    {
        LowEnergyText.enabled = false;

    }

    public void AddFoodEffect()
    {

        Instantiate(AddFullnessEff);

        if (dogtype == "Shiba")
        {
            //AddFullnessEff.transform.SetParent(Shiba.gameObject.transform);
        }
        else if (dogtype == "Hokkaido")
        {
            //AddFullnessEff.transform.SetParent(Hokkaido.gameObject.transform);
        }
        else if (dogtype == "Akita")
        {
           // AddFullnessEff.transform.SetParent(Akita.transform);
        }
    }

    public void AddCleaanEff()
    {
        Instantiate(AddHygieneEff);
    }

}
