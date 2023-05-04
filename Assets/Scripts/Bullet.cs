using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    protected float Damage;
    public float damage => Damage;
    void Start()
    {
        Player player = FindObjectOfType<Player>();
        Damage = player.Damage;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject,2f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            
        }
    }
}
