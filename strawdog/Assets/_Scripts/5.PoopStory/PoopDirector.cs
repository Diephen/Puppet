using UnityEngine;
using System.Collections;

public class PoopDirector : MonoBehaviour {
    Girl _girlState = Girl.atBlank;
    Door _doorState = Door.closed;
    Chain _chainState = Chain.locked;
    PoopMonster _poopMonsterState = PoopMonster.A;
    Shadow _shadowState = Shadow.hide;
    LightsPoop _lightsPoopState = LightsPoop.center;
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
            GirlMessage (victim);
            break;
        case Actors.Door:
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
        case Actors.LightsPoop:
            LightsPoopMessage (victim);
            break;
        }
        //determine Chain State here
        Events.G.Raise (new PoopStoryAct (_girlState, _doorState, _chainState, _poopMonsterState, _shadowState, _lightsPoopState));
    }
	
    void GirlMessage(Actors victim){
        switch (victim)
        {
        case Actors.Door:
            _girlState = Girl.atDoor;
            _doorState++;
            _poopMonsterState++;
            break;
        case Actors.Chain:
            _girlState = Girl.atDoor;
            _doorState++;
            _poopMonsterState++;
            break;
        case Actors.PoopMonster:
            _girlState = Girl.atDoor;
            _doorState++;
            _poopMonsterState++;
            break;
        case Actors.Shadow:
            _girlState = Girl.atShadow;
            _doorState++;
            _poopMonsterState++;
            _shadowState = Shadow.talk;
            break;
        case Actors.LightsPoop:
            _girlState = Girl.atBlank;
            _doorState++;
            _poopMonsterState++;
            break;
        default:
            _girlState = Girl.atBlank;
            _doorState++;
            _poopMonsterState++;
            _shadowState = Shadow.hide;
            break;
        }
    }

    void DoorMessage(Actors victim){
        _doorState++;
        _poopMonsterState++;
    }

    void ChainMessage(Actors victim){
        _doorState++;
        _poopMonsterState++;
    }

    void PoopMonsterMessage(Actors victim){
        _doorState++;
        _poopMonsterState++;
    }

    void ShadowMessage(Actors victim){
        switch (victim)
        {
        case Actors.Girl:
            _doorState++;
            _poopMonsterState++;
            _shadowState = Shadow.talk;
            break;
        case Actors.Door:
            _doorState++;
            _poopMonsterState++;
            _shadowState = Shadow.talk;
            break;
        case Actors.Chain:
            _doorState++;
            _poopMonsterState++;
            _shadowState = Shadow.talk;
            break;
        case Actors.PoopMonster:
            _doorState++;
            _poopMonsterState++;
            _shadowState = Shadow.talk;
            break;
        case Actors.LightsPoop:
            _doorState++;
            _poopMonsterState++;
            _shadowState = Shadow.burn;
            break;
        default:
            _doorState++;
            _poopMonsterState++;
            _shadowState = Shadow.talk;
            break;
        }
    }

    void LightsPoopMessage(Actors victim){
        _doorState++;
        _poopMonsterState++;
    }

}
