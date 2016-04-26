using UnityEngine;
using System.Collections;

public class Hole : MonoBehaviour {

    [SerializeField] bool _available = true;
	[SerializeField] GameObject _chain;
	Animator chain_Anim;
    BoxCollider2D bc2;

    void Start () {
        bc2 = gameObject.GetComponent <BoxCollider2D> ();
		chain_Anim = _chain.GetComponent<Animator> ();

    }

	public void locked(){
        _available = false;
        bc2.enabled = false;
        chain_Anim.Play ("idle");
    }

    void OnEnable () {
        Events.G.AddListener<PoopStoryAct>(ActFunction);
    }

    void OnDisable () {
        Events.G.RemoveListener<PoopStoryAct>(ActFunction);
    }

    public void ActFunction (PoopStoryAct e) {
        Debug.Log (e.DoorState);
		if (e.DoorState == Door.opening0) {
            
            _available = true;
            bc2.enabled = true;
			chain_Anim.Play ("break");

        }
    }
}
