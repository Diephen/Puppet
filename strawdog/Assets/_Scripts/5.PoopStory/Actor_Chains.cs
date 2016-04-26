using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Actor))]
public class Actor_Chains : MonoBehaviour {


    [SerializeField] MinMax _chainRotationRange = new MinMax(0f, 180f);
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
        if(e.DoorState == Door.opening0){
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

    void OnMouseDrag () {
        if (_internalState == Chain.loose) {
            Vector3 mouseDelta = Input.mousePosition;

            Vector3 worldMouse = Camera.main.ScreenToWorldPoint (mouseDelta);

            float angle = Mathf.Atan2 (
                          worldMouse.y - transform.position.y, 
                          worldMouse.x - transform.position.x) * Mathf.Rad2Deg;

            float tempAngle;
            if (_chainRotationRange.Max < angle) {
                tempAngle = _chainRotationRange.Max;
            } else if (_chainRotationRange.Min > angle) {
                tempAngle = _chainRotationRange.Min;
            } else {
                tempAngle = angle;
            }

            transform.localEulerAngles = new Vector3 (transform.localEulerAngles.x,
                transform.localEulerAngles.y, 
                tempAngle + 90);
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
//        if (dragging) {
//            Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
//            Vector3 rayPoint = ray.GetPoint(distance);
//            rayPoint.z = transform.position.z;
//            transform.position = rayPoint;
//        }
    }




    void CheckCollision() {
        Actors draggedVictim = Actors.Null;
        //check if dropped on actor
        if (_draggedVictimGameObject != null && _draggedVictimGameObject.GetComponent <Actor> () != null) {    
            draggedVictim = _draggedVictimGameObject.GetComponent <Actor> ()._thisActor;
            if(draggedVictim == Actors.Hole){
				_draggedVictimGameObject.GetComponent<Hole> ().locked ();
                transform.localEulerAngles = new Vector3 (0f, 0f, 0f);

                _internalState = Chain.locked;
//                GUISettings hole as undragintoable
//                _draggedVictimGameObject.
            }
        } else {
            draggedVictim = Actors.Null;
        }
        Debug.Log ("Act: " + _draggedActor+", Vict: " + draggedVictim);
        Events.G.Raise(new DirectorUpdate(_draggedActor, draggedVictim));
    }


    void OnTriggerEnter2D(Collider2D other) {
        if (dragging) {
            _draggedVictimGameObject = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        _draggedVictimGameObject = null;
    }
}
