using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour { //버튼 씬 관리

    public void GameStartButton() 
    {
        SceneManager.LoadScene("Battle"); // 배틀씬 로드 
        Debug.Log("START Button CLick"); //스타트 버튼 클릭시 
    }
    public void ChangeCardButton()
    {
        SceneManager.LoadScene("cardmenu");
        Debug.Log("CARD BUTTON CLICK");
    }

    public void OnClickExit()
    {
        Application.Quit();
        Debug.Log("EXIT Button CLick");
    }

    public void ChangeCardMenuScene()
    {
        SceneManager.LoadScene("main");
        Debug.Log("BackButton CLICK");
    }


    public void YssCardButton()
    {
        SceneManager.LoadScene("YssCard");
        Debug.Log("YssCard CLICK");
    }

    public void ToyoCardButton()
    {
        SceneManager.LoadScene("ToyoCard");
        Debug.Log("ToyoCard CLICK");
    }

    public void TurtleCardButton()
    {
        SceneManager.LoadScene("TurtleCard");
        Debug.Log("TurtleCard Click");
    }


    public void YssTextButton()
    {
        SceneManager.LoadScene("YSSTEXT");
        Debug.Log("YssTextB CLICK");
    }

    public void ToyoTextButton()
    {
        SceneManager.LoadScene("TOYOTEXT");
        Debug.Log("ToyoTextB CLICK");
    }

    public void TurtleTextButton()
    {
        SceneManager.LoadScene("TurtleText");
        Debug.Log("TurtleTextB CLICK");
    }

}
