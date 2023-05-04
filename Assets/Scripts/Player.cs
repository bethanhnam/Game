using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.EventSystems.EventTrigger;

public class Player : MonoBehaviour
{
    [Header("status nhân vật")]
    public float moveSpeed = 5f; // tốc độ di chuyển của nhân vật
    public float Damage = 30;
    private Animator animator;
    private Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    [SerializeField] public float PlayerHealth = 100;
    [SerializeField] public float PlayerEXP = 0;
    [SerializeField] public float maxEXP = 100;
    [SerializeField] public int level ;
    [SerializeField] public float TotalEXP;
    Vector2 movement;

    [SerializeField] private bool isCollidingWithEnemy = false;
    float collidingTime = 0;

    [Header("Bar")]
    public HealthBar healthBar;
    public ExpBar EXPBar;
    public TMP_Text Level;

    [Header("UpgradePanel")]
    public GameObject UpgradePanel;
    public GameManager gameManager;

    [Header("LosePop")]
    public GameObject LosePop;

    [Header("Audio")]
    public AudioClip PlayerAudioLevelUp;
    public AudioClip GameOver;
    public AudioSource PlayerAudioSource;
    public bool OnSound = false;

    [Header("heso")]
    public float spawnTime = 4;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PlayerAudioSource = GetComponent<AudioSource>();
        gameManager = FindObjectOfType<GameManager>();
        healthBar = FindObjectOfType<HealthBar>();
        EXPBar = FindObjectOfType<ExpBar>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

        Level.text = level.ToString();
        healthBar.UpdateBar(PlayerHealth, 100);
        if (PlayerHealth > 0)
        {
            EXPBar.UpdateBar(PlayerEXP, maxEXP);
        }
        if (PlayerEXP > maxEXP)
        {
            TotalEXP += maxEXP;
            level++;
            PlayerAudioSource.PlayOneShot(PlayerAudioLevelUp);
            PlayerEXP -= maxEXP;
            UpgradePanel.SetActive(true);
            Time.timeScale = 0;
            spawnTime -= 0.1f;
            maxEXP += maxEXP / 5;
        }
        else if (PlayerEXP < maxEXP && PlayerHealth <= 0)
        {
            TotalEXP += PlayerEXP;
        }
        if (PlayerHealth <= 0)
        {
            PlayerEXP = 0;
            if (OnSound == false)
            {
                PlayerAudioSource.PlayOneShot(GameOver);
                OnSound = true;
            }


            //back to Game Menu
            LosePop.SetActive(true);
            Time.timeScale = 0;

        }



    }
    private void FixedUpdate()
    {
        // Xử lý di chuyển nhân vật
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                StartCoroutine(dame(enemy));
                //Debug.Log(PlayerHealth);
                isCollidingWithEnemy = true;
              
            }
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (isCollidingWithEnemy)
            {
                collidingTime = collidingTime + Time.deltaTime;
                if (collidingTime >= 3)
                {
                    Enemy enemy = collision.gameObject.GetComponent<Enemy>();
                    if (enemy != null)
                    {
                        StartCoroutine(dame(enemy));
                        collidingTime = 0;
                    }
                }
            }
        }
    }

    IEnumerator dame(Enemy enemy)
    {
        PlayerHealth -= enemy.Damage;
        yield return null;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            isCollidingWithEnemy = false;
            Debug.Log(PlayerHealth);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            EnemyBullet enemyBullet = collision.gameObject.GetComponent<EnemyBullet>();
            PlayerHealth -= enemyBullet.damage;
           
        }
        if (collision.gameObject.CompareTag("EXP"))
        {
            ExpPoint expPoint = collision.gameObject.GetComponent<ExpPoint>();
            PlayerEXP += expPoint.exp;
            //Debug.Log(PlayerHealth);
        }
    }
    public void UpdateSpeed(int data)
    {
        moveSpeed += data;
    }
    public void UpdateDamage(int data)
    {
        Damage += data;
    }
    public void UpdateHealth(int data)
    {
        PlayerHealth += data;
    }
}
