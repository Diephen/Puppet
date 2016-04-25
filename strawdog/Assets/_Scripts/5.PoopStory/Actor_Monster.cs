using UnityEngine;
using System.Collections;

public class Actor_Monster : MonoBehaviour {

    Actors _thisActor;
    PoopMonster _priorState;

    Animator _monsterAnimator;

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
        switch (e.PoopMonsterState) {
        case PoopMonster.A:
            Debug.Log ("closed");
            break;
        case PoopMonster.B:
            Debug.Log ("locked0");
            break;
        case PoopMonster.C:
            Debug.Log ("locked1");
            break;
        case PoopMonster.D:
            Debug.Log ("opened");
            break;
        case PoopMonster.E:
            Debug.Log ("opening0");
            break;
        case PoopMonster.F:
            Debug.Log ("opening1");
            break;
        }
        _priorState = e.PoopMonsterState;
    }
}
