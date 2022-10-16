using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] float FollowSpeed = 2f; 
    [SerializeField] float yOffset= 1f; 
    public GameObject target; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       Vector3 newPos = new Vector3(target.transform.position.x, target.transform.position.y+ yOffset, -10f);
       transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed*Time.deltaTime) ;
    }
}
