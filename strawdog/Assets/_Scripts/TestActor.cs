using UnityEngine;
using System.Collections;

public class TestActor : MonoBehaviour {

	// Use this for initialization
	void Start () {
//        Events.G.Raise (ActorsInteract ());
        Events.G.Raise(new ActorsInteract(Actors.A,Actors.B));
	}

    void OnEnable () {
        Events.G.AddListener<ActorsInteract>(ActFunction);
    }

    void OnDisable () {
        Events.G.RemoveListener<ActorsInteract>(ActFunction);
    }

    void ActFunction (ActorsInteract e) {
        Debug.Log (e.Actors);
        Debug.Log (e.Victims);
    }
}
