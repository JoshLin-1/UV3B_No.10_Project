using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTestScript : MonoBehaviour
{
    [SerializeField] PlayerController _input; 
    public GameObject TextBlinkUI; 

    public bool OnlyOnce = false; 
    bool TextShow = true; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TextBlinkUI.transform.position = new Vector3(this.transform.position.x, this.transform.position.y+1.5f, 0);

        if(Input.GetKey(KeyCode.Space))
        {
            _input.EnableGameplayInput();
            TextBlinkUI.SetActive(false);
            if(OnlyOnce)
            {
                TextShow = false; 
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerMovemnetController>())
        {
            other.GetComponent<PlayerMovemnetController>().direction = Vector3.zero;
            _input.DisablePlayerInputs();

            if(TextShow)
            {
                TextBlinkUI.SetActive(true);
            }
        }
        

    }
}
