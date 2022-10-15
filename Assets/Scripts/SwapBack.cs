using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.Events; 

public class SwapBack : MonoBehaviour
{
    
    [SerializeField] private float CountTime = 5.0f; 
    private float timeRemaining; 
    public bool StartCount = true; 
    public GameObject OriginalObject; 
    public GameObject Camera; 
    public CameraFollow cameraFollow; 

   


    // Start is called before the first frame update
    private void Awake()
    {
        OriginalObject = GameObject.Find("Cube");
        Camera = GameObject.Find("Main Camera");
        cameraFollow = Camera.GetComponent<CameraFollow>();
    }
    void Start()
    {
        timeRemaining = CountTime;
        
    }

    // Update is called once per frame
    void Update()
    {
        CountDown();
    }

    private void CountDown()
    {
        if(StartCount == true)
        {
            if(timeRemaining>0)
            {
                timeRemaining -= Time.deltaTime; 
                Debug.Log(timeRemaining);
            }

            else
            {
                StartCount = false;
                Swap();
            }
        }
    }

    private void Swap()
    {
        OriginalObject.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        OriginalObject.SetActive(true);
        cameraFollow.target = OriginalObject;
        Destroy(GetComponent<PlayerMovementForItems>());
        Destroy(GetComponent<SwapBack>());
    }
}
