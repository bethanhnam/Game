using System.Collections;
using UnityEditor;
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
    public float SpawnTime = 4f;
    [Header("Update status")]
    public float updateSpeed = 1;
    public float updateDamage = 5;
    public float updateHealth = 10;
    public bool isBoss;
    [Header("Audio")]
    public AudioSource BackGroundAudioSource;

    [Header("object")]
    Player Player;
    public GameObject Winpop;
    public GameObject PauseMenu;
    public GameObject Dialog;
    showKey showKey;
    public bool pauseon = false;

    GameManager gameManager;
    void Start()
    {
        Time.timeScale = 1;
        StartCoroutine(createEnemy());
        BackGroundAudioSource = GetComponent<AudioSource>();
        BackGroundAudioSource.Play();
        Player = FindObjectOfType<Player>();
        showKey = FindObjectOfType<showKey>();

    }

    // Update is called once per frame
    void Update()
    {
        SpawnTime = Player.spawnTime;
        CreateBoss();
        if (Input.GetKeyDown(KeyCode.Q) && pauseon == false)
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0;
            pauseon = true;

        }
        if (Input.GetKeyDown(KeyCode.Q) && pauseon == true)
        {
            PauseMenu.SetActive(false);
            Time.timeScale = 1;
            pauseon = false;
        }
        player.transform.position = new Vector3(Mathf.Clamp(player.transform.position.x, -60, 68f), Mathf.Clamp(player.transform.position.y, -29f, 26f), transform.position.z);
        if (Input.GetKeyDown(KeyCode.E) && showKey.ShowDialog == true)
        {
            Dialog.SetActive(true);
            Time.timeScale = 0;
        }

    }
    public void CreateBoss()
    {

        if (Player.level == 10)
        {

            if (NumberOfBoss < 1)
            {
                GameObject newBoss = Instantiate(Boss, new Vector3(0, 0, 1), Quaternion.identity);
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
    public void CloseDialog()
    {
        // Hàm này sẽ hiển thị panel Win game
        Dialog.SetActive(false);
        Time.timeScale = 1;
    }
    public void HidePauseMenu()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void ShowPauseMenu()
    {

        PauseMenu.SetActive(true);
        Time.timeScale = 0;

    }
    IEnumerator createEnemy()
    {
        while (true)
        {
            Vector3 randomPosition = new Vector3(Random.Range(player.transform.position.x - 35, player.transform.position.x + 35), Random.Range(player.transform.position.y - 35, player.transform.position.y + 35), 0);
            Instantiate(enemy, randomPosition, Quaternion.identity);
            yield return new WaitForSeconds(SpawnTime);
        }
    }

}
