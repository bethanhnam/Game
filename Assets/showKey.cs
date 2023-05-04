using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showKey : MonoBehaviour
{
    public Transform SignPositon;
    [SerializeField] float DistanceToPlayer;
    [SerializeField] Vector3 DistanceFromPlayer;
    Transform player;
    [SerializeField] GameObject ImageButton;
    [SerializeField] public bool ShowDialog = false;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        DistanceFromPlayer = SignPositon.transform.position - player.transform.position;
        DistanceToPlayer = (SignPositon.transform.position - player.transform.position).x;
        if(Mathf.Abs(DistanceFromPlayer.magnitude) < 1f)
        {
            ImageButton.SetActive(true);
            ShowDialog =true;

        }
        else
        {
            ImageButton.SetActive(false);
            ShowDialog = false;
        }
    }
}
