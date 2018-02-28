using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneAfterSec : MonoBehaviour {

    public float delay;
    //public DogManager DogManager;

    void Start()
    {
        StartCoroutine(LoadLevelAfterDelay(delay));
        //DogManager = GetComponent<DogManager>();
    }

    public IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Sandbox");
        //DogManager.Energy = 1f;

    }
}