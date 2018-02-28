using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallManager : MonoBehaviour {

    public bool isGround;

    private BallSpawning BallSpawning;
    private BallDogController DogController;

    public bool IsHitted;

    //public int HitBallCount;

    // Use this for initialization
    void Start () {
        BallSpawning = GameObject.FindObjectOfType<BallSpawning>().GetComponent<BallSpawning>();
       // DogController = GameObject.FindObjectOfType<BallDogController>().GetComponent<BallDogController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (!IsHitted)
        {
            if (collision.gameObject.tag == "Ground")
            {
                IsHitted = true;

                Invoke("DestroyBalls", 5.0f);
            }

            if (collision.gameObject.tag == "Player")
            {

                IsHitted = true;
                Debug.Log("Hit dog");


                DogController = collision.gameObject.GetComponent<BallDogController>();
                //BallSpawning.HitBallCheck();

                DogController.IsHitBall = true;
                // collision.gameObject.GetComponent<BallDogController>().MyPhotonView.RPC("Hitting", PhotonTargets.AllBuffered);
                //collision.gameObject.GetComponent<Animator>().SetBool("IsHit", true);
               
                if (collision.gameObject.name == "Player1")
                {
                    BallSpawning.MyPhotonView.RPC("HitBallCheck1", PhotonTargets.AllBuffered);
                }

                else if (collision.gameObject.name == "Player2")
                {
                    BallSpawning.MyPhotonView.RPC("HitBallCheck2", PhotonTargets.AllBuffered);
                }

            }

        }
    }

    public void DestroyBalls()
    {if (PhotonNetwork.isMasterClient) {
            PhotonNetwork.Destroy(gameObject);

            }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            DogController = collision.gameObject.GetComponent<BallDogController>();
            DogController.IsHitBall = false;

        }
    }
}
