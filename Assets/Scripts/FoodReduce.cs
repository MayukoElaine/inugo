using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodReduce : MonoBehaviour {

    public GameObject foodplane;
    public GameObject waterplane;

    public DogManager DogManagerS;

    private Vector3 FoodOriPosiiton;
    private Vector3 WaterOriPosition;


	// Use this for initialization
	void Start () {

        FoodOriPosiiton = foodplane.transform.position;
        WaterOriPosition = waterplane.transform.position;
       

	}
	
	// Update is called once per frame
	void Update () {
        if (foodplane.transform.position.y <= -0.085f && DogManagerS.isEaten == false)
        {
            foodplane.SetActive(false);
            DogManagerS.GetComponent<DogManager>().ReturnPosition();

        }
        if (waterplane.transform.position.y <= 0.5f && DogManagerS.isDrank == false)
        {
            waterplane.SetActive(false);
            DogManagerS.GetComponent<DogManager>().ReturnPosition();
           

        }

        if (DogManagerS.isEaten)
        {
            foodplane.transform.position = FoodOriPosiiton;
        }

        if (DogManagerS.isDrank)
        {
            waterplane.transform.position = WaterOriPosition;
        }

    }

    public void Eaten()
    {
        foodplane.transform.Translate (0,0,-0.08f);
        DogManagerS.Fullness += 0.1f;
        DogManagerS.AddFoodEffect();
    }

    public void Drinking()
    { 
        waterplane.transform.Translate(0, 0, -0.06f);
        DogManagerS.Fullness += 0.1f;
        DogManagerS.AddFoodEffect();
    }
}
