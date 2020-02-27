using UnityEngine;
using Vuforia;

public class TrackingObject : MonoBehaviour, ITrackableEventHandler //객체 트래킹 
{

    public TextMesh obj_text_mesh; //3d text 오브젝트 

    public string name_;  //캐릭터 능력치  변수 
    public int atk;
    public int def;
    public int hp;

    private TrackableBehaviour mtrackableBehaviour;
    public bool is_detected_ = false;

    void Start()
    {
        obj_text_mesh.text = name_ + "\n 체력:" + hp + "\n 공격: " + atk + "\n 방어: " + def; 
        mtrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mtrackableBehaviour)
        {
            mtrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status PreviousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED || newStatus == TrackableBehaviour.Status.TRACKED) //물체가 인식되었을때 트래킹 상태
        {
            is_detected_ = true;
        }
        else
        {
            is_detected_ = false;
        }
    }
}