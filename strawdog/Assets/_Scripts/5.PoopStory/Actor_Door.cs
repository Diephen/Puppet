using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Actor))]
public class Actor_Door : MonoBehaviour {

    Actors _thisActor;
    Door _priorState;

    Animator _doorAnimator;

    [SerializeField] AudioClip _chainBreak;
    [SerializeField] AudioClip _chainRattle;

    AudioSource _audioSource;

    void Awake () {
        _thisActor = gameObject.GetComponent <Actor> ()._thisActor;
		_doorAnimator = gameObject.GetComponent<Animator> ();
        _audioSource = gameObject.GetComponent<AudioSource> ();
    }

    void OnEnable () {
        Events.G.AddListener<PoopStoryAct>(ActFunction);
    }

    void OnDisable () {
        Events.G.RemoveListener<PoopStoryAct>(ActFunction);
    }

    public void ActFunction (PoopStoryAct e) {
        switch (e.DoorState) {
		case Door.closed:
            _doorAnimator.Play ("Door0");
            break;
        case Door.locked0:
            if (_priorState != Door.locked1) {
                _audioSource.Play ();
            }
            _doorAnimator.Play ("Door1");
            break;
        case Door.locked1:
            _audioSource.clip = _chainRattle;
            if (_priorState != Door.opening0 && _priorState != Door.opening1) {
                _audioSource.Play ();
            }
			_doorAnimator.Play ("Door2");
            break;
        case Door.opening0:
            _doorAnimator.Play ("Door3");
            _audioSource.clip = _chainBreak;
            _audioSource.Play ();
            break;
        case Door.opening1:
			_doorAnimator.Play ("Door4");
            break;
		case Door.opened:
			_doorAnimator.Play ("Door5");
			break;
        }
        _priorState = e.DoorState;
    }
}
