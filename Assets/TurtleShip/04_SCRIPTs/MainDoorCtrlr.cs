using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDoorCtrlr : MonoBehaviour {
    public Animator DoorAnimn;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {

        DoorAnimn.SetBool("DoorOpenON", true);

    }
}
