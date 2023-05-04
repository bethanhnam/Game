using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
[CreateAssetMenu(fileName = "Update", menuName = "Selection/BaseUpdate", order = 1)]

public class BaseUpdate : ScriptableObject
{
    // Start is called before the first frame update
    public string UpdateName;
    public string UpdateText;
    public float Data;
    public Sprite UpdateSprite;
    public int UpdateType;
    public Sprite sprite => UpdateSprite;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
