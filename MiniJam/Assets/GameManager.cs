using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static bool gamePaused = false;
    public GameObject Ui;
 



    public TMP_Text play;
      private void Start()
    {
        if (Time.time == 0f)
        {
            Ui.SetActive(true);
            Time.timeScale = 0f;
            gamePaused = true;
            play.text = "Play";




        }


    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
            {
                Resume();
        
              
            }
            else
            {
                Pause();
             
            }


     
        }


    }
    public void Pause()
    {
        Ui.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
        play.text = "Resume";

      
      
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quiting Game");
    }
    public void Resume()
    {
        Ui.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
       



    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       
        Time.timeScale = 1f;
    }
}
