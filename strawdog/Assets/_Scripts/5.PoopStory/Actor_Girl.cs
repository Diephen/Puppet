using UnityEngine;
using System.Collections;

public class Actor_Girl : MonoBehaviour {

    Actors _thisActor;

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
        //        if (_thisActor == e.Actors){
        //            Debug.Log ("actor " + _thisActor);
        //        } else if (_thisActor == e.Victims) {
        //            Debug.Log ("victim" + _thisActor);
        //        } else {
        //            Debug.Log ("static" + _thisActor);
        //        }
        //        e.GirlState;
        //        e.DoorState;
        //        e.ChainState;
        //        e.PoopMonsterState;
        //        e.ShadowState;
        //        e.PoopParticleState;
    }
}
