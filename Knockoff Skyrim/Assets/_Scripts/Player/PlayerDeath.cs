using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour {

    [SerializeField]
    private float playerHP = 1.0f;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (playerHP <= 0f)
        {
            Debug.Log("The Player Died");
            Death();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("EnemySword"))
        {
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        playerHP = playerHP - 1.0f;
    }

    void Death()
    {
        SceneManager.LoadScene("DeathScreen", LoadSceneMode.Single);
    }
}
