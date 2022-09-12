using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaildDialogueTest : MonoBehaviour
{

    [SerializeField] GameObject failedDialogue; 
    // Start is called before the first frame update
    void Start()
    {
        failedDialogue.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
