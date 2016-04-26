using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Actor))]
public class Actor_Lights : MonoBehaviour {

    Actors _thisActor;
    LightsPoop _priorState;
    [SerializeField] MinMax _lightRotationRange = new MinMax(70f, 120f);
    [SerializeField] GameObject _lightBeam;


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
        switch (e.LightsPoopState) {
        case LightsPoop.center:
            Debug.Log ("closed");
            break;
        case LightsPoop.side:
            Debug.Log ("locked0");
            break;
        }
        _priorState = e.LightsPoopState;
    }

    void OnMouseDrag(){
        Vector3 mouseDelta = Input.mousePosition;

        Vector3 worldMouse = Camera.main.ScreenToWorldPoint (mouseDelta);

        float angle = Mathf.Atan2 (
            worldMouse.y - transform.position.y, 
            worldMouse.x - transform.position.x) * Mathf.Rad2Deg;
//        if (angle < 0) { 
//            angle += 360;
//        }

        float tempAngle;
        if (_lightRotationRange.Max < angle) {
            tempAngle = _lightRotationRange.Max;
        } else if (_lightRotationRange.Min > angle){
            tempAngle = _lightRotationRange.Min;
        } else {
            tempAngle = angle;
        }

        transform.localEulerAngles = new Vector3 
            (transform.localEulerAngles.x,
                transform.localEulerAngles.y, 
                tempAngle+90);

        _lightBeam.transform.position = new Vector3 
            ((1f / (Mathf.Tan (tempAngle*Mathf.Deg2Rad) / (2.75f - transform.position.y))) + transform.position.x, 
                _lightBeam.transform.position.y, 
                _lightBeam.transform.position.z);
    }
}
