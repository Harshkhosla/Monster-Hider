 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player  : MonoBehaviour
{
    [SerializeField]
    private float moveForce =10f;
    [SerializeField]
    private float jumpForce =11f;
    private float movementX;
    private Rigidbody2D mybody; 
    private SpriteRenderer sr;
    private Animator anim;
    private string WALK_ANIMATION="walk";
    private bool isGrounded;
    private string GROUNG_TAG="Ground";
    private string ENEMY_TAG ="Enemy";
    private void Awake()
    {
        mybody= GetComponent<Rigidbody2D>();
        anim =GetComponent<Animator>();
        // any updates  are done
        sr =GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeybord();
        AnimatePlayer();
       
    }
    private void FixedUpdate()
    {
         playerJump();

    }

    void PlayerMoveKeybord(){
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position+= new Vector3(movementX, 0f, 0f)*Time.deltaTime*moveForce;
    }
    void AnimatePlayer(){
        if(movementX>0){
            anim.SetBool(WALK_ANIMATION,true);
            sr.flipX=false;
        }else if(movementX<0){
            anim.SetBool(WALK_ANIMATION,true);
            sr.flipX=true;
        }else{
            anim.SetBool(WALK_ANIMATION,false);
        }
    }
    void playerJump(){
        if(Input.GetButtonDown("Jump")&& isGrounded){
            isGrounded =false;
           mybody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag(GROUNG_TAG)){
            isGrounded=true;
        }
        if(collision.gameObject.CompareTag(ENEMY_TAG)){
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag(ENEMY_TAG)){
            Destroy(gameObject);
        }
    }
}
