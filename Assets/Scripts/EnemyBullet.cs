using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]protected float Damage;
    public float damage => Damage;
    void Start()
    {
        Enemy enemy = FindObjectOfType<Enemy>();
        Damage = enemy.Damage;
    }

    void Update()
    {
        Destroy(gameObject, 2f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
