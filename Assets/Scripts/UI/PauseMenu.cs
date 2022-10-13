using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public static bool GameIsPaused = false; 
    public GameObject PausedMenuUI; 

    private  PlayerInputScheme _inputScheme; 
    // Update is called once per frame

    private void Awake()
    {
        _inputScheme = new PlayerInputScheme();
        _inputScheme.Enable();

        //example
        // bool isgamepasuedTrue = PauseMenu.GameIsPaused;
      
    }
    void Update()
    {
        if(_inputScheme.Menu.EscapeMenu.triggered)
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else{
                Paused();
            }
        }
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
