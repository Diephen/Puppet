using UnityEngine;
using System.Collections;

public class Actor_Lights : MonoBehaviour {

    Actors _thisActor;
    LightsPoop _priorState;

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


    void OnMouseDown(){
//        Vector3 mousePosition = 
    
    }
    void OnMouseDrag(){
        Vector3 mouseDelta = Input.mousePosition;

        Vector3 worldMouse = Camera.main.ScreenToWorldPoint (mouseDelta);

        float angle = Mathf.Atan2 (worldMouse.y - transform.position.y, worldMouse.x - transform.position.x) * Mathf.Rad2Deg;
        if (angle < 0) { 
            angle += 360;
        }

        Debug.Log (angle);

        transform.localEulerAngles = new Vector3 
            (transform.localEulerAngles.x,
                transform.localEulerAngles.y, 
                angle+90);
    }
}
