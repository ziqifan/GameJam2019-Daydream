using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ControllerInput;

public class PlayerMovement : MonoBehaviour
{
    public Animator _animator;
    
    public float MaxSpeed;
    public float JumpHeight = 7;
    public bool isGrounded;

    private Vector3 moveDirection;
    private bool stopMove = false;

    Rigidbody rb;
    BoxCollider col_size;

    // Start is called before the first frame update
    void Start()
    {
        
        //Assign player's phisics body and collider
        rb = GetComponent<Rigidbody>();
        col_size = GetComponent<BoxCollider>();
        
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Get the X and Y position of any input (laptop or controller)
         Stick stick = getSticks(0)[LS];
        setStickDeadZone(0, 0.1f);

        //Move player to that direction, forward is allways where player look at
        moveDirection = transform.forward * stick.y + transform.right * stick.x;
        moveDirection = moveDirection.normalized;
        transform.position += moveDirection * MaxSpeed * Time.deltaTime;

        //Running check for animator
        if((stick.x == 0) &&  (stick.y == 0))
        {
            _animator.SetBool("isRun", false);
        }
        else
        {
            if (!stopMove)
            {
                _animator.SetBool("isRun", true);
            }
            else
            {
                _animator.SetBool("isRun", false);
            }
        }
       
        //If player is on the ground make player jump
        if(isButtonPressed(0,(int)CONTROLLER_BUTTON.A) && isGrounded == true)
        {
            Debug.Log("Jump pls");
            rb.AddForce(0, JumpHeight, 0,ForceMode.Impulse);
            isGrounded = false;

            stopMove = true;
            _animator.SetBool("isJump", true);
        }
       
    }

    // Check player on the ground or not (Unity build in function)
    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;

        stopMove = false;
        _animator.SetBool("isJump", false);
    }
}