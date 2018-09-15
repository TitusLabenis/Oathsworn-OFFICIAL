using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindAttack : PlayerAttack {

    [SerializeField]
    private Transform startPos; //the enemy sword's starting position

    [SerializeField]
    private Transform sword; //the current position of the enemy's sword

    private bool isRewinding = false; //the enemy isn't currently retracting his sword

    private const float BLOCKING = 4; //the sword stance where the enemy would be blocking

    List<Vector3> positions; //list of places where the enemy's sword has been

	// Use this for initialization
	void Start () {
        positions = new List<Vector3>(); //creates the list
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("PlayerSword")  || collision.gameObject.CompareTag("PlayerShield") && swordStatus == BLOCKING)
        {
            StartRewind(); //begin drawing back if the sword has been blocked
            Debug.Log("Enemy Attack Blocked");
        }

        if (sword == startPos)
        {
            StopRewind(); //stop rewinding if the sword is back in the starting place
        }
    }

    void StartRewind()
    {
        //tells the ai to stop attacking
        attackingPlayer = false;
        isRewinding = true;
        
    }

    void StopRewind()
    {
        //*code*
    }

    private void FixedUpdate()
    {
        if (isRewinding == true)
        {
            Rewind();
        }

        else
        {
            //record sword places if it isn't currently rewinding
            Record();
        }
    }

    private void Rewind()
    {
        //makes it so there is only ever one vector3 in the list
        transform.position = positions[0];
        positions.RemoveAt(0);
    }

    private void Record()
    {
        positions.Insert(0, transform.position);
    }
}
