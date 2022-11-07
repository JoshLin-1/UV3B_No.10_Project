using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControl : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Light; 
    private GameObject enemy; 
    bool candestory; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Z))
        {
            Light.GetComponent<Light>().intensity = 20; 
            if(candestory == true)
            {
                enemy.SetActive(false);
            }
           
        }

        if( Light.GetComponent<Light>().intensity >0)
            {
                Light.GetComponent<Light>().intensity --; 
            }
    }

     private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            enemy = other.gameObject; 
          candestory = true; 
        }
    }
}
