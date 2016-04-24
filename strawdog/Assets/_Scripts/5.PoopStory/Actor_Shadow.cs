using UnityEngine;
using System.Collections;

public class Actor_Shadow : MonoBehaviour {
    Actors _thisActor;
    Shadow _priorState;

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
            break;
        case Shadow.lurk:
            Debug.Log ("S.Lurk");
            break;
        case Shadow.talk:
            Debug.Log ("S.Talk");
            break;
        case Shadow.jeer:
            Debug.Log ("S.Jeer");
            break;
        case Shadow.burn:
            Debug.Log ("S.Burn");
            break;
        }
        _priorState = e.ShadowState;
    }
}
