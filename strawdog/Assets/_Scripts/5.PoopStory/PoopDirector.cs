using UnityEngine;
using System.Collections;

public class PoopDirector : MonoBehaviour {
    Girl _girlState = Girl.A;
    Door _doorState = Door.A;
    Chain _chainState = Chain.A;
    PoopMonster _poopMonsterState = PoopMonster.A;
    Shadow _shadowState = Shadow.A;
    PoopParticle _poopParticleState = PoopParticle.A;
    public static int _turns;

    void Awake(){
        _turns = 0;       
    }

    void OnEnable () {
        Events.G.AddListener<DirectorUpdate>(DirectMessage);
    }

    void OnDisable () {
        Events.G.RemoveListener<DirectorUpdate>(DirectMessage);
    }

    void DirectMessage(DirectorUpdate e) {
        _turns++;
        Actors actor = e.Actors;
        Actors victim = e.Victims;
        switch (actor)
        {
        case Actors.Girl:
            Debug.Log ("girl AS EXPECTED");
            GirlMessage (victim);
            break;
        case Actors.Door:
            Debug.Log ("door AS EXPECTED");
            DoorMessage (victim);
            break;
        case Actors.Chain:
            ChainMessage (victim);
            break;
        case Actors.PoopMonster:
            PoopMonsterMessage (victim);
            break;
        case Actors.Shadow:
            ShadowMessage (victim);
            break;
        case Actors.PoopParticle:
            PoopParticleMessage (victim);
            break;
        }
        Events.G.Raise (new PoopStoryAct (_girlState, _doorState, _chainState, _poopMonsterState, _shadowState, _poopParticleState));
    }
	
    void GirlMessage(Actors victim){
        switch (victim)
        {
//        case Actors.girl:
//            GirlMessage (victim);
//            break;
        case Actors.Door:
            Debug.Log ("Duurr AS EXPECTED");
//            DoorMessage (victim);

            break;
        case Actors.Chain:
            Debug.Log ("churn AS EXPECTED");
//            ChainMessage (victim);
            break;
        case Actors.PoopMonster:
//            PoopMonsterMessage (victim);
            break;
        case Actors.Shadow:
//            ShadowMessage (victim);
            break;
        case Actors.PoopParticle:
//            PoopParticleMessage (victim);
            break;
        default:
            Debug.Log ("Null");
            break;
        }
    }

    void DoorMessage(Actors victim){
        
    }

    void ChainMessage(Actors victim){
        
    }

    void PoopMonsterMessage(Actors victim){
        
    }

    void ShadowMessage(Actors victim){
        
    }

    void PoopParticleMessage(Actors victim){
        
    }

}
