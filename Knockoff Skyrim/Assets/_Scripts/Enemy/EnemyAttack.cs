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

    Collider e_collider;

    [SerializeField]
    private Animation anim;

	// Use this for initialization
	void Start () {
        e_collider = GetComponent<Collider>();
    }

    public void AttackPlayer()
    {
        e_collider.enabled = true;
        enemySword.GetComponent<Animation>().Play("EnemyAttack"); //swings sword
        Debug.Log("Attacking Player");
        attackedPlayer = true;//tells detection that we've already attacked the player
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("PlayerSword"))
        {
            anim["EnemyAttack"].speed = 0.5f; //stops animation if blocked
            e_collider.enabled = false;
        }

        else if (collision.gameObject.CompareTag("PlayerShield"))
        {
            anim["EnemyAttack"].speed = 0.5f; //Fix later
            e_collider.enabled = false;
        }
    }
}
