using UnityEngine;
using System.Collections;

public class ShadowSpawner : MonoBehaviour {
    [SerializeField] GameObject shadowPrefab;
    int _shadowCnt = 0;
    [SerializeField] int _maxShadow = 5;

    [SerializeField] string[] jeerText = new string[5];
    [SerializeField] string[] talkText = new string[5];

    Actor_Shadow _actShade;

    public string TalkGetter (int number) {
        return talkText [number];
    }

    public string JeerGetter (int number) {
        return jeerText [number];
    }

    void OnEnable () {
        Events.G.AddListener<PoopStoryAct>(ActFunction);
    }

    void OnDisable () {
        Events.G.RemoveListener<PoopStoryAct>(ActFunction);
    }

    public void ActFunction (PoopStoryAct e) {
        if(e.DoorState == Door.closed){
            if (_shadowCnt < (_maxShadow)) {
                GameObject newShadow = (GameObject)Instantiate (shadowPrefab, new Vector3 (0f, 0f, 0f), Quaternion.identity);
                newShadow.transform.parent = transform;

                _actShade = newShadow.GetComponent <Actor_Shadow> ();
                _actShade.shadowSpawnComponent ();
                _actShade.AssignID (_shadowCnt);
                _shadowCnt++;
            }
        }
    }
}
