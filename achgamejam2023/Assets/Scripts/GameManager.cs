using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] public GMData gmData;

    [SerializeField] private int playerLives = 5;
    
    [SerializeField] private float speedMultiplier = 1;

    [SerializeField] private float playerTimer = 10.0f;

    private bool _gameOver = false;

    private bool _canModifyLives = true;

    [SerializeField] private bool objectiveComplete = false;

    [SerializeField] private string minigame1Scene;
    [SerializeField] private string minigame2Scene;
    [SerializeField] private string gameOverScene;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        speedMultiplier = gmData.speedMultiplier;
        playerLives = gmData.playerLives;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetGame();
        }

        if (playerTimer >= 0 && !_gameOver)
        {
            playerTimer -= speedMultiplier * Time.deltaTime;
        }
        else if (playerTimer <= 0)
        {
            if (objectiveComplete)
            {
                LoadNextScene();
            }
            else
            {
                DestroyPlayer();
            }
        }
    }

    public void DestroyPlayer()
    {
        PlayerMovement player = FindObjectOfType<PlayerMovement>();
        if (player != null)
        {
            Destroy(player.gameObject);
        }
        ModifyLives(-1);
        _canModifyLives = false;
        Invoke("ResetGame", 0.5f);
    }
    

    public void SetSpeedMultiplier(float multiplierToSet)
    {
        speedMultiplier = multiplierToSet;
        GameManager.Instance.speedMultiplier = speedMultiplier;
        gmData.speedMultiplier = multiplierToSet;
    }

    public void AddSpeedMultiplier(float multiplierToAdd)
    {
        speedMultiplier += multiplierToAdd;
        GameManager.Instance.speedMultiplier = speedMultiplier;
        gmData.speedMultiplier = speedMultiplier;
    }

    public float GetSpeedMultiplier()
    {
        return speedMultiplier;
    }

    public void ResetGame()
    {
        _canModifyLives = true;
        LoadNextScene();
    }

    public int GetLives()
    {
        return playerLives;
    }

    public void ModifyLives(int livesToModify)
    {
        if (_canModifyLives)
        {
            playerLives += livesToModify;
            gmData.playerLives = playerLives;
            if (playerLives <= 0)
            {
                _gameOver = true;
                Debug.Log("Game Over!");
                SceneManager.LoadScene(gameOverScene);
            }

        }


    }

    public void SetLives(int livesToSet)
    {
        playerLives = livesToSet;
        gmData.playerLives = livesToSet;
    }

    public float GetTimer()
    {
        return playerTimer;
    }

    public void SetObjectiveComplete(bool objToSet)
    {
        objectiveComplete = objToSet;
    }

    void LoadNextScene()
    {
        String currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == minigame1Scene)
        {
            SceneManager.LoadScene(minigame2Scene);
        }
        else if (currentScene == minigame2Scene)
        {
            AddSpeedMultiplier(0.2f);
            SceneManager.LoadScene(minigame1Scene);
        }
    }
}

// https://awesometuts.com/blog/singletons-unity/

