using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenRotation2 : MonoBehaviour { 
   
	// Use this for initialization
	void Start () 
    {
        Screen.orientation = ScreenOrientation.Portrait; //씬 세로로 고정
    }


}
