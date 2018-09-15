using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour {

    public bool attackingPlayer = false;

    [SerializeField]
    private GameObject Enemy;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Enemy.GetComponent<EnemyAttack>().AttackPlayer();
            attackingPlayer = true; //tells other script that the player has been found once he collides with the view range
            Debug.Log("Player Detected");
        }
    }
}
