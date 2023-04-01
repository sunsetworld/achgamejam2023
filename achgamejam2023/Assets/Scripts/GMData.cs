using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "GameData", menuName = "Persistance Data")]
public class GMData : ScriptableObject
{
    [SerializeField] public float defaultSpeed = 1;
    [SerializeField] public int defaultLives = 5;
    
    [HideInInspector] public float speedMultiplier;
    [HideInInspector] public int playerLives;

    private void OnEnable()
    {
        speedMultiplier = defaultSpeed;
        playerLives = defaultLives;
    }
}
