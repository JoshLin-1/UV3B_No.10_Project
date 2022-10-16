using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTestScript : MonoBehaviour
{
    [SerializeField] PlayerController _input; 
    public GameObject TextBlinkUI; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            _input.EnableGameplayInput();
            TextBlinkUI.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerMovemnetController>())
        {
            other.GetComponent<PlayerMovemnetController>().direction = Vector3.zero;
            _input.DisablePlayerInputs();

            TextBlinkUI.SetActive(true);
        }
        

    }
}