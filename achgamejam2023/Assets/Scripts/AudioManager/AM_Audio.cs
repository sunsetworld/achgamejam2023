using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class AM_Audio : MonoBehaviour
{
    [SerializeField] private AudioClip minigame1Audio;
    [SerializeField] private AudioClip minigame2Audio;

    private AudioSource _audioSource;

    private GameManager _gameManager;

    
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        
        _gameManager = FindObjectOfType<GameManager>();
        
        int level01 = SceneManager.GetSceneByName("minigame01").buildIndex;
        int level02 = SceneManager.GetSceneByName("minigame02").buildIndex;
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        
        if (currentLevelIndex == level01)
        {
            _audioSource.clip = minigame1Audio;
        }
        else if (currentLevelIndex == level02)
        {
            _audioSource.clip = minigame2Audio;
        }

        _audioSource.pitch = _gameManager.GetSpeedMultiplier();
        
        _audioSource.Play();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
