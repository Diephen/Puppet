using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Actor))]
public class Actor_Girl : MonoBehaviour {

    Actors _thisActor;
    Girl _priorState;
	Animator _girlAnimator;

    void Awake () {
        _thisActor = gameObject.GetComponent <Actor> ()._thisActor;
		// this is a temporary fix for girl animation
		_girlAnimator = gameObject.GetComponentInChildren<Animator> ();
    }

    void OnEnable () {
        Events.G.AddListener<PoopStoryAct>(ActFunction);
    }

    void OnDisable () {
        Events.G.RemoveListener<PoopStoryAct>(ActFunction);
    }

    public void ActFunction (PoopStoryAct e) {
		_girlAnimator.SetBool ("isAtDoor", false);
		_girlAnimator.SetBool ("isShadowTalk", false);
        switch (e.GirlState) {
        case Girl.atBlank:
//            Debug.Log ("Girl At Blank");
			_girlAnimator.SetBool ("isAtDoor", false);
			_girlAnimator.SetBool ("isShadowTalk", false);
            break;
		case Girl.atDoor:
			_girlAnimator.SetBool ("isShadowTalk", false);
			_girlAnimator.SetBool ("isAtDoor", true);

//            Debug.Log ("Girl is at door");
            //condition to allow door
            //snap girl into position
            break;
        case Girl.atShadow:
//            Debug.Log ("Girl is at Shadow");
			_girlAnimator.SetBool ("isAtDoor", false);
			_girlAnimator.SetBool ("isShadowTalk", true);

            break;
        }
        _priorState = e.GirlState;
    }
}
