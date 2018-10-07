using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuyFollow : MonoBehaviour {
    public Transform target;
    public Transform gaylord;

	
	
	// Update is called once per frame
	void Update () {

        transform.LookAt(target);
        transform.Translate(Vector3.forward * 5 * Time.deltaTime);

	}
}
