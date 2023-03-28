using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] private TMP_Text timerTxt;
    [SerializeField] private TMP_Text playerLivesTxt;

    private GameManager _gm;
    // Start is called before the first frame update
    void Start()
    {
        _gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        playerLivesTxt.text = _gm.GetLives().ToString();
        timerTxt.text = _gm.GetTimer().ToString("F2");
    }
}
