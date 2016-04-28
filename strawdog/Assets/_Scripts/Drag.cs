using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Drag : MonoBehaviour {
    bool dragging = false;
    float distance;
    Actors _draggedActor;
    Actors draggedVictim;
    GameObject _draggedVictimGameObject;

    List<GameObject> _hover = new List<GameObject> ();

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
        if (_hover.Count != 0) {
            _draggedVictimGameObject = _hover [0];
        }
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
        _hover.Clear ();
        Events.G.Raise(new DirectorUpdate(_draggedActor, draggedVictim));
    }


    void OnTriggerEnter2D(Collider2D other) {
        if (dragging) {
			if (other.CompareTag("Actor")) {
//				Debug.Log (other.name);
				_draggedVictimGameObject = other.gameObject;
                _hover.Add(_draggedVictimGameObject);
			}
            Debug.Log ("ENTER "+_hover);
        }
    }

    void OnTriggerExit2D(Collider2D other) {
//		Debug.Log (other.name);
        if (dragging) {
            if (other.CompareTag ("Actor")) {
                Debug.Log (_hover.Count);
                _draggedVictimGameObject = null;
                if (_hover.Count != 0) {
                    _hover.RemoveAt (_hover.Count - 1);
                }
                Debug.Log ("Exit: " + _hover);
            }
        }
    }


}