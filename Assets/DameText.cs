using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DameText : MonoBehaviour
{
    [Header("DameText")]
    public float timeToLive = 0.5f;
    public float floatSpeed = 500;
    public Vector3 floatDirection = new Vector3(0, 1, 0);
    public TextMeshProUGUI textMesh;
    RectTransform rectTransform;
    float timeElapsed = 0.0f;
    Color startingColor;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        startingColor = textMesh.color;
        rectTransform = GetComponent<RectTransform>();
        player = FindObjectOfType<Player>();
        textMesh.text = player.Damage.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        rectTransform.position += floatDirection * floatSpeed * Time.deltaTime;
        textMesh.color = new Color(startingColor.r, startingColor.g, startingColor.b, 1 - (timeElapsed / timeToLive));
        if (timeElapsed > timeToLive)
        {
            Destroy(gameObject);
        }
    }
}
