using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAwareness : MonoBehaviour
{
    [SerializeField] public bool AwareOfPlayer { get; private set; }
    [SerializeField] public Vector2 DirectionToPlayer { get; private set; }
    [SerializeField] public float _playerAwarenessDistance;
    Transform _player;
    // Start is called before the first frame update
    void Start()
    {
        _player= FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyToPlayerVector = _player.position - transform.position;
        DirectionToPlayer =  enemyToPlayerVector.normalized;

        // Tính toán góc quay để đối tượng hướng về người chơi
        //float angle = Mathf.Atan2(enemyToPlayerVector.y, enemyToPlayerVector.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(Vector3.forward * angle);

        // Nếu khoảng cách tới người chơi nhỏ hơn hoặc bằng _playerAwarenessDistance, đánh dấu kẻ địch đã nhận thức được người chơi
        if (enemyToPlayerVector.magnitude <= _playerAwarenessDistance)
        {
            AwareOfPlayer = true;
        }
        else
        {
            AwareOfPlayer = false;
        }
    }
}
