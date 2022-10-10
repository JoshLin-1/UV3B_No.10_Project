using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 
using UnityEngine.UI; 


public class RadialIndicatorClick : MonoBehaviour
{
    [Header("Track Object")]
    public GameObject TrackObject; 
    [Header ("Radial Timers")]
    [SerializeField] private float indicatorTimer = 1.0f; 
    [SerializeField] private float maxIndicatorTimer = 1.0f; 

    [Header("UI Indicator")]
    [SerializeField]private Image radialIndicatorUI = null; 

    // [Header("Key Codes")]
    // [SerializeField] private KeyCode selectKey = KeyCode.Mouse0; 
    [Header("Camera")]
    public GameObject Camera; 
    public CameraFollow cameraFollow;

    [Header("PlayerObject")]
    public GameObject OriginalObject; 
    [SerializeField] public GameObject possessObject; 

    [Header("Unity Event")]
    [SerializeField] private UnityEvent myEvent = null;

    [Header("UI")]
    public GameObject RadialUI; 

    private PlayerInputScheme _inputScheme; 

    public bool canInteract = false; 
    private bool shouldUpdate = false; 
    public bool startCount = false;

    #if UNITY_EDITOR

   /// <summary>
   /// Called when the script is loaded or a value is changed in the
   /// inspector (Called in the editor only).
   /// </summary>
    private void OnValidate()
    {
        OriginalObject = GameObject.Find("Cube");
        Camera = GameObject.Find("Main Camera");
        RadialUI = GameObject.Find("RadialUI");
    }

   #endif

     private void Awake()
    {
        cameraFollow = Camera.GetComponent<CameraFollow>();
        _inputScheme = new PlayerInputScheme();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(TrackObject.transform.position.x, TrackObject.transform.position.y+1.5f, 0);
        if(indicatorTimer == maxIndicatorTimer)
        {
            canInteract = true; 
        }
        else
        {
            canInteract = false; 
        }


        if(_inputScheme.Player.Interact.triggered)
        {
            startCount = false;
            _inputScheme.Disable();
            Swap();
        }

        if(startCount == true)
        {
            _inputScheme.Enable();
            indicatorTimer -= Time.deltaTime; 
            radialIndicatorUI.enabled = true; 
            radialIndicatorUI.fillAmount = indicatorTimer/maxIndicatorTimer; 

            if(indicatorTimer <= 0)
            {
                indicatorTimer = maxIndicatorTimer; 
                radialIndicatorUI.fillAmount = maxIndicatorTimer; 
                radialIndicatorUI.enabled = false; 
                myEvent.Invoke();
                Time.timeScale = 0;
                RadialUI.SetActive(false);
            }
        }
        else
        {
            if(shouldUpdate)
            {
                indicatorTimer += Time.deltaTime; 
                radialIndicatorUI.fillAmount = indicatorTimer/maxIndicatorTimer; 
                if(indicatorTimer >= maxIndicatorTimer)
                {
                    indicatorTimer = maxIndicatorTimer; 
                    radialIndicatorUI.fillAmount = maxIndicatorTimer; 
                    radialIndicatorUI.enabled = false; 
                    shouldUpdate = false; 
                }
            }
        }

        if(startCount == false)
        {
            shouldUpdate = true; 
        }

    }

     private void Swap()
    {

        OriginalObject.SetActive(true);
        OriginalObject.transform.position = new Vector3(cameraFollow.transform.position.x, cameraFollow.transform.position.y, 0);
        Destroy(GetComponentInParent<PlayerMovementForItems>());
        Destroy(possessObject.GetComponentInParent<PlayerMovementForItems>());
        // RadialUI.transform.SetParent(OriginalObject.transform);
        TrackObject = OriginalObject; 
        cameraFollow.target = OriginalObject;
        possessObject = null; 
        // Destroy(GetComponent<PlayerMovementForItems>());
        // Destroy(GetComponent<SwapBack>());
    }
}
