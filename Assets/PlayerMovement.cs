using UnityEngine;
using System.Collections;

//Arrow Keys to move
//Up Arrow again in the air to expened double jump
//Quickly double tap Left or Right to dash

public class PlayerMovement : MonoBehaviour {
    public static bool canJump = false;
    public static bool canDash = true;
    public static bool canJumpDash = true;
    public static bool isJumping = true;

    private float Jumps = 2;

    private float lastTimeD;
    private float lastTimeA;

    public float runSpeed;
    public float dashDistance;

    public float dashFrameCounterRight = 100;
    public float dashFrameCounterLeft = 100;

    public AudioSource Jump;
    public AudioSource DashWoosh;

    // Use this for initialization
    void Start () {
        AudioSource[] audios = GetComponents<AudioSource>();
        Jump = audios[1];
        DashWoosh = audios[0];
	
	}
	
	// Update is called once per frame
	void Update () {
        

        Vector2 jump = new Vector2(0, 350);
        Vector2 jump2 = new Vector2(0, 100);

        dashFrameCounterRight = dashFrameCounterRight + 1;
        dashFrameCounterLeft = dashFrameCounterLeft + 1;

        if (Input.GetKeyDown(KeyCode.UpArrow) && canJump == false && Jumps > 0)
        {
            Jump.Play();
            GetComponent<Rigidbody2D>().AddForce(jump2, ForceMode2D.Force);
            Jumps = Jumps - 1;
            Debug.Log("# of Jumps =" + Jumps);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && canJump == true)
        {
            Jump.Play();
            GetComponent<Rigidbody2D>().AddForce(jump, ForceMode2D.Force);
            Jumps = Jumps - 1;
            canJump = false;
            isJumping = true;
            Debug.Log("# of Jumps =" + Jumps); 
        }
        //Dash Right
        
        //Jump Dash Right
        if (Input.GetKeyDown(KeyCode.RightArrow) && Time.time - lastTimeD < .1 && canJump == false && canJumpDash == true)
        {
            DashWoosh.Play();
            dashFrameCounterRight = 1;

            Debug.Log("Dash");
            canJumpDash = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKey(KeyCode.RightArrow) && canJump == false && canJumpDash == true)
        {
            DashWoosh.Play();
            dashFrameCounterRight = 1;

            Debug.Log("Dash");
            canJumpDash = false;
        }

        //Dashing Code
        if (dashFrameCounterRight > 0 && dashFrameCounterRight < 11)
        {
            transform.localScale += new Vector3(.0587536f,-.03980123f, 0);
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * dashDistance);
            GetComponent<Rigidbody2D>().gravityScale = 0;
            canDash = false;
            Debug.Log("Running While loop RIGHT");
        }
        if (dashFrameCounterRight > 11 && dashFrameCounterRight < 21)
        {
            transform.localScale += new Vector3(-.0587536f, .03980123f, 0);
            GetComponent<Rigidbody2D>().AddForce(Vector2.left * (dashDistance - 10));
            GetComponent<Rigidbody2D>().gravityScale = 1;
            canDash = false;
            Debug.Log("Running Other While Loop RIGHT");
        }
        if (dashFrameCounterRight > 22 && dashFrameCounterRight < 24)
        {
            transform.localScale = new Vector3 (0.7326964f, 0.6413806f, 0f);
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * dashDistance);
            dashFrameCounterRight = 100;
            canDash = true;
            Debug.Log("Running The Last Other While Loop RIGHT");
        }

        //Ground Dash
        if (Input.GetKeyDown(KeyCode.RightArrow) && Time.time - lastTimeD < .1 && canJump == true && canDash == true)
        {
            DashWoosh.Play();
            dashFrameCounterRight = 1;
            Debug.Log("Dash RIGHT");
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKey(KeyCode.RightArrow) && canJump == true && canDash == true)
        {
            DashWoosh.Play();
            dashFrameCounterRight = 1;

            Debug.Log("Dash");
            canDash = false;
        }

        //Move Right
        if (Input.GetKey(KeyCode.RightArrow) )
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * runSpeed);
            lastTimeD = Time.time;

        }
        //Turn Right During Jump
        if (Input.GetKey(KeyCode.RightArrow) && isJumping && Time.time - lastTimeA < .3)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * (runSpeed * 2));
            lastTimeD = Time.time;

        }

        //Move Down
        if (Input.GetKey(KeyCode.DownArrow) )
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.down * runSpeed);
        }

        //Dash Left

        //Jump Dash Left
        if (Input.GetKeyDown(KeyCode.LeftArrow) && Time.time - lastTimeA < .1 && canJump == false && canJumpDash == true)
        {
            DashWoosh.Play();
            dashFrameCounterLeft = 1;
            Debug.Log("Dash");
            canJumpDash = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKey(KeyCode.LeftArrow) && canJump == false && canJumpDash == true)
        {
            DashWoosh.Play();
            dashFrameCounterLeft = 1;
            Debug.Log("Dash");
            canJumpDash = false;
        }

        //Dashing
        if (dashFrameCounterLeft > 0 && dashFrameCounterLeft < 11)
        {
            transform.localScale += new Vector3(.0587536f, -.03980123f, 0);
            GetComponent<Rigidbody2D>().AddForce(Vector2.left * dashDistance);
            GetComponent<Rigidbody2D>().gravityScale = 0;
            Debug.Log("Running While loop LEFT");
            canDash = false;
        }
        if (dashFrameCounterLeft > 11 && dashFrameCounterLeft < 21)
        {
            transform.localScale += new Vector3(-.0587536f, .03980123f, 0);
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * (dashDistance - 10));
            GetComponent<Rigidbody2D>().gravityScale = 1;
            Debug.Log("Running Other While Loop LEFT");
            canDash = false;
        }
        if (dashFrameCounterLeft > 22 && dashFrameCounterLeft < 24)
        {
            transform.localScale = new Vector3(0.7326964f, 0.6413806f, 0f);
            GetComponent<Rigidbody2D>().AddForce(Vector2.left * dashDistance);
            dashFrameCounterLeft = 100;
            Debug.Log("Running The Last Other While Loop LEFT");
            canDash = true;
        }

        //Grounded Dash Left
        if (Input.GetKeyDown(KeyCode.LeftArrow)  && Time.time - lastTimeA < .1 && canJump == true && canDash == true)
        {
            DashWoosh.Play();
            dashFrameCounterLeft = 1;
            Debug.Log("Dash LEFT");
            
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKey(KeyCode.LeftArrow) && canJump == true && canDash == true)
        {
            DashWoosh.Play();
            dashFrameCounterLeft = 1;

            Debug.Log("Dash");
            canDash = false;
        }

        //Move Left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.left * runSpeed);
            lastTimeA = Time.time;
        }
        //Turn Left During Jump
        if (Input.GetKey(KeyCode.LeftArrow) && isJumping && Time.time - lastTimeD < .3)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.left * (runSpeed * 2));
            lastTimeA = Time.time;
        }

    }

    //Checking if Player is on the Floor to be able to jump
    void OnCollisionEnter2D (Collision2D collision) {
        if (collision.gameObject.tag == "Floor")
        {
            isJumping = false;
            canJump = true;
            canJumpDash = true;
            Jumps = 2;
            Debug.Log("Can Jump");
            Debug.Log("# of Jumps =" + Jumps);
        }
   
       
    }
}
