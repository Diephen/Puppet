using UnityEngine;
using System.Collections;

public class Hole : MonoBehaviour {

    [SerializeField] bool _available = true;
    BoxCollider2D bc2;

    void Start () {
        bc2 = gameObject.GetComponent <BoxCollider2D> ();
    }

    public void locked(){
        _available = false;
        bc2.enabled = false;
    }

    void OnEnable () {
        Events.G.AddListener<PoopStoryAct>(ActFunction);
    }

    void OnDisable () {
        Events.G.RemoveListener<PoopStoryAct>(ActFunction);
    }

    public void ActFunction (PoopStoryAct e) {
        if (e.DoorState == Door.opened) {
            _available = true;
            bc2.enabled = true;
        }
    }
}
