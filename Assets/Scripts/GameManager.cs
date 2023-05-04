using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Create Enemy")]
    public int NumberOfEnemy;
    Vector3 randomPosition;
    public GameObject enemy;
    public GameObject Boss;
    public GameObject player;
   
    int NumberOfBoss = 0;
    [Header("Update status")]
    public float updateSpeed =1;
    public float updateDamage = 5;
    public float updateHealth = 10;
    public bool isBoss;
    [Header("Audio")]
    public AudioSource BackGroundAudioSource;

    [Header("object")]
    Player Player;
    public GameObject Winpop;

    GameManager gameManager;
    void Start()
    {
        Time.timeScale = 1;
        StartCoroutine(createEnemy());
        BackGroundAudioSource = GetComponent<AudioSource>();
        BackGroundAudioSource.Play();
        Player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        CreateBoss();
        // Giới hạn khu vực di chuyển

        player.transform.position = new Vector3(Mathf.Clamp(player.transform.position.x,-60,68f), Mathf.Clamp(player.transform.position.y,-29f,26f), transform.position.z);
    }
    public void CreateBoss()
    {
        
        if(Player.level == 10)
        {
            
            if(NumberOfBoss <1)
            {
                GameObject newBoss=Instantiate(Boss, new Vector3(0, 0, 1), Quaternion.identity);
                NumberOfBoss = 1;
                Enemy bossEnemy = newBoss.GetComponent<Enemy>();
                bossEnemy.OnBossDefeated += ShowWinPanel;
            }
        }
        
    }
    void ShowWinPanel()
    {
        // Hàm này sẽ hiển thị panel Win game
        Winpop.SetActive(true);
        Time.timeScale = 0;
    }
    IEnumerator createEnemy()
    {
        while (true) { 
            Vector3 randomPosition = new Vector3(Random.Range(player.transform.position.x-35, player.transform.position.x + 35), Random.Range(player.transform.position.y-35, player.transform.position.y + 35), 0);
            Instantiate(enemy, randomPosition, Quaternion.identity);
            yield return new WaitForSeconds(5f);
        }
    }

}
