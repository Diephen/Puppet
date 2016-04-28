using UnityEngine;
using System.Collections;

public class ShadowSpawner : MonoBehaviour {
    [SerializeField] GameObject shadowPrefab_left;
    [SerializeField] GameObject shadowPrefab_right;
    int _shadowCnt = 0;
    [SerializeField] int _maxShadow = 5;

    [SerializeField] string[] jeerText = new string[5];
    [SerializeField] string[] talkText = new string[5];
    [SerializeField] AudioClip[] jeerClip = new AudioClip[5];
    [SerializeField] AudioClip[] talkClip = new AudioClip[5];
    [SerializeField] Vector3[] _spawnPos = new Vector3[5];

    [SerializeField] Ending _ending;

    int _shadowDeath = 0;

    Actor_Shadow _actShade;

    AudioSource _audioSource;

    public AudioClip TalkGetter (int number) {
        return talkClip [number];
    }

    public AudioClip JeerGetter (int number) {
        return jeerClip [number];
    }

    public void ShadowDeathHandler () {
        _shadowDeath++;
    }

    void Start() {
        _audioSource = gameObject.GetComponent<AudioSource> ();
    }

    void OnEnable () {
        Events.G.AddListener<PoopStoryAct>(ActFunction);
    }

    void OnDisable () {
        Events.G.RemoveListener<PoopStoryAct>(ActFunction);
    }

    public void ActFunction (PoopStoryAct e) {
        if(e.DoorState == Door.closed){

            //which prefab?
            GameObject shadowPrefab;
            if(_shadowCnt%2 == 0){
                shadowPrefab = shadowPrefab_left;
            } else {
                shadowPrefab = shadowPrefab_right;
            }

            if (_shadowCnt < (_maxShadow)) {
                _audioSource.Play ();
                GameObject newShadow = (GameObject)Instantiate (shadowPrefab, 
                    new Vector3 (_spawnPos[_shadowCnt].x, 
                        _spawnPos[_shadowCnt].y, 
                        _spawnPos[_shadowCnt].z), 
                    Quaternion.identity);
                newShadow.transform.parent = transform;

                _actShade = newShadow.GetComponent <Actor_Shadow> ();
                _actShade.shadowSpawnComponent ();
                _actShade.AssignID (_shadowCnt);
                _shadowCnt++;
            }
        } else if(e.DoorState == Door.opened) {
            if(_shadowDeath == 0){
                _ending.EndingReveal(1);
                //ENDING 
            } else if (_shadowCnt == _shadowDeath){
                _ending.EndingReveal(3);
            }
        } else if (e.DoorState == Door.locked0){
            if (_maxShadow == _shadowCnt) {
                _ending.EndingReveal (2);
            }
        }
    }
}
