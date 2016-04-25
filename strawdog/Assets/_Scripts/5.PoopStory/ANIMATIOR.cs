//using UnityEngine;
//using System.Collections;
//
//// TODO: follow the player + attack the player when they collide 
//// TODO: health and attack value 
//// TODO: get hit by the arrow 
//
//public class Monster : MonoBehaviour {
//    [SerializeField] float m_healthValue;
//    private float m_attackPower;
//    private float m_type;
//
//    private Rigidbody2D m_rigidBody;
//    private Transform m_AttackCheck;
//    private Transform m_WaterCheck;
//    public GameObject m_player;
//    private float m_detectRange = 5.0f;
//    [SerializeField] float distance = 5.0f;
//    [SerializeField] float m_speed = 10.0f;
//    private Vector3 m_initPos;
//
//    private bool isPlayerInAir;
//    private bool isJumping;
//    private bool isDead;
//
//    private float m_jumpHeight = 1.25f;
//
//    private Vector3 m_velocity;
//
//    // animator 
//    private Animator m_anim;
//    private GameManager GM;
//
//
//    // Use this for initialization
//    void Awake () {
//        m_healthValue = 1.0f;
//        m_rigidBody = GetComponent<Rigidbody2D> ();
//
//        m_velocity = new Vector3 (1.0f, 1.0f, 0f);
//        m_anim = GetComponent<Animator> ();
//        m_AttackCheck = GameObject.Find ("AttackCheck").transform;
//        m_WaterCheck = GameObject.Find ("WaterCheck").transform;
//        isJumping = false;
//        isDead = false;
//
//    }
//
//    // Update is called once per frame
//    void FixedUpdate () {
//        Detect ();
//
//        isPlayerInAir = m_player.GetComponent<Forest.Player.Hero> ().m_InAir;
//
//
//        if (Input.GetKeyDown (KeyCode.Space)) {
//            //Debug.Log ("M: Monster jump test!!");
//            //StartCoroutine(Jump (new Vector3 (transform.position.x + 2.0f, transform.position.y, transform.position.z), 2.0f));
//        }
//
//    }
//
//    // initalize the monster according to the type of the monster 
//    public void InitMonster(Vector3 origin, GameObject followTarget, GameObject gm){
//        m_initPos = origin;
//        m_player = followTarget;
//        isPlayerInAir = m_player.GetComponent<Forest.Player.Hero> ().m_InAir;
//        GM = gm.GetComponent<GameManager> ();
//    }
//
//    // monster detect the player 
//    void Detect(){
//        if (Vector3.Distance (transform.position, m_player.transform.position) <= m_detectRange) {
//            Debug.Log ("M: Found you ha!");
//            m_detectRange += 0.2f * Time.deltaTime;
//            Follow ();
//        } else {
//            GoBack (m_initPos);
//        }
//
//        if (transform.position.y >= m_AttackCheck.position.y && isPlayerInAir) {
//            Vector3 jumpDestination = calJumpDirection ();
//            StartCoroutine(Jump (jumpDestination,3.0f));
//        }
//    }
//
//    // determine where to jump;
//    Vector3 calJumpDirection(){
//        Vector3 result = transform.position;
//        if (m_player.transform.position.x <= transform.position.x) {
//            result.x -= 6f;
//        } else {
//            result.x += 6f;
//        }
//        return result;
//    }
//
//    // jump out of the water 
//    IEnumerator Jump(Vector3 dest, float time) {
//        if (isJumping) yield break;
//
//        m_jumpHeight = m_WaterCheck.position.y - transform.position.y + 3.0f;
//        isJumping = true;
//        Vector3 startPos = transform.position;
//        float timer = 0.0f;
//
//        while (timer <= 1.0f) {
//            float height = Mathf.Sin(Mathf.PI * timer) * m_jumpHeight;
//            transform.position = Vector3.Lerp(startPos, dest, timer) + Vector3.up * height; 
//            timer += (Time.deltaTime / time);
//            yield return null;
//        }
//        isJumping = false;
//    }
//
//
//
//    // Smooth follow 
//    void Follow(){
//        Vector3 dir = m_player.transform.position - transform.position;
//        dir.Normalize ();
//        Vector3 delta = dir * m_speed * Time.deltaTime;
//        if (Vector3.Distance (m_player.transform.position, transform.position) >= 0.3f) {
//            transform.position = Vector3.SmoothDamp (transform.position, transform.position + delta, ref m_velocity, 0.2f);
//        }
//    }
//
//    // go back to the inital place and just move randomly around 
//
//
//    // random movement
//    void GoBack(Vector3 target){
//        Vector3 dir = target - transform.position;
//        dir.Normalize ();
//        Vector3 delta = dir * m_speed * Time.deltaTime;
//        if (Vector3.Distance (target, transform.position) >= 0.3f) {
//            transform.position = Vector3.SmoothDamp (transform.position, transform.position + delta, ref m_velocity, 0.2f);
//        }
//    }
//
//
//    // arrow collision 
//
//    void OnTriggerEnter2D(Collider2D coll) {
//        Debug.Log ("You suck");
//        if (coll.CompareTag("arrow") && !isDead) {
//            //m_healthValue = 0;
//            coll.GetComponent<BoxCollider2D>().enabled = false;
//            isDead = true;
//            GM.RemoveMonster ();
//            StartCoroutine(onMonsterDie());
//
//        }
//
//        if (coll.CompareTag ("Player")) {
//            Debug.Log ("Attak player");
//            if (!isDead) {
//                m_anim.SetTrigger ("attackTrigger");
//            }
//
//        }
//    }
//
//    void OnTriggerStay2D(Collider2D coll)
//    {
//        if (coll.CompareTag ("Player")) {
//            Debug.Log ("Attak player");
//            if (!isDead) {
//                m_anim.SetTrigger ("attackTrigger");
//            }
//        }
//
//    }
//
//    // monster die after the health value drop to zero 
//    IEnumerator onMonsterDie(){
//        Debug.Log ("##Monster: AHHHHHHHHHH");
//        m_anim.SetTrigger ("dieTrigger");
//        yield return new WaitForSeconds (2);
//        Destroy (gameObject);
//    }
//}