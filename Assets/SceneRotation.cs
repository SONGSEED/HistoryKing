using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneRotation : MonoBehaviour {

    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft; //씬 가로로 고정
    }

}
