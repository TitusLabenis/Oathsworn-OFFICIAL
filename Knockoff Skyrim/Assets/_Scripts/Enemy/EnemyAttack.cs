using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : EnemyDetection {

    [SerializeField]
    private Transform player;

    [SerializeField]
    private GameObject enemySword;

    private bool attackedPlayer = false;

    private bool attackPlayer;

    [SerializeField]
    private Animation anim;

	// Use this for initialization
	void Start () {
    }

    public void AttackPlayer()
    {
        enemySword.GetComponent<Animation>().Play("EnemyAttack"); //swings sword
        Debug.Log("Attacking Player");
        attackedPlayer = true;//tells detection that we've already attacked the player
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("PlayerSword"))
        {
            anim["EnemyAttack"].speed = 0; //stops animation if blocked
        }
    }
}
