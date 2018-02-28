using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileStatusManager : MonoBehaviour {

    private bool ProfileIsShown;
    public GameObject profile;


	// Use this for initialization
	void Start () {

        ProfileIsShown = false;
        profile.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (profile.activeInHierarchy)
        {
            if (Input.GetMouseButtonDown(0))
            {
                profile.SetActive(false);
            }

        }

    }

    public void OnClick()
    {
        if (!ProfileIsShown)
        {
            profile.SetActive(true);
            ProfileIsShown = true;

        }
        else
        {
            profile.SetActive(false);
            ProfileIsShown = false;
        }
    }

}
