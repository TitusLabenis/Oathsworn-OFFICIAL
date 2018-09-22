using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour {

    public static bool hasShield = false;

    [SerializeField]
    private GameObject actionText;

    [SerializeField]
    private GameObject playerSword;

    [SerializeField]
    private GameObject swordPickup;

    private bool canPickup = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (canPickup == true && Input.GetButtonDown("Interact"))
        {
            playerSword.SetActive(true);
            canPickup = false;
            swordPickup.SetActive(false);
            hasShield = true;
            actionText.SetActive(false);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ShieldPickup") && hasShield == false)
        {
            actionText.SetActive(true);
            canPickup = true;
        }
    }
}
