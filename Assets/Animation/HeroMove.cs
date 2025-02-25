using UnityEngine;

public class HeroMove : MonoBehaviour
{
    //public CharacterController2D controller;
    public Animator animator;
    public Rigidbody2D rb;
    //https://www.youtube.com/watch?app=desktop&v=vAZV5xO_AHU&t=567s
    private PlayerControls controls;



    public float moveForce = 40f;
    public float jumpForce = 10f;
    float horizontalMove = 0f;
    float maxVelocity = 10f;
    private float movement;
    bool jump;
    bool isGrounded;
    bool crouch ;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //global playercontrolls we created
        controls = new PlayerControls();

        //move what are creatd inside player controlls
        controls.Player.Move.performed += ctx => movement = ctx.ReadValue<float>();

        jump = false;
        isGrounded = true;
        crouch = false;
    }



    // Update is called once per frame
    void Update()
    {
        //horizontalMove = Input.GetAxisRaw("Horizontal")* runSpeed;

        //animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        //if (Input-GetButtonDown("Jump")){
            //jump = true;
        
        //}

      //  if (GroundCheck() && Input.GetKeyDown(KeyCode.W)){
      //      rb.AddForce (transform.up * jumpForce, ForceMode2D.Impulse );
      //  }

        
    }

    private void FixedUpdate(){
        rb.velocity = new Vector2(movement * moveForce, rb.velocity.y );

    }

    private void OnEnable(){
        controls.Enable();
    }

    private void OnDisable(){
        controls.Disable();
    }

    void PlayerMove(){
        if (rb.velocity.magnitude < maxVelocity){
            rb.AddForce(Input.GetAxis("Horizontal") * Vector2.right * moveForce );

        }
    }

    void OnDrawGizmos(){
      //  Gizmos.color = Color.green;
      //  gizmos.DrawCube(transform.position - transform.up * maxDistance, boxSize);
    }


    private bool GroundCheck(){

    //    if (Physics2D.BoxCast(transform.position, boxSize,0,-transform.up, maxDistance, layerMask)){
    //        return true;
    //    }
    //    else{
    //        return false;
    //    }
        return true;

    }

    private void Jump(){
        if (isGrounded){
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        }

    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Ground")){
            isGrounded = true;


        }

    }




}
