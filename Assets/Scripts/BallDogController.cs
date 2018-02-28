using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BallDogController : Photon.PunBehaviour {

    public float moveSpeed;

    private Joystick joystick;
    public Animator Anim;

    public bool isWalking;
    public bool IsHitBall;
    public PhotonView MyPhotonView;

    public bool WalkStart;
    // Use this for initialization
    void Start()
    {
        //joystick = GameObject.FindObjectOfType<Joystick>().GetComponent<Joystick>();
        MyPhotonView = GetComponent<PhotonView>();
        joystick = transform.Find("Canvas/Joystick/Background").gameObject.GetComponent<Joystick>();
        Anim = GetComponent<Animator>();


        if (!MyPhotonView.isMine)
        {

            joystick.GetComponent<Image>().enabled = false;
            joystick.transform.GetChild(0).gameObject.GetComponent<Image>().enabled = false;
        }
        
        
        gameObject.name = MyPhotonView.owner.NickName;
        // get the transform of the main camera

    }

    // Update is called once per frame
    void Update()
    {

        //float h = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        //float v = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        // float h = joystick.Horizontal() * Time.deltaTime * moveSpeed;
        //float v = joystick.Vertical() * Time.deltaTime * moveSpeed;
        // float v = 1 * Time.deltaTime * moveSpeed;

        //transform.Translate(h, 0, v);


        //if (MyPhotonView.isMine)
        //{
            if (isWalking)
            {
                float movespeed = moveSpeed * Time.deltaTime;
                //Anim.SetBool("IsWalk", true);
                transform.Translate(0, 0, movespeed);
            if (!WalkStart)
            {
                WalkStart = true;
                MyPhotonView.RPC("IsWalking", PhotonTargets.AllBuffered);

            }
           
            }
            else if (!isWalking)
            {
                if (WalkStart)
             {
                WalkStart = false;
                MyPhotonView.RPC("StopWalk", PhotonTargets.AllBuffered);

                }
            // Anim.SetBool("IsWalk", false);
             }
            
            if (IsHitBall)
            {
            MyPhotonView.RPC("Hitting", PhotonTargets.AllBuffered);
            // Anim.SetTrigger("IsHit");
        }
        
            
       // }

    }

   

    [PunRPC]
    public void IsWalking()
    {
        Anim.SetBool("IsWalk", true);
    }

    [PunRPC]
    public void StopWalk()
    {
        Anim.SetBool("IsWalk", false);
    }

    [PunRPC]
    public void Hitting()
    {

        Anim.SetTrigger("IsHit");
        Debug.Log("AnimPlay");
    }

}
