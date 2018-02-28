using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallSpawning : Photon.PunBehaviour {

    public GameObject BallPrefab;
    public float Shootpower;

    public float Spawnsec;

    public Image ball1P1;
    public Image ball2P1;
    public Image ball3P1;

    public Image ball1P2;
    public Image ball2P2;
    public Image ball3P2;

    public int HitBallCount1;
    public int HitBallCount2;

    public PhotonView MyPhotonView;

    public bool GameOver;

    // private BallDogController DogController;

    // Use this for initialization
    void Start() {
        // DogController = GameObject.FindObjectOfType<BallDogController>().GetComponent<BallDogController>();
        MyPhotonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update() {

        if (PhotonNetwork.isMasterClient)
        {
            InvokeRepeating("SpawnBall", 5f, Spawnsec);
        }
    }

    void SpawnBall()
    {
        //GameObject Balls = Instantiate(BallPrefab, transform.position, transform.rotation);
        GameObject Balls = PhotonNetwork.Instantiate("Balls", transform.position, transform.rotation, 0);
        Vector3 direction = transform.TransformDirection(Vector3.forward);

        Balls.GetComponent<Rigidbody>().AddForce(direction * Shootpower);

        CancelInvoke();
    }

    [PunRPC]
    public void HitBallCheck1()
    {
        HitBallCount1++;


        if (HitBallCount1 == 1)
        {
            ball1P1.GetComponent<Image>().color = Color.white;
        }

        if (HitBallCount1 == 2)
        {
            ball2P1.GetComponent<Image>().color = Color.white;
        }

        if (HitBallCount1 == 3)
        {
            ball3P1.GetComponent<Image>().color = Color.white;


            if (!GameOver)
            {
                GameOver = true;
                Player1Wins();
            }
            // call player win function
            // win ui appear
        }
        
           

    }

    [PunRPC]
    public void HitBallCheck2()
    {

        // DogController.Anim.SetBool("IsHit",true);

      

       
            HitBallCount2++;

            if (HitBallCount2 == 1)
            {
                ball1P2.GetComponent<Image>().color = Color.white;
            }

            if (HitBallCount2 == 2)
            {
                ball2P2.GetComponent<Image>().color = Color.white;
            }

            if (HitBallCount2 == 3)
            {
                ball3P2.GetComponent<Image>().color = Color.white;

            if (!GameOver)
            {
                GameOver = true;
                Player2Wins();
            }

        }
        

    }

    void Player1Wins()
    {
        Debug.Log("Player 1 wins");
        //win ui 
    }

    void Player2Wins()
    {
        Debug.Log("Player 2 wins");
    }
}
