using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeStatus : MonoBehaviour
{
    public UpdateState[] updateStatesObject;
    public bool changeData = false;
    public GameObject UpgradePanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (changeData)
        {
            UpgradePanel.SetActive(false);
            Time.timeScale = 1;
            foreach (var state in updateStatesObject)
            {

                state.Init();
                state.LoadData();
            }
            changeData = false;
        }
    }
}
