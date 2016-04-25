using UnityEngine;
using System.Collections;

public class Actor_Shadow : MonoBehaviour {
    Actors _thisActor;
    Shadow _priorState;
    bool _isThisShadow = false;

    void Awake () {
        _thisActor = gameObject.GetComponent <Actor> ()._thisActor;
    }

    void OnEnable () {
        Events.G.AddListener<PoopStoryAct>(ActFunction);
    }

    void OnDisable () {
        Events.G.RemoveListener<PoopStoryAct>(ActFunction);
    }

    public void ActFunction (PoopStoryAct e) {
        switch (e.ShadowState) {
        case Shadow.hide:
            Debug.Log ("S.hide");

            //hidden
            break;
        case Shadow.lurk:
            Debug.Log ("S.Lurk");
            //existing in shadow
            break;
        case Shadow.talk:
            Debug.Log ("S.Talk");
            //text shows up
            break;
        case Shadow.burn:
            Debug.Log ("S.Burn");
            //play die animation
            break;
        }
        _isThisShadow = false;
        _priorState = e.ShadowState;
    }

    void OnMouseDown(){
        ThisShadow ();
    }
        
    public void ThisShadow () {
        _isThisShadow = true;
    }
}
