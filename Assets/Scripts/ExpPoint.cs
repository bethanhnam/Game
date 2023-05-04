using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpPoint : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] protected float Exp;
    public AudioClip PickUpAudio;
    public float exp => Exp;
    
    void Start()
    {
        Enemy enemy = FindObjectOfType<Enemy>();
        Exp = enemy.Exp;
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
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(PickUpAudio);
        }
    }
}
