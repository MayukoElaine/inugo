using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCheck : MonoBehaviour {

    private DogRun DogRun;
    private RoadMove RoadMove;

	// Use this for initialization
	void Start () {
        DogRun = GameObject.FindObjectOfType<DogRun>().GetComponent<DogRun>();
        RoadMove = GameObject.FindObjectOfType<RoadMove>().GetComponent<RoadMove>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {   
        if (gameObject.tag == "CrouchObstacle")
        {
            if (DogRun.isCrouch)
            {
                if (RoadMove.Onlvl3)
                {
                    RoadMove.Level3Pass = true;
                }

                else if (RoadMove.Onlvl5)
                {
                    RoadMove.Level5Pass = true;
                }
                
            }
        }
        else if (gameObject.tag == "JumpObstacle")
        {
            if (DogRun.isJump)
            {
                if (RoadMove.Onlvl2)
                {
                    RoadMove.Level2Pass = true;
                }
                else if (RoadMove.Onlvl5)
                {
                    RoadMove.Level5Pass = true;
                }
            }
        }
    }


}
