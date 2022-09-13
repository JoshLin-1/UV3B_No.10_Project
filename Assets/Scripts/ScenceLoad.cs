using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScenceLoad : MonoBehaviour
{
    [SerializeField] float time = 10; 
    bool starttoquit = false; 
    bool loadscence = false; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(loadscence ==true)
        {
            time--;
            if(time<=0)
            {
                LoadScene();
            }
        }
        if(starttoquit ==true)
        {
            time--;
            if(time<=0)
            {
                Quit();
            }
        }
        
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void LoadScene()
    {
        
        DontDestroyOnLoad(GameObject.Find("NextSceneInfo"));
        // SceneManager.LoadScene("SampleScene");
        SceneManager.LoadScene("LoadingScence");
    }
    public void starttoload()
    {
        loadscence = true;
    }

    public void startingtoquit()
    {
        starttoquit = true;
    }
}
