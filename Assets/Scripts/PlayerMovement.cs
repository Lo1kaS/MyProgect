using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    bool movenow = false;
    bool isJump = false;
    private Animator anim;

    [SerializeField]
    private CharacterController controller;

    [SerializeField]
     float speed = 12f;

    [SerializeField]
     float gravityVelocity = -9.81f;
    Vector3 gravity;
  
    [SerializeField]
    Transform GroundCheck;
     float groundDistance = 0.4f;
    
    [SerializeField]
    LayerMask groundMask;

    bool isGrounded;

    float jumpHeight = 3f;
    Vector2 lastdirection;
    private InputSettings _input;
    private void Awake()
    {
        _input = new InputSettings();

        anim = GetComponentInChildren<Animator>();
    }
   
    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }
    private void Idle()
    {
        anim.SetFloat("Speed",0, 0.1f, Time.deltaTime);
    }
    private void Walk()
    {
        anim.SetFloat("Speed", 1, 0.1f, Time.deltaTime);
    }
    private void Junp()
    {
        anim.SetTrigger("Jump");
    }
    private void JumpAndRun()
    {
        anim.SetTrigger("JumpAndRun");
        
    }
    void Update()
    {
        
        isGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, groundMask);
        if (isGrounded)
        {
            isJump = false;
        }
        if (isGrounded && gravity.y < -10 && !this.GetComponent<Respawn>().unstatic)
        {
            
            gravity.y = -2f;
        }
        if(_input.Player.Jump.WasPressedThisFrame() && isGrounded && !this.GetComponent<Respawn>().unstatic)
        {
            isJump = true;
            gravity.y = Mathf.Sqrt(jumpHeight * -2f * gravityVelocity );
        }
        if (_input.Player.Move.ReadValue<Vector2>() != null && !this.GetComponent<Respawn>().unstatic)
        {

            Vector2 direction = _input.Player.Move.ReadValue<Vector2>();
           
            if (direction.x == 0 && direction.y == 0)
            {
                if (isJump)
                {
                    Junp();
                    controller.Move(gravity * Time.deltaTime);

                }
                else
                {
                    Idle();
                    controller.Move(gravity * Time.deltaTime);
                }
                
                
            }
            else
            {

                if (isJump)
                {
                    JumpAndRun();
                    Moved(direction.x, direction.y);

                }
                else
                {
                    Walk();
                    Moved(direction.x, direction.y);
                }
                
            }
                
             
           
            
                
            
            
        }
        gravity.y += gravityVelocity * Time.deltaTime;
    }
    private void Moved(float xAxis, float zAxis)
    {
        movenow = true;
        
        Vector3 moved = transform.right * xAxis + transform.forward * zAxis;

        controller.Move(moved * speed * Time.deltaTime);

        controller.Move(gravity * Time.deltaTime);

    }
}
