using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int playerLives = 5;
    
    [SerializeField] private float speedMultiplier = 1;

    [SerializeField] private float playerTimer = 10.0f;

    private bool _gameOver = false;

    private bool _canModifyLives = true;

    [SerializeField] private bool objectiveComplete = false;
    
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
                Invoke("ResetGame", 1);
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
    }

    public void AddSpeedMultiplier(float multiplierToAdd)
    {
        speedMultiplier += multiplierToAdd;
    }

    public float GetSpeedMultiplier()
    {
        return speedMultiplier;
    }

    public void ResetGame()
    {
        _canModifyLives = true;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
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
            if ((playerLives + livesToModify) <= 0)
            {
                _gameOver = true;
                Debug.Log("Game Over!");
            }

        }


    }

    public void SetLives(int livesToSet)
    {
        playerLives = livesToSet;
    }

    public float GetTimer()
    {
        return playerTimer;
    }

    public void SetObjectiveComplete(bool objToSet)
    {
        objectiveComplete = objToSet;
    }
}
