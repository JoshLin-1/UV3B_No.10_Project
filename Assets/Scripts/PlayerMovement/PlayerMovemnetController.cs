using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))] //可以自動加入component進去
// [RequireComponent(typeof(Rigidbody))] //可以自動加入component進去
public class PlayerMovemnetController : MonoBehaviour
{
    [SerializeField] PlayerController _input; 
    // public PlayerInputScheme _inputScheme;
    CharacterController characterController; 
    // new Rigidbody rigidbody; 
    public Vector3 direction; 
    [SerializeField] float moveSpeed = 50; 

    #if UNITY_EDITOR
    /// <summary>
    /// Called when the script is loaded or a value is changed in the
    /// inspector (Called in the editor only).
    /// </summary>
    private void OnValidate()
    {
        characterController = GetComponent<CharacterController>();
        // rigidbody = GetComponent<Rigidbody>();
    }
    #endif

     /// <summary>
     /// Awake is called when the script instance is being loaded.
     /// </summary>
     private void Awake()
     {
        // _inputScheme = new PlayerInputScheme();
        // _inputScheme.Enable();

     }

    public void OnEnable()
    {
        _input.onMovement += Move;
        _input.onStopMove += StopMove;
        _input.onJump += Jump;
        _input.onStopJump += StopJump;

    }

    void OnDisable()
    {
        _input.onMovement -= Move;
        _input.onStopMove -= StopMove;
        _input.onJump -= Jump;
        _input.onStopJump -= StopJump;

    }
    
    void Start()
    {
        // rigidbody.useGravity = false; 
        _input.EnableGameplayInput();
    }

    // Update is called once per frame
    void Update()
    {
        // Vector2 vector2d = _inputScheme.Player.Movement.ReadValue<Vector2>();
        // if(vector2d!= Vector2.zero)
        // {
            // Vector3 vector3d = new Vector3(vector2d.x, vector2d.y, 0);
            // Vector3 direction = transform.TransformDirection(vector3d);
            // characterController.Move(direction* moveSpeed* Time.deltaTime);
        // }
        
        characterController.Move(direction* moveSpeed* Time.deltaTime);    
        
    }

    void Move(Vector2 moveInput)
    {
        Vector3 vector3d = new Vector3(moveInput.y,-1 , -moveInput.x);
        direction = vector3d;
        //transform.TransformDirection(vector3d);    

        Debug.Log(moveInput.x);

        if(moveInput.x>0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (moveInput.x<0)
        {
                       transform.rotation = Quaternion.Euler(0, 180, 0);

        }
        else if (moveInput.y<0)
        {
        
                        transform.rotation = Quaternion.Euler(0, 90, 0);


        }
        else if(moveInput.y>0)
        {
                        transform.rotation = Quaternion.Euler(0, 270, 0);


        }
    }

    void StopMove()
    {
        direction = Vector3.zero; 
        // rigidbody.velocity = Vector2.zero; 
        // moveAmount = new Vector2(0,0); 
    }

    void Jump()
    {
        direction += new Vector3(0, 1, 0) ;
    }

    void StopJump()
    {
        direction -= new Vector3(0,2,0);
    }

}
