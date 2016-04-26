using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Actor))]
public class Actor_Girl : MonoBehaviour {

    Actors _thisActor;
    Girl _priorState;

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
        switch (e.GirlState) {
        case Girl.atBlank:
//            Debug.Log ("Girl At Blank");
            break;
        case Girl.atDoor:
//            Debug.Log ("Girl is at door");
            //condition to allow door
            //snap girl into position
            break;
        case Girl.atShadow:
//            Debug.Log ("Girl is at Shadow");
            break;
        }
        _priorState = e.GirlState;
    }
}
