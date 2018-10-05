using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindAttack : PlayerAttack {

    [SerializeField]
    private Transform startPos; //the enemy sword's starting position

    [SerializeField]
    private Transform sword; //the current position of the enemy's sword

    private int listLength;

    private bool isRewinding = false; //the enemy isn't currently retracting his sword

    private const float BLOCKING = 4; //the sword stance where the enemy would be blocking

    List<Vector3> positions; //list of places where the enemy's sword has been

	// Use this for initialization
	void Start () {
        positions = new List<Vector3>(); //creates the list
    }

    private void Update()
    {
        

        listLength = positions.Count;
        if (sword == startPos)
        {
            Debug.Log("Done Rewinding");
            isRewinding = false;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("PlayerSword") && swordStatus == BLOCKING)
        {
            StartRewind(); //begin drawing back if the sword has been blocked
            Debug.Log("Enemy Attack Blocked");
        }

        else if (collision.gameObject.CompareTag("PlayerShield") && swordStatus == BLOCKING)
        {
            StartRewind(); //begin drawing back if the sword has been blocked
            Debug.Log("Enemy Attack Blocked");
        }


    }

    void StartRewind()
    {
        //tells the ai to stop attacking
        attackingPlayer = false;
        isRewinding = true;
        
    }

    private void FixedUpdate()
    {
        if (isRewinding == true)
        {
            StartCoroutine("Rewind");
            StopCoroutine("Record");
        }

        else if (isRewinding == false)
        {
            //record sword places if it isn't currently rewinding
            StartCoroutine("Record");
            Debug.Log("Recording");
            StopCoroutine("Rewind");
        }
    }

    private void Rewind()
    {
        //makes it so the vector3 at the top is always the newest position
        transform.position = positions[listLength-1];
        positions.RemoveAt(listLength);
        Debug.Log("Rewinding");
    }

    private void Record()
    {
        positions.Add(transform.position);
        Debug.Log("Array 1:" + positions[0]);
        Debug.Log("Array 2:" + positions[1]);
    }
}
