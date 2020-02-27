using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class ShipCtroller : MonoBehaviour {

    public Animator BattleShipAnimn;
    public Animator MasterAnimn;
    public Animator LeftWindowAnim;
    public Animator RightWindowAnim;
    public Animator BackWindowsAnim;
    public Animator RudderAnim;



    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

    }

    private void FixedUpdate()
    {

    }

    public void OnClick_toggMASTER()
    {
        if (this.MasterAnimn == null)
        {
            Debug.Log("Assign the MasterAnimn Animator before controlling of the Button ...");
            return;
        }

        this.MasterAnimn.SetBool("OnWINDSAIL", !this.MasterAnimn.GetBool("OnWINDSAIL"));

    }

    public void OnClick_toggWindows()
    {
        if (this.LeftWindowAnim == null)
        {
            Debug.Log("Assign the LeftWindowAnimn Animator before controlling of the Button ...");
            return;
        }

        this.LeftWindowAnim.SetBool("LeftWindowOn", !this.LeftWindowAnim.GetBool("LeftWindowOn"));

        if (this.RightWindowAnim == null)
        {
            Debug.Log("Assign the RightWindowAnimn Animator before controlling of the Button ...");
            return;
        }

        this.RightWindowAnim.SetBool("RightWindowOn", !this.RightWindowAnim.GetBool("RightWindowOn"));

        if (this.BackWindowsAnim == null)
        {
            Debug.Log("Assign the RightWindowAnimn Animator before controlling of the Button ...");
            return;
        }

        this.BackWindowsAnim.SetBool("BackWindowsON", !this.BackWindowsAnim.GetBool("BackWindowsON"));

    }




    public void OnClick_toggForewardPaddle()
    {
        if (this.BattleShipAnimn == null)
        {
            Debug.Log("Assign the BattleShip Animator before controlling of the Button ...");
            return;
        }

        this.BattleShipAnimn.SetBool("OnWINDSAIL", false);

        this.BattleShipAnimn.SetBool("OnForewardMaster", false);

        this.BattleShipAnimn.SetBool("OnForewardPaddle", true);
        this.BattleShipAnimn.SetBool("OnTurnRightPaddle", false);
        this.BattleShipAnimn.SetBool("OnTurnLeftPaddle", false);
        this.BattleShipAnimn.SetBool("OnBackwardPaddle", false);

        this.RudderAnim.SetBool("LeftTurn", false);
        this.RudderAnim.SetBool("LeftTurn", false);


    }


    public void OnClick_toggTURNRIGHT()
    {
        if (this.BattleShipAnimn == null)
        {
            Debug.Log("Assign the BattleShip Animator before controlling of the Button ...");
            return;
        }

        

        this.BattleShipAnimn.SetBool("OnForewardMaster", false);

        this.BattleShipAnimn.SetBool("OnForewardPaddle", false);
        this.BattleShipAnimn.SetBool("OnTurnRightPaddle", true);
        this.BattleShipAnimn.SetBool("OnTurnLeftPaddle", false);
        this.BattleShipAnimn.SetBool("OnBackwardPaddle", false);

        this.RudderAnim.SetBool("RightTurn", true);
        this.RudderAnim.SetBool("LeftTurn", false);


    }

    public void OnClick_toggTURNLEFT()
    {
        if (this.BattleShipAnimn == null)
        {
            Debug.Log("Assign the BattleShip Animator before controlling of the Button ...");
            return;
        }

        

        this.BattleShipAnimn.SetBool("OnForewardMaster", false);

        this.BattleShipAnimn.SetBool("OnForewardPaddle", false);
        this.BattleShipAnimn.SetBool("OnTurnRightPaddle", false);
        this.BattleShipAnimn.SetBool("OnTurnLeftPaddle", true);
        this.BattleShipAnimn.SetBool("OnBackwardPaddle", false);

        this.RudderAnim.SetBool("RightTurn", false);
        this.RudderAnim.SetBool("LeftTurn", true);


    }


    public void OnClick_toggBACKWARD()
    {
        if (this.BattleShipAnimn == null)
        {
            Debug.Log("Assign the BattleShip Animator before controlling of the Button ...");
            return;
        }

        

        this.BattleShipAnimn.SetBool("OnForewardMaster", false);

        this.BattleShipAnimn.SetBool("OnForewardPaddle", false);
        this.BattleShipAnimn.SetBool("OnTurnRightPaddle", false);
        this.BattleShipAnimn.SetBool("OnTurnLeftPaddle", false);
        this.BattleShipAnimn.SetBool("OnBackwardPaddle", true);

        this.RudderAnim.SetBool("RightTurn", false);
        this.RudderAnim.SetBool("LeftTurn", false);


    }

    public void OnClick_LoadInterior()
    {
        SceneManager.LoadScene("SCENE01");

    }


}
