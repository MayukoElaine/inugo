using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour {

    public bool isShow;
    private Animator anim;

    public GameObject[] UI;


	// Use this for initialization
	void Start () {
        isShow = false;
        anim = GetComponent<Animator>();

        foreach (GameObject GO in UI )
        {
            GO.SetActive(false);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnMouseDown()
    {
        if (!isShow)
        {
            anim.SetBool("IsAppear", true);
            isShow = true;

            foreach (GameObject GO in UI)
            {
                GO.SetActive(true);
            }

        }

        else
        {
            anim.SetBool("IsAppear", false);
            isShow = false;

            Invoke("UIDisable", 1.0f);

            /*foreach (GameObject GO in UI)
            {
                GO.SetActive(false);
            }*/
        }
    }

    public void UIDisable()
    {
        foreach (GameObject GO in UI)
        {
            GO.SetActive(false);
        }
    }


}
