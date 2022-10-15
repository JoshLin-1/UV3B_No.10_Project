using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] PlayerController _input; 

    public static bool GameIsPaused = false; 
    public GameObject PausedMenuUI; 

    
    // Update is called once per frame

    private void Awake()
    {
       

        //example
        // bool isgamepasuedTrue = PauseMenu.GameIsPaused;
      
    }

    void OnEnable()
    {
        _input.onEscapeMenu+= escapeMenu; 
        _input.onStopEscapeMenu+= stopEscapeMenu; 
    }

    void DisEnable()
    {
        _input.onEscapeMenu-= escapeMenu; 
        _input.onStopEscapeMenu-= stopEscapeMenu; 
    }

    void escapeMenu()
    {
        if(GameIsPaused)
        {
            Resume();
        }
        else{
            Paused();
        }
    }

    void stopEscapeMenu()
    {

    }

    public void Resume()
    {
        PausedMenuUI.SetActive(false);
        Time.timeScale = 1f; 
        GameIsPaused = false;
    }

    void Paused()
    {
        PausedMenuUI.SetActive(true);
        Time.timeScale = 0f; 
        GameIsPaused = true; 
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("StartUI");
        Time.timeScale = 1f; 
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
