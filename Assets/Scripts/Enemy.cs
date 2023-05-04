using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public event System.Action OnBossDefeated;
    public BaseEnemy[] enemy;

    [Header("enemy Status")]
    public Sprite EnemySprite;
    public string EnemyName;
    public float Health;
    public float Damage;
    public float Speed;
    public bool ShootingEnemy;
    public bool Boss;
    public float Exp;
    public AudioSource EnemyAudioSource;
    public AudioClip EnemyAudioClip;
    public int currentEnemy;
    SpriteRenderer spriteRenderer;

    [Header("exp")]
    public GameObject expPoint;
    private bool hasCreatedExpPoint = false;
    [Header("DameText")]
    public GameObject DameText;
    
    // Start is called before the first frame update
    private void Awake()
    {
        
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        currentEnemy = Random.Range(0, enemy.Length);
        Init(enemy[currentEnemy]);
        EnemyAudioSource = GetComponent<AudioSource>();
        
    }
    void CreateBoss()
    {
        currentEnemy = enemy.Length;
        Init(enemy[currentEnemy]);
        EnemyAudioSource = GetComponent<AudioSource>();
    }

    public void Init(BaseEnemy data)
    {
        Exp = data.exp;
        EnemySprite = data.EnemySprite;
        EnemyName = data.EnemyName;
        Health = data.Health;
        Damage = data.Damage;
        Speed = data.Speed;
        ShootingEnemy = data.ShootingEnemy;
        Boss = data.Boss;

    }

    // Update is called once per frame
    void Update()
    {
        if (this.Health <= 0)
        {
            Destroy(gameObject, 0.2f);
            if (hasCreatedExpPoint == false)
            {
                Instantiate(expPoint, transform.position, Quaternion.identity);
                hasCreatedExpPoint = true;
                if (this.Boss)
                {
                    GameManager gameManager = FindObjectOfType<GameManager>();
                    gameManager.isBoss = true;
                    if (this.Boss)
                    {
                        // Gọi sự kiện OnBossDefeated
                        if (OnBossDefeated != null)
                        {
                            OnBossDefeated();
                        }
                    }
                }
            }
            

        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            this.Health -= bullet.damage;
            EnemyAudioSource.PlayOneShot(EnemyAudioClip);
            RectTransform textTransform = Instantiate(DameText).GetComponent<RectTransform>();
            textTransform.transform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position);

            Canvas canvas = GameObject.FindObjectOfType<Canvas>();
            textTransform.SetParent(canvas.transform);
        }
    }
}
