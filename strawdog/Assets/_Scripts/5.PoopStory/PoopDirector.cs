using UnityEngine;
using System.Collections;

public class PoopDirector : MonoBehaviour {
    Girl _girlState = Girl.atBlank;
    Door _doorState = Door.closed;
    Chain _chainState = Chain.locked;
    PoopMonster _poopMonsterState = PoopMonster.A;
    Shadow _shadowState = Shadow.hide;
    LightsPoop _lightsPoopState = LightsPoop.center;

    AudioSource _audioSource;

    int _chainHandler = 0;

    public static int _turns;

    void Awake(){
        _turns = 0;    
        _audioSource = gameObject.GetComponent<AudioSource> ();
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
        if(_doorState == Door.opening0){
            _chainHandler = 0;
        }
        _audioSource.volume = (float)_doorState / 7f;
        _audioSource.Play ();
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
		case Actors.Hole:
			_girlState = Girl.atDoor;
			_doorState++;
			_poopMonsterState++;
			break;
		case Actors.LightArea:
			_girlState = Girl.atDoor;
			_doorState++;
			_poopMonsterState++;
			break;
        case Actors.Shadow:
            _girlState = Girl.atShadow;
            _doorState++;
            _poopMonsterState++;
            _shadowState = Shadow.jeer;
            break;
        case Actors.LightsPoop:
			_girlState = Girl.atDoor;
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
        
        switch(victim){
        case Actors.Hole:
            _chainHandler++;
            Debug.Log (_chainHandler);
            if(_chainHandler == 1){
                _doorState = Door.locked1;
                _poopMonsterState = PoopMonster.C;
            } else if(_chainHandler == 2) {
                _doorState = Door.locked0;
                _poopMonsterState = PoopMonster.B;
            } else if(_chainHandler == 3){
                _doorState = Door.closed;
                _poopMonsterState = PoopMonster.A;
            }
            break;
        default:
            _doorState++;
            _poopMonsterState++;
            break;
        }
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
//            _doorState = Door.closed;
            _poopMonsterState++;
            _shadowState = Shadow.jeer;
            break;
        case Actors.Door:
            _doorState++;
            _poopMonsterState++;
            _shadowState = Shadow.jeer;
            break;
        case Actors.Chain:
            _doorState++;
            _poopMonsterState++;
            _shadowState = Shadow.jeer;
            break;
        case Actors.PoopMonster:
            _doorState++;
            _poopMonsterState++;
            _shadowState = Shadow.jeer;
            break;
        case Actors.LightsPoop:
            _doorState++;
            _poopMonsterState++;
            _shadowState = Shadow.jeer;
            break;
        case Actors.LightArea:
            _doorState++;
            _poopMonsterState++;
            _shadowState = Shadow.jeer;
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
