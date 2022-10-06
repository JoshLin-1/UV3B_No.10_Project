using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementForItems : MonoBehaviour
{
   
    public PlayerInputScheme _inputScheme;
    public Rigidbody m_Rigidbody;
    [SerializeField] float moveSpeed = 50; 



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
        _inputScheme = new PlayerInputScheme();
        Enable();
     }

     private void Disable()
     {
        _inputScheme.Disable();
     }

     private void Enable()
     {
        _inputScheme.Enable();
     }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vector2d = _inputScheme.Player.Movement.ReadValue<Vector2>();
        if(vector2d!= Vector2.zero)
        {
            Vector3 vector3d = new Vector3(vector2d.x, vector2d.y, 0);
            // Vector3 direction = transform.TransformDirection(vector3d);
            m_Rigidbody.AddForce(vector3d* moveSpeed* Time.deltaTime);
        }

    }
}
