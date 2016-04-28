using UnityEngine;
using System.Collections;

public class Drag : MonoBehaviour {
    bool dragging = false;
    float distance;
    Actors _draggedActor;
    Actors draggedVictim;
    GameObject _draggedVictimGameObject;


    void Awake() {
        _draggedActor = gameObject.GetComponent<Actor> ()._thisActor;
    }

    void OnMouseDown() {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
    }

    void OnMouseUp() {
        dragging = false;
        CheckCollision ();
    }

    void Update() {
        if (dragging) {
            Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            rayPoint.z = transform.position.z;
            transform.position = rayPoint;
        }
    }

    void CheckCollision() {
        
        //check if dropped on actor
        if (_draggedVictimGameObject != null && _draggedVictimGameObject.GetComponent <Actor> () != null) {    
            
            draggedVictim = _draggedVictimGameObject.GetComponent <Actor> ()._thisActor;
        } else {
            draggedVictim = Actors.Null;
        }
        if(draggedVictim == Actors.Shadow){
            _draggedVictimGameObject.GetComponent <Actor_Shadow> ().ThisShadow ();
        }
        Debug.Log ("Act: " + _draggedActor+", Vict: " + draggedVictim);
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