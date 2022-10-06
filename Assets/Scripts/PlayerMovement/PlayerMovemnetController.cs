using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))] //可以自動加入component進去
public class PlayerMovemnetController : MonoBehaviour
{
    public PlayerInputScheme _inputScheme;
    public CharacterController characterController; 
    [SerializeField] float moveSpeed = 10; 



    #if UNITY_EDITOR
    /// <summary>
    /// Called when the script is loaded or a value is changed in the
    /// inspector (Called in the editor only).
    /// </summary>
    private void OnValidate()
    {
        characterController = GetComponent<CharacterController>();
    }
    #endif

     /// <summary>
     /// Awake is called when the script instance is being loaded.
     /// </summary>
     private void Awake()
     {
        _inputScheme = new PlayerInputScheme();
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
            Vector3 direction = transform.TransformDirection(vector3d);
            characterController.Move(direction* moveSpeed* Time.deltaTime);
        }

    }

}
