using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D Rigidbody2D;
    private Transform player;
    private Vector3 directionToPlayer;
    private Vector3 localScale;
    private Enemy enemy;
    public float _rotationSpeed;
    PlayerAwareness _playerAwareness;
    public float distanceToPlayer;
    private Vector2 targetDirection;
    [SerializeField] private float playerAwarenessDistance;
    [SerializeField] private float _maxApproachDistance = 15;

    //enemy shoot
    [SerializeField] private float _shootInterval;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _shootPoint;
    private float _lastShootTime;
   




    // Start is called before the first frame update
    private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        enemy = GetComponent<Enemy>();
       
        player = FindObjectOfType<Player>().transform;
        _playerAwareness = GetComponent<PlayerAwareness>();
        playerAwarenessDistance = _playerAwareness._playerAwarenessDistance;
        localScale = transform.localScale;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    void Start()
    {


    }


    // Update is called once per frame
    void Update()
    {
        if (Rigidbody2D.velocity.x > 0)
        {
            transform.localScale = new Vector3(localScale.x, localScale.y, 5);
        }
        else if (Rigidbody2D.velocity.x < 0)
        {
            transform.localScale = new Vector3(-localScale.x, localScale.y, 5);
        }
        spriteRenderer.sprite = enemy.EnemySprite;
        directionToPlayer = (player.transform.position - transform.position).normalized;
        distanceToPlayer = (player.transform.position - transform.position).x;
        //Nếu kẻ địch có khả năng bắn
        if (enemy.ShootingEnemy == true)
        {
            // Nếu khoảng cách tới người chơi lớn hơn _maxApproachDistance, kẻ thù sẽ tiếp cận người chơi
            if (distanceToPlayer > _maxApproachDistance)
            {
                Move();
            }
            // Ngược lại, nếu khoảng cách nhỏ hơn hoặc bằng _maxApproachDistance, kẻ thù sẽ dừng lại
            else if (distanceToPlayer <= _maxApproachDistance)
            {
                Rigidbody2D.velocity = Vector2.zero;
            }

            // Nếu người chơi không null và khoảng cách tới người chơi nhỏ hơn hoặc bằng _playerAwarenessDistance
            if (player != null && distanceToPlayer <= playerAwarenessDistance)
            {
                // Nếu đủ thời gian đã trôi qua kể từ lần bắn cuối cùng, kẻ địch sẽ bắn
                if (Time.time - _lastShootTime >= _shootInterval)
                {
                    Fire();
                    _lastShootTime = Time.time;
                }
            }
        }
        // Nếu kẻ địch không có khả năng bắn
        else
        {
            Move();

        }

    }
    private void Move()
    {
        Rigidbody2D.velocity = new Vector2(directionToPlayer.x, directionToPlayer.y) * enemy.Speed;
       
    }

    void Fire()
    {
        GameObject bulletSP = Instantiate(_bulletPrefab, _shootPoint.position, Quaternion.identity);

        //định hướng bắn 
        Vector2 direction = (player.position - _shootPoint.position).normalized;
        bulletSP.GetComponent<Rigidbody2D>().velocity = direction * 10f;
    }
}

