using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vuforia;

public enum eGameState //게임상태 
{
    Ready = 0,
    Battle,
    Result
}

public class InBattleCard : MonoBehaviour
{
    //트래킹오브젝트 변수
    public TrackingObject obj_lss;  
    public TrackingObject obj_toyo;
    public TrackingObject obj_turtle;
    //게임오브젝트 변수 
    public GameObject Card_Text;
    public GameObject Turn_Text;
    
    public GameObject YssDice;
    public GameObject ToyoDice;
    public GameObject DrawDice;
    public GameObject BattleEnd;
    public GameObject Battleing;

    public GameObject YssWin;
    public GameObject ToyoWin;
  //전투, 선공 정하기 상황시 오디오 
    public AudioClip Battlesound;
    public AudioClip DiceSound;
 

    public eGameState game_state = eGameState.Ready;
    public string system_message = "";
    bool flag = false;
  
    void OnGUI()
    {
        

        GUIStyle gui_style_btn = new GUIStyle("Button"); //gui 버튼 생성 
        gui_style_btn.fontSize = 50;

        if (game_state == eGameState.Ready)
        {
            Card_Text.SetActive(true); //카드 인식 텍스트 오브젝트만 활성화 

            Turn_Text.SetActive(false);
            YssDice.SetActive(false);
            ToyoDice.SetActive(false);
            DrawDice.SetActive(false);
            BattleEnd.SetActive(false);
            Battleing.SetActive(false);
            ToyoWin.SetActive(false);
            YssWin.SetActive(false);
            GetComponent<AudioSource>().clip = DiceSound; //오디오
        }

       


        if (obj_turtle.is_detected_ && obj_lss.is_detected_ && flag == false) //거북선 버프 
        {
            obj_lss.hp += 150;
            obj_lss.atk += 30;
            obj_lss.def += 20;
            obj_lss.obj_text_mesh.text = obj_lss.name_ + "\n 체력: " + obj_lss.hp + "\n 공격: " + obj_lss.atk + "\n 방어: " + obj_lss.def;
            flag = true;
        }


        if (obj_lss.is_detected_ && obj_toyo.is_detected_ && game_state == eGameState.Ready) //게임 준비상태 
        {
            Card_Text.SetActive(false);
           

            if (GUI.Button(new Rect(1150, 20, 350 , 200 ), "전투 시작", gui_style_btn))
            {
                
                game_state = eGameState.Battle;
                Turn_Text.SetActive(true);

                StartCoroutine(RollTheDices());
            }
        }
       
        if (game_state == eGameState.Result)
        {
            if (GUI.Button(new Rect(2000, 20, 350, 200), "다시 시작", gui_style_btn))
            {
                game_state = eGameState.Ready;
                flag = false;
                obj_lss.hp = 950;
                obj_lss.atk = 90;
                obj_lss.def = 20;
                obj_lss.obj_text_mesh.text = obj_lss.name_ + "\n 체력: " + obj_lss.hp + "\n 공격: " + obj_lss.atk + "\n 방어: " + obj_lss.def;
                obj_toyo.obj_text_mesh.text = obj_toyo.name_ + "\n HP: " + obj_toyo.hp + "\n ATK: " + obj_toyo.atk + "\n 방어: " + obj_toyo.def;
            }
        }
    }
        

        IEnumerator RollTheDices()
        {
            int last_lss_dice = 0;
            int last_toyo_dice = 0;
            YssDice.SetActive(false);
            ToyoDice.SetActive(false);
            DrawDice.SetActive(false);
            GetComponent<AudioSource>().Play();
            for (int i = 0; i < 15; i++)
            {
                
                last_lss_dice = 1 + Random.Range(0, 6);
                last_toyo_dice = 1 + Random.Range(0, 6);
                
                obj_lss.obj_text_mesh.text = "주사위 : " + last_lss_dice;
                 obj_toyo.obj_text_mesh.text = "주사위 : " + last_toyo_dice;
                yield return new WaitForSeconds(0.2f);
            }
            
            if (last_lss_dice > last_toyo_dice)
            {
                GetComponent<AudioSource>().clip = Battlesound;
                YssDice.SetActive(true);
                StartCoroutine(StartBattle1(obj_lss, obj_toyo));
            }
            else if (last_lss_dice < last_toyo_dice)
            {
                GetComponent<AudioSource>().clip = Battlesound;
                 ToyoDice.SetActive(true);
                StartCoroutine(StartBattle2(obj_toyo, obj_lss));
            }
            else if (last_lss_dice == last_toyo_dice)
            {
                
                DrawDice.SetActive(true);
                StartCoroutine(RollTheDices());
            }

            Turn_Text.SetActive(false);
        }



