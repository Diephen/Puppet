using UnityEngine;
using System.Collections;

public enum Actors {A, B, C, D}

public class ActorsInteract : GameEvent {
    public Actors Actors { get; private set; }
    public Actors Victims { get; private set; }

    public float DegreesPerSecond { get; private set; }
    public float d { get; private set; }
    public ActorsInteract (Actors actors, Actors victims){
        Actors = actors;
        Victims = victims;
    }
}

public class EventManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
//        Events.G.Raise (ActorsInteract ());
    }
	
}
