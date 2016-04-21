using UnityEngine;
using System.Collections;

public enum Actors {A, B, C, D, Girl, Door, Chain, PoopMonster, Shadow, PoopParticle, Null}


//Poop Story
public enum Girl {A, B, C, D}
public enum Door {A, B, C, D}
public enum Chain {A, B, C, D}
public enum PoopMonster {A, B, C, D}
public enum Shadow {A, B, C, D}
public enum PoopParticle {A, B, C, D}


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
    public PoopParticle PoopParticleState { get; private set; }

    public PoopStoryAct (Girl girlState, Door doorState, Chain chainState, PoopMonster poopMonsterState, Shadow shadowState, PoopParticle poopParticleState){
        GirlState = girlState;
        DoorState = doorState;
        ChainState = chainState;
        PoopMonsterState = poopMonsterState;
        ShadowState = shadowState;
        PoopParticleState = poopParticleState;
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

public class EventManager {

    }
	

