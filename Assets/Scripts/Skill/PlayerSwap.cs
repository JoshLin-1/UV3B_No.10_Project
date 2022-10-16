using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSwap : MonoBehaviour
{

    [Header("UI")]
    public GameObject RadialUI; 
    public GameObject InteractUI; 
    // private PlayerInputScheme _inputScheme;

    [Header("UI Indicator")]
    [SerializeField]private GameObject blinkText;


    [SerializeField] PlayerController _input; 
    [SerializeField] PlayerController _Items; 
    
    GameObject SwapGameObject; 
    public CameraFollow cameraFollow;
    RadialIndicatorClick Script;
    public GameObject Dialogue; 
    private bool canTalk = false; 

    
    // private bool CanPossess = false; 

   #if UNITY_EDITOR

   /// <summary>
   /// Called when the script is loaded or a value is changed in the
   /// inspector (Called in the editor only).
   /// </summary>
   private void OnValidate()
   {
        RadialUI = GameObject.Find("RadialUI");
   }

   #endif
   

    private void Awake()
    {
        // _inputScheme = new PlayerInputScheme();
        // _inputScheme.Enable();
      
    }
    void Start()
    {
        _input.EnableGameplayInput();
        Script = RadialUI.GetComponent<RadialIndicatorClick>();
    }

    public void OnEnable()
    {
        _input.onInteract += Interact;
        _input.onStopInteract += StopInteract;
    }

    public void OnDisable()
    {
        _input.onInteract -= Interact;
        _input.onStopInteract -= StopInteract;
    }

    // Update is called once per frame
    void Update()
    {
        if(SwapGameObject!= null &&Script.canInteract == true)
        {
            blinkText.transform.position = new Vector3(SwapGameObject.transform.position.x, SwapGameObject.transform.position.y+1.5f, 0);
        }
    }

    void Interact()
    {
        // if(_inputScheme.Player.Interact.triggered)
        // {
            if(SwapGameObject!= null && Script.canInteract == true)
            {
                InteractUI.SetActive(false);
                cameraFollow.target = SwapGameObject;
                // SwapGameObject.AddComponent<PlayerMovementForItems>();
                SwapGameObject.GetComponent<PlayerMovementForItems>().OnEnable();
                // SwapGameObject.AddComponent<SwapBack>();
                // RadialUI.transform.SetParent(SwapGameObject.transform);
                Script.TrackObject = SwapGameObject; 
                Script.possessObject = SwapGameObject; 
                gameObject.SetActive(false);
                
                // SwapBack.StartCount = true;
                Script.startCount = true;
                SwapGameObject = null;
            }

            if(Dialogue != null && canTalk == true)
            {
                Dialogue.SetActive(true);
            }
        // }
    }

    void StopInteract()
    {

    }

    

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Interact"))
        {
            Debug.Log("Get Object");
            SwapGameObject = other.gameObject; 
            if(Script.canInteract == true)
            {
                InteractUI.SetActive(true);
            }
        }
        if(other.CompareTag("Talk"))
        {
            Debug.Log("Interact to Talk");
            canTalk = true;
        }
    }

    /// <summary>
    /// OnTriggerExit is called when the Collider other has stopped touching the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    private void OnTriggerExit(Collider other)
    {
        SwapGameObject = null;
        Debug.Log("Lost Object");
        InteractUI.SetActive(false);
    }

}
