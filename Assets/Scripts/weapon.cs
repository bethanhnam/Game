using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public GameObject bullet;
    public float FireRate = 0.2f;
    private float firerate;
    public float bulletForce;
    [Header("Effect")]
    public GameObject muzzle;
    public SpriteRenderer spriteRenderer;
    public Color flashColor = Color.red; // màu sáng tạm thời
    private Color originalColor;
    [Header("Audio")]
    public AudioClip shootAudio;
    public AudioSource shootAudioSoure;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        shootAudioSoure = GetComponent<AudioSource>();
        originalColor = spriteRenderer.color; // lưu màu ban đầu của game object
    }

    // Update is called once per frame
    void Update()
    {
        firerate -= Time.deltaTime;
        if (firerate <= 0)
        {
            Fire();
        }
    }

    void Fire()
    {
        firerate = FireRate;

        // tính toán hướng từ vị trí spawn đạn đến vị trí chuột
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -Camera.main.transform.position.z;
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector3 direction = (worldMousePos - transform.position).normalized;

        // tạo đối tượng đạn
        GameObject bulletSP = Instantiate(bullet, transform.position, Quaternion.identity);
        // xoay đối tượng đạn theo hướng tính toán được
        bulletSP.transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);

        // tạo hiệu ứng
        //Instantiate(muzzle, firePos.position, transform.rotation, transform);

        // áp dụng lực cho đạn
        Rigidbody2D rb = bulletSP.GetComponent<Rigidbody2D>();
        rb.AddForce(direction * bulletForce, ForceMode2D.Impulse);

        // phát âm thanh
        shootAudioSoure.PlayOneShot(shootAudio);
        // thay đổi màu tạm thời của game object sang màu flashColor
        StartCoroutine(FlashColor());
    }
    IEnumerator FlashColor()
    {
        spriteRenderer.color = flashColor;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = originalColor;
    }
}
