using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class gameend : MonoBehaviour
{
    [SerializeField] private String firstLevelName;
    [SerializeField] private GMData gmData;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenFirstLevel()
    {
        gmData.speedMultiplier = gmData.defaultSpeed;
        gmData.playerLives = gmData.defaultLives;
        SceneManager.LoadScene(firstLevelName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
}
