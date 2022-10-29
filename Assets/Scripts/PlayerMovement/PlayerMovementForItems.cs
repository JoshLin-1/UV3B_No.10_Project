using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor; 


[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementForItems : MonoBehaviour
{
   
    [SerializeField] PlayerController _input; 
    public Rigidbody m_Rigidbody;

    // Vector3 moveAmount; 

    // PlayerInputScheme _inputScheme; 
    [SerializeField] float moveSpeed = 50; 
    [SerializeField] float jumpValue = 10; 



    #if UNITY_EDITOR
    /// <summary>
    /// Called when the script is loaded or a value is changed in the
    /// inspector (Called in the editor only).
    /// </summary>
    private void OnValidate()
    {
        m_Rigidbody = GetComponent<Rigidbody>();


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
     }
     public void OnDisable()
     {
        _input.onMovement -= Move; 
        _input.onStopMove -= StopMove; 
        _input.onJump -= Jump;

     }


    // Start is called before the first frame update
    void Start()
    {
       _input.EnableGameplayInput();
       OnDisable();
    }

    // Update is called once per frame
    void Update()
    {
        // Vector2 vector2d = _inputScheme.Player.Movement.ReadValue<Vector2>();
        // if(vector2d!= Vector2.zero)
        // {
        //     Vector3 vector3d = new Vector3(vector2d.x, vector2d.y, 0);
        //     Vector3 direction = transform.TransformDirection(vector3d);
            // m_Rigidbody.AddForce(moveAmount* moveSpeed* Time.deltaTime);
        // }
    }

    void Move(Vector2 moveInput)
    {
        Debug.Log("Detect");
        // moveAmount = new Vector3(moveInput.x, moveInput.y, 0); 
        Vector3 moveAmount = new Vector3(moveInput.x* moveSpeed, 0 ,moveInput.y* moveSpeed); 
        m_Rigidbody.velocity = moveAmount;
    }

    void StopMove()
    {
        // m_Rigidbody.velocity = Vector2.zero; 
    }

    void Jump()
    {
        m_Rigidbody.velocity += new Vector3(0, jumpValue, 0);
    }
    
}
