using UnityEngine;
using System.Collections;

public class ShadowSpawner : MonoBehaviour {
    [SerializeField] GameObject shadowPrefab_left;
    [SerializeField] GameObject shadowPrefab_right;
    int _shadowCnt = 0;
    [SerializeField] int _maxShadow = 5;

    [SerializeField] string[] jeerText = new string[5];
    [SerializeField] string[] talkText = new string[5];
    [SerializeField] Vector3[] _spawnPos = new Vector3[5];

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

            //which prefab?
            GameObject shadowPrefab;
            if(_shadowCnt%2 == 0){
                shadowPrefab = shadowPrefab_left;
            } else {
                shadowPrefab = shadowPrefab_right;
            }

            if (_shadowCnt < (_maxShadow)) {
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
        }
    }
}
