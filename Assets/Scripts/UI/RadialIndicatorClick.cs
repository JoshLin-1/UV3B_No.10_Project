using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 
using UnityEngine.UI; 


public class RadialIndicatorClick : MonoBehaviour
{
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

    [Header("Unity Event")]
    [SerializeField] private UnityEvent myEvent = null;

    [Header("UI")]
    public GameObject RadialUI; 

    private PlayerInputScheme _inputScheme; 

    private bool shouldUpdate = false; 
    public bool startCount = false;

     private void Awake()
    {
        OriginalObject = GameObject.Find("Cube");
        Camera = GameObject.Find("Main Camera");
        RadialUI = GameObject.Find("Radial");
        cameraFollow = Camera.GetComponent<CameraFollow>();
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
        if(_inputScheme.Player.Interact.triggered)
        {
            startCount = false;
            Swap();
        }

        if(startCount == true)
        {
            indicatorTimer -= Time.deltaTime; 
            radialIndicatorUI.enabled = true; 
            radialIndicatorUI.fillAmount = indicatorTimer/maxIndicatorTimer; 

            if(indicatorTimer <= 0)
            {
                indicatorTimer = maxIndicatorTimer; 
                radialIndicatorUI.fillAmount = maxIndicatorTimer; 
                radialIndicatorUI.enabled = false; 
                myEvent.Invoke();
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
        RadialUI.transform.SetParent(OriginalObject.transform);
        cameraFollow.target = OriginalObject;
        Destroy(GetComponent<PlayerMovementForItems>());
        Destroy(GetComponent<SwapBack>());
        
    }
}
