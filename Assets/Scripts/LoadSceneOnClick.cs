using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {

   

	public void LoadByIndex (int sceneIndex)
	{
        SceneManager.LoadScene(sceneIndex);

        
    }

    public void PlayAgain()//int sceneIndex)
    {
        //SceneManager.LoadScene(sceneIndex);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void Quit()
    {
        Application.Quit();

    }

    public void LoadOnEnergy(int sceneIndex)
    {
        DogManager Dogmanger = GameObject.FindObjectOfType<DogManager>().GetComponent<DogManager>();

        if (!Dogmanger.isLowEnergy)
        {
            SceneManager.LoadScene(sceneIndex);
        }
        else if (Dogmanger.isLowEnergy)
        {
            Dogmanger.LowEnergyAppear();
            Dogmanger.Invoke("LowEnergyDissapear",0.5f);
        }
    }

}
