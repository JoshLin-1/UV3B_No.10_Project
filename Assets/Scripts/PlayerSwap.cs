using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwap : MonoBehaviour
{

    [Header("UI")]
    public GameObject RadialUI; 
    private PlayerInputScheme _inputScheme;
    
    GameObject SwapGameObject; 
    public CameraFollow cameraFollow;
    RadialIndicatorClick radialIndicatorClick;
    public GameObject Dialogue; 
    private bool canTalk = false; 

    // Start is called before the first frame update

    private void Awake()
    {
        _inputScheme = new PlayerInputScheme();
        _inputScheme.Enable();
        RadialUI = GameObject.Find("Radial");
    }
    void Start()
    {
        radialIndicatorClick = RadialUI.GetComponent<RadialIndicatorClick>();
    }

    // Update is called once per frame
    void Update()
    {
        Interact();
       
    }

    private void Interact()
    {
        if(_inputScheme.Player.Interact.triggered)
        {
            if(SwapGameObject!= null)
            {
                cameraFollow.target = SwapGameObject;
                SwapGameObject.AddComponent<PlayerMovementForItems>();
                // SwapGameObject.AddComponent<SwapBack>();
                RadialUI.transform.SetParent(SwapGameObject.transform);
                gameObject.SetActive(false);
                // SwapBack.StartCount = true;
                radialIndicatorClick.startCount = true;
                SwapGameObject = null;
            }

            if(Dialogue != null && canTalk == true)
            {
                Dialogue.SetActive(true);
            }
        }
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
    }

}
