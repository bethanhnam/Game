using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy/BaseEnemy", order = 1)]
public class BaseEnemy : ScriptableObject
{
    // Start is called before the first frame update
    public Sprite EnemySprite;
    public string EnemyName;
    public float Health;
    public float Damage;
    public float Speed;
    public bool ShootingEnemy;
    public bool Boss;
    public float exp;

    public Sprite sprite => EnemySprite;



}
