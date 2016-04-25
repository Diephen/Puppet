using UnityEngine;
using System.Collections;

public class Actor_Chains : MonoBehaviour {

    Actors _thisActor;
    Chain _internalState;

    bool dragging = false;
    float distance;
    Actors _draggedActor;
    GameObject _draggedVictimGameObject;

    void Awake () {
        _thisActor = gameObject.GetComponent <Actor> ()._thisActor;
        _draggedActor = Actors.Chain;

    }

    void OnEnable () {
        Events.G.AddListener<PoopStoryAct>(ActFunction);
    }

    void OnDisable () {
        Events.G.RemoveListener<PoopStoryAct>(ActFunction);
    }

    public void ActFunction (PoopStoryAct e) {
        if(e.DoorState == Door.opened){
            _internalState = Chain.loose;
        }
    }

    void OnMouseDown() {
        if (_internalState == Chain.loose) {
            distance = Vector3.Distance (transform.position, Camera.main.transform.position);
            dragging = true;
        } else if (_internalState == Chain.locked) {
            //TODO: Just Scene response things
        }
    }

    void OnMouseUp() {
        if (_internalState == Chain.loose) {
            dragging = false;
            CheckCollision ();
        } else if (_internalState == Chain.locked) {
            //TODO: Just Scene response things
        }
    }

    void Update() {
        if (dragging) {
            Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = rayPoint;
        }
    }



    void CheckCollision() {
        Actors draggedVictim = Actors.Null;
        //check if dropped on actor
        if (_draggedVictimGameObject != null) {          
            draggedVictim = _draggedVictimGameObject.GetComponent <Actor> ()._thisActor;
            if(draggedVictim == Actors.Hole){
                _draggedVictimGameObject.GetComponent<Hole> ().locked ();
//                GUISettings hole as undragintoable
//                _draggedVictimGameObject.
            }
        }
            
        Events.G.Raise(new DirectorUpdate(_draggedActor, draggedVictim));
    }


    void OnTriggerEnter2D(Collider2D other) {
        if (dragging) {
            Debug.Log (other.name);
            _draggedVictimGameObject = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        _draggedVictimGameObject = null;
    }
}
