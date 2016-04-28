using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Actor))]
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
            break;
        case PoopMonster.B:
            break;
        case PoopMonster.C:
            break;
        case PoopMonster.D:
            break;
        case PoopMonster.E:
            break;
        case PoopMonster.F:
            Vector3 tempMonsterPos = transform.position;
            tempMonsterPos.z = -0.7f;
            transform.position = tempMonsterPos;
            break;
        }
        _priorState = e.PoopMonsterState;
    }
}