        IEnumerator StartBattle1(TrackingObject obj_lss, TrackingObject obj_toyo)
        {

            yield return new WaitForSeconds(1.0f);
            int lss_hp = obj_lss.hp;
            int toyo_hp = obj_toyo.hp;

            YssDice.SetActive(false);
            ToyoDice.SetActive(false);
            Battleing.SetActive(true);

        //체력
        obj_lss.obj_text_mesh.text = obj_lss.name_ + "\n 체력: " + lss_hp + "\n 공격: " + obj_lss.atk + "\n 방어: " + obj_lss.def;
        obj_toyo.obj_text_mesh.text = obj_toyo.name_ + "\n HP: " + toyo_hp + "\n ATK: " + obj_toyo.atk + "\n 방어: " + obj_toyo.def;

        while (true)
            {
         
                toyo_hp -= obj_lss.atk - obj_toyo.def; //선공

            obj_lss.obj_text_mesh.text = obj_lss.name_ + "\n 체력: " + lss_hp + "\n 공격: " + obj_lss.atk + "\n 방어: " + obj_lss.def;
            obj_toyo.obj_text_mesh.text = obj_toyo.name_ + "\n HP: " + toyo_hp + "\n ATK: " + obj_toyo.atk + "\n 방어: " + obj_toyo.def;
            GetComponent<AudioSource>().Play();
            if (toyo_hp <= 0)
                {
                    Battleing.SetActive(false);
                    BattleEnd.SetActive(true);
                 
                
                    YssWin.SetActive(true);
           
                    game_state = eGameState.Result;
                

                    break;
                }
                 yield return new WaitForSeconds(1.0f);



            //후공 턴 
                
                lss_hp -= obj_toyo.atk - obj_lss.def;
            GetComponent<AudioSource>().Play();
            //체력
            obj_lss.obj_text_mesh.text = obj_lss.name_ + "\n 체력: " + lss_hp + "\n 공격: " + obj_lss.atk + "\n 방어: " + obj_lss.def;
            obj_toyo.obj_text_mesh.text = obj_toyo.name_ + "\n HP: " + toyo_hp + "\n ATK: " + obj_toyo.atk + "\n 방어: " + obj_toyo.def;

            if (lss_hp <= 0)
                {
                    Battleing.SetActive(false);
                    BattleEnd.SetActive(true);
                
                   ToyoWin.SetActive(true);
                    game_state = eGameState.Result;

                
                
                    break;
                }

           
            yield return new WaitForSeconds(1.0f);
            }
        }

    IEnumerator StartBattle2(TrackingObject obj_toyo, TrackingObject obj_lss) //도요토미 선공시 
    {

        yield return new WaitForSeconds(1.0f); 
        int toyo_hp = obj_toyo.hp;
        int lss_hp = obj_lss.hp;

        YssDice.SetActive(false);
        ToyoDice.SetActive(false);
        Battleing.SetActive(true);

        //체력
        obj_toyo.obj_text_mesh.text = obj_toyo.name_ + "\n HP: " + toyo_hp + "\n ATK: " + obj_toyo.atk + "\n 방어: " + obj_toyo.def;
        obj_lss.obj_text_mesh.text = obj_lss.name_ + "\n 체력: " + lss_hp + "\n 공격: " + obj_lss.atk + "\n 방어: " + obj_lss.def;
        while (true)
        {
            
            lss_hp -= obj_toyo.atk - obj_lss.def; //선공
            GetComponent<AudioSource>().Play();
            obj_toyo.obj_text_mesh.text = obj_toyo.name_ + "\n HP: " + toyo_hp + "\n ATK: " + obj_toyo.atk + "\n 방어: " + obj_toyo.def;
            obj_lss.obj_text_mesh.text = obj_lss.name_ + "\n 체력: " + lss_hp + "\n 공격: " + obj_lss.atk + "\n 방어: " + obj_lss.def;

            if (lss_hp <= 0)
            {
                Battleing.SetActive(false);
                BattleEnd.SetActive(true);
               
                ToyoWin.SetActive(true);
               
             
                game_state = eGameState.Result;


                break;
            }

           
            yield return new WaitForSeconds(1.0f);



            //후공 턴 
            toyo_hp -= obj_lss.atk - obj_toyo.def;
            GetComponent<AudioSource>().Play();
            //체력
            obj_toyo.obj_text_mesh.text = obj_toyo.name_ + "\n HP: " + toyo_hp + "\n ATK: " + obj_toyo.atk + "\n 방어: " + obj_toyo.def;
            obj_lss.obj_text_mesh.text = obj_lss.name_ + "\n 체력: " + lss_hp + "\n 공격: " + obj_lss.atk + "\n 방어: " + obj_lss.def;

            if (toyo_hp <= 0)
            {
                Battleing.SetActive(false);
                BattleEnd.SetActive(true);
          
                YssWin.SetActive(true);
    
                game_state = eGameState.Result;


                break;
            }
            yield return new WaitForSeconds(1.0f);
        }
    }







}