using UnityEngine;
using System.Collections;

public class Actor_Shadow : MonoBehaviour {
//    Actors _thisActor;
//    Shadow _priorState;
    bool _isThisShadow = false;
    int idNumber;
    ShadowSpawner _shadowSp;
    [SerializeField] TextMesh _tm;
    BoxCollider2D _boxC2D;

    string _thisJeer;
    string _thisTalk;

    void Awake () {
//        _thisActor = gameObject.GetComponent <Actor> ()._thisActor;
        _boxC2D = gameObject.GetComponent<BoxCollider2D> ();

    }

    public void shadowSpawnComponent () {
        _shadowSp = gameObject.GetComponentInParent<ShadowSpawner> ();
    }

    void OnEnable () {
        Events.G.AddListener<PoopStoryAct>(ActFunction);
    }

    void OnDisable () {
        Events.G.RemoveListener<PoopStoryAct>(ActFunction);
    }

    public void AssignID (int number){
        idNumber = number;
        //getting the text information as well
        Debug.Log (number);
        Debug.Log (_shadowSp.TalkGetter (number));
        _thisTalk = _shadowSp.TalkGetter (number);
        _thisJeer = _shadowSp.JeerGetter (number);
    }

    public void ActFunction (PoopStoryAct e) {
        switch (e.ShadowState) {
        case Shadow.lurk:
            Debug.Log ("S.Lurk");
            //existing in shadow
            break;
        case Shadow.jeer:
            Debug.Log ("Before THISSHADOW");
            if(_isThisShadow){
                Debug.Log ("S.Jeer");
                Speak (_thisJeer);
            }
            //existing in shadow
            break;
        case Shadow.talk:
            Debug.Log ("Before THISSHADOW");
            if(_isThisShadow){
                Debug.Log ("S.Talk");
                Speak (_thisTalk);
            }
            break;
        case Shadow.burn:
            Debug.Log ("S.Burn");
            //play die animation
            _boxC2D.enabled = false;
            break;
        }
        _isThisShadow = false;
//        _priorState = e.ShadowState;
    }

    void Speak (string content) {
        _tm.text = content;
    }

    void OnMouseDown(){
        ThisShadow ();
    }
        
    public void ThisShadow () {
        _isThisShadow = true;
    }
}
