using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{

    private float RotationSpeed = 3f;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(Vector3.up * RotationSpeed);
       // transform.Translate(Vector3.down * Time.deltaTime);


    }
}
