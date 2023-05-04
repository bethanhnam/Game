using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update() { 
       
    }
    public void GoMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        

    }
    public void PlayGame()
    {
        
        SceneManager.LoadScene(1);
    }
    public void StopGame()
    {
        Application.Quit();
    }
}
