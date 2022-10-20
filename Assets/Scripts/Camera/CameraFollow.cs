using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] float FollowSpeed = 2f; 
    [SerializeField] float yOffset= 1f; 
    [SerializeField] float zoffset = -10f; 
    public GameObject target; 

#if UNITY_EDITOR

    /// <summary>
    /// Called when the script is loaded or a value is changed in the
    /// inspector (Called in the editor only).
    /// </summary>
    private void OnValidate()
    {
       Vector3 newPos = new Vector3(target.transform.position.x, target.transform.position.y+ yOffset, zoffset);
       transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed*Time.deltaTime) ;
        
    }

#endif
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       Vector3 newPos = new Vector3(target.transform.position.x, target.transform.position.y+ yOffset, zoffset);
       transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed*Time.deltaTime) ;
    }
}
