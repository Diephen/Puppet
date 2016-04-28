﻿using UnityEngine;
using System.Collections;

public class Ending : MonoBehaviour {

    [SerializeField] Sprite _ending1;
    [SerializeField] Sprite _ending2;
    [SerializeField] Sprite _ending3;
    SpriteRenderer _spriteRenderer;

    [SerializeField] Animator _girlAnimator;
    [SerializeField] Animator _monsterAnimator;
    [SerializeField] GameObject _blackOut;

    Fading _fading;

    void Start(){
        _spriteRenderer = gameObject.GetComponent <SpriteRenderer> ();
        _fading = gameObject.GetComponent <Fading> ();
        _spriteRenderer.enabled = false;
        _blackOut.SetActive (false);
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public void EndingReveal(int end) {
        if(end == 1){
            _spriteRenderer.sprite = _ending1;
            _monsterAnimator.Play ("MonsterWalkOut");
        } else if(end == 2){
            _spriteRenderer.sprite = _ending2;
            _girlAnimator.SetTrigger ("triggerEnd");
        } else if(end == 3) {
            _spriteRenderer.sprite = _ending3;
            _monsterAnimator.Play ("MonsterWalkOut");
        }
        StartCoroutine (WaitForEnd());
    }



    IEnumerator WaitForEnd(){
        yield return new WaitForSeconds(3f);
        _fading.BeginFade(1);
        yield return new WaitForSeconds(2f);
        _spriteRenderer.enabled = true;
        _blackOut.SetActive (true);
        _fading.BeginFade(-1);
        //        Application.LoadLevel (2);
    }
}
