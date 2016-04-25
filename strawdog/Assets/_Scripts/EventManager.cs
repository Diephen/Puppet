using UnityEngine;
using System.Collections;

public enum Actors {A, B, C, D, Girl, Door, Chain, PoopMonster, Shadow, LightsPoop, Hole, LightArea, Null}


//Poop Story
public enum Girl {atDoor, atBlank, atShadow}
public enum Door {closed, locked0, locked1, opening0, opening1, opened}
public enum Chain {locked, loose, draggable, nonDraggable}
public enum PoopMonster {A, B, C, D, E, F}
public enum Shadow {hide, lurk, talk, jeer, burn}
public enum LightsPoop {center, side}


public class ActorsInteract : GameEvent {
    public Actors Actors { get; private set; }
    public Actors Victims { get; private set; }

    public ActorsInteract (Actors actors, Actors victims){
        Actors = actors;
        Victims = victims;
    }
}


public class PoopStoryAct : GameEvent {
    public Girl GirlState { get; private set; }
    public Door DoorState { get; private set; }
    public Chain ChainState { get; private set; }
    public PoopMonster PoopMonsterState { get; private set; }
    public Shadow ShadowState { get; private set; }
    public LightsPoop LightsPoopState { get; private set; }

    public PoopStoryAct (Girl girlState, Door doorState, Chain chainState, PoopMonster poopMonsterState, Shadow shadowState, LightsPoop lightsPoopState){
        GirlState = girlState;
        DoorState = doorState;
        ChainState = chainState;
        PoopMonsterState = poopMonsterState;
        ShadowState = shadowState;
        LightsPoopState = lightsPoopState;
    }
}

public class DirectorUpdate : GameEvent {
    public Actors Actors { get; private set; }
    public Actors Victims { get; private set; }

    public DirectorUpdate (Actors actors, Actors victims){
        Actors = actors;
        Victims = victims;
    }
}

public class EventManager: MonoBehaviour {
        
}
	

