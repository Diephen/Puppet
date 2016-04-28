using UnityEngine;
using System.Collections;

public class Start : MonoBehaviour {


	
	// Update is called once per frame
    void Update () {
//        if (Input.anyKeyDown) {
//            StartCoroutine(restartLevel());
//        }
    }

    IEnumerator restartLevel(){
        yield return new WaitForSeconds(.5f);
        gameObject.GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(.6f);
        Application.LoadLevel (2);
    }

    void OnTriggerEnter2D(Collider2D other) {
        StartCoroutine(restartLevel());
    }
}
