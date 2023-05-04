using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LosePop : MonoBehaviour
{
    public GameObject losePop;
    public TMP_Text Score;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Score.text = player.TotalEXP.ToString();
    }
    public void GoMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;


    }
    public void PlayGame()
    {

        SceneManager.LoadScene(1);
        losePop.SetActive(false);
    }
}
