using UnityEngine;
using System.Collections;

public class Actor_Door : MonoBehaviour {

    Actors _thisActor;
    Door _priorState;

    Animator _doorAnimator;

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
        switch (e.DoorState) {
        case Door.closed:
            Debug.Log ("closed");
            break;
        case Door.locked0:
            Debug.Log ("locked0");
            break;
        case Door.locked1:
            Debug.Log ("locked1");
            break;
        case Door.opened:
            Debug.Log ("opened");
            break;
        case Door.opening0:
            Debug.Log ("opening0");
            break;
        case Door.opening1:
            Debug.Log ("opening1");
            break;
        }
        _priorState = e.DoorState;
    }
}
