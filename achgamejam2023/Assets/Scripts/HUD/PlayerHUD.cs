using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] private TMP_Text timerTxt;
    [SerializeField] private TMP_Text playerLivesTxt;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        playerLivesTxt.text = GameManager.Instance.GetLives().ToString();
        timerTxt.text = GameManager.Instance.GetTimer().ToString("F2");
    }
}
