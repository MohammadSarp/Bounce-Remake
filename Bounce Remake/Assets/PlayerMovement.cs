using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    bool isGround;

    public static float horizontalMove = 0;
    public LayerMask ground;

    public PhysicsMaterial2D physicsMaterial2D;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space) && isGround){
            Jump();
        }

        Movement();


        if(Input.GetKeyDown(KeyCode.X)){
            physicsMaterial2D.bounciness = 0;
        }
    }


    public void Movement(){

        horizontalMove = Input.GetAxis("Horizontal");
        Vector3 target = new Vector3(horizontalMove * 6, rb.velocity.y);
        rb.velocity = Vector3.MoveTowards(rb.velocity, target,  2);
    }

    void OnCollisionEnter2D(Collision2D collider){
        
        if(collider.gameObject.tag == "Ground"){
            isGround = true;
        }
    }

    public void Jump(){

        if(isGround){
            rb.velocity = new Vector2(rb.velocity.x, 10f);
            isGround = false;
        }
    }


} 