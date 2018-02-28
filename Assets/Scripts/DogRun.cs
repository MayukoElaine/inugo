using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogRun : MonoBehaviour {

    //public float RunSpeed;
    private float SwitchLane = 0f;

    private int LaneNum = 2;
    private string controlledLocked = "n";

    //public float JumpForce = 200f;
    private Animator DogRunAnim;

    public float speed;
    public bool isJump = false;
    public bool isCrouch = false;

    private RoadMove RoadMove;
    private BoxCollider boxcollider;

    //public bool Success;

    // Use this for initialization
    void Start() {
        DogRunAnim = GetComponent<Animator>();
        RoadMove = GameObject.FindObjectOfType<RoadMove>().GetComponent<RoadMove>();
  
    }

    // Update is called once per frame
    void Update() {

        Invoke("IsRunAfterSec",3f);

        GetComponent<Rigidbody>().velocity = new Vector3(SwitchLane * speed * Time.deltaTime, 0, 0 );

        if (SwipeManager.Instance.IsSwiping(SwipeDirection.Left) && (LaneNum > 1) && (controlledLocked == "n"))
        {
            Debug.Log("Swiped Left!");
            SwitchLane = -3.5f;
            LaneNum -= 1;
            StartCoroutine(StopSlide());
            controlledLocked = "y";
        }
        else if (SwipeManager.Instance.IsSwiping(SwipeDirection.Right) && (LaneNum < 3) && (controlledLocked == "n"))
        {
            Debug.Log("Swiped Right!");
            SwitchLane = 3.5f;
            LaneNum += 1;
            StartCoroutine(StopSlide());
            controlledLocked = "y";
        }
        else if (SwipeManager.Instance.IsSwiping(SwipeDirection.Up) || Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Swiped UP!");
            //GetComponent<Rigidbody>().AddForce(transform.up* JumpForce);
           // GetComponent<Rigidbody>().AddForce(0,JumpForce,0, ForceMode.Impulse);
            DogRunAnim.SetTrigger("IsJump");
            isJump = true;
     
        }

        else if (SwipeManager.Instance.IsSwiping(SwipeDirection.Down))
        {
            Debug.Log("Swiped Down!");
            DogRunAnim.SetTrigger("IsCrouch");
            isCrouch = true;
  
        }
        if (!isJump || isCrouch)
        {
            gameObject.transform.position = new Vector3(transform.position.x, -0.03f, transform.position.z);
        }


        if (!isJump && LaneNum == 1 || !isCrouch && LaneNum == 1 )
        {
            gameObject.transform.position = new Vector3(-6, -0.03f, transform.position.z);
            //gameObject.transform.position = new Vector3(transform.position.x, -0.03f, transform.position.z);

        }

        else if (!isJump && LaneNum == 2 || !isCrouch && LaneNum == 2)
        {
            gameObject.transform.position = new Vector3(0, -0.03f, transform.position.z);
            //gameObject.transform.position = new Vector3(transform.position.x, -0.03f, transform.position.z);

        }

        else if (!isJump && LaneNum == 3 || !isCrouch && LaneNum == 3)
        {
            gameObject.transform.position = new Vector3(6, -0.03f, transform.position.z);
            //gameObject.transform.position = new Vector3(transform.position.x, -0.03f, transform.position.z);

        }

    }

    IEnumerator StopSlide()
    {
        yield return new WaitForSeconds(0.45f);
        SwitchLane = 0;
        controlledLocked = "n";
    }

    public void IsGround()
    {
        isJump = false;
        isCrouch = false;
        RoadMove.NormalSpeed();
    }

    public void RoadMoveFaster()
    {
        RoadMove.FasterSpeed();
    }

    
    /*private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collide");

        if (collision.gameObject.tag == "DogFood")
        {
            Destroy(collision.gameObject);
            Debug.Log("DogFood");
        }
        else if (collision.gameObject.tag == "WrongFood")
        {
            Debug.Log("WrongFood");
        }

    }*/

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "DogFood")
        {
            Destroy(other.gameObject);
            if (RoadMove.Onlvl1)
            {
                RoadMove.Level1Pass = true;
            }

            else if (RoadMove.Onlvl4)
            {
                RoadMove.Level4Pass = true;
            }
        }
        else if (other.gameObject.tag == "WrongFood")
        {
            Destroy(other.gameObject);
            if (RoadMove.Onlvl1)
            {
                RoadMove.Level1Pass = false;
            }
        }
    }

    void IsRunAfterSec()
    {
        DogRunAnim.SetBool("IsRun",true);
    }

}
