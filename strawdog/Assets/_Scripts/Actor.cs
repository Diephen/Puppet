using UnityEngine;
using System.Collections;

public class Actor : MonoBehaviour {

    [SerializeField] Actors _setActor = Actors.A;
    public Actors _thisActor { 
        get {
            return _setActor;
        } 
        private set {
            _thisActor = _setActor;
        } 
    }
}