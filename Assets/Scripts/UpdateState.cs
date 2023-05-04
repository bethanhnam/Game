using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class UpdateState : MonoBehaviour
{
    [Header("dữ liệu từ Enemy")]
    public string UpdateName;
    public string UpdateText;
    public float Data;
    public Sprite UpdateSprite;
    public int upgradeType;

    public BaseUpdate[] baseUpdates = new BaseUpdate[5];
    public int CurrentUpdate;

    
    public Image image;
    public TMP_Text text;
    private Player character;
    public ChangeStatus changeStatus;

    public void Init()
    {
        CurrentUpdate = Random.Range(0, baseUpdates.Length);
        UpdateName = baseUpdates[CurrentUpdate].UpdateName;
        UpdateText = baseUpdates[CurrentUpdate].UpdateText;
        Data = baseUpdates[CurrentUpdate].Data;
        upgradeType = baseUpdates[CurrentUpdate].UpdateType;
        UpdateSprite = baseUpdates[CurrentUpdate].UpdateSprite;
    }
    private void Awake()
    {
        character = FindObjectOfType<Player>();

    }
    public void OnButtonClick()
    {
        // Tìm đối tượng Player và nâng cấp tùy thuộc vào giá trị của biến upgradeType

        if (character != null)
        {
            if (upgradeType == 1)
            {
                character.UpdateDamage(5);
                Debug.Log("Tăng 5 điểm sát thương!");
            }
            else if (upgradeType == 3)
            {
                character.UpdateHealth(10);
                Debug.Log("Tăng 10 điểm máu!");
            }
            else if (upgradeType == 2)
            {
                character.UpdateSpeed(1);
                Debug.Log("Tăng 1 điểm tốc độ!");
            }
            else
            {
                Debug.LogError(upgradeType + " Cách chỉ số không hợp lệ!");
            }
            changeStatus.changeData = true;
        }
        else
        {
            Debug.LogError("Không thể tìm thấy nhân vật!");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Init();
        LoadData();
    }

    public void LoadData()
    {
        if (baseUpdates == null || baseUpdates.Length == 0)
        {
            Debug.LogError("baseUpdates is null or empty!");
            return;
        }

        if (image != null)
        {
            image.sprite = UpdateSprite;
        }
        else
        {
            Debug.LogError("image is null!");
        }

        if (text != null)
        {
            text.text = UpdateName;
        }
        else
        {
            Debug.LogError("text is null!");
        }
    }
}
