using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    public int score;
    public int enemiesDestroyed;
    public bool win;
    private float timeLevel1;
    private float timeLevel2;
    private int enemyPoints;
    private Scene level;
    
    // Start is called before the first frame update
    void Start()
    {
        level= SceneManager.GetActiveScene();
        timeLevel1 = 60f;
        timeLevel2 = 130f;
        enemyPoints = 100;
        AudioManager.Get().PlaySound("InGameSong");
        EnemyFSM.enemyDeath += AddScore;
        EnemyFSM.enemyDeath += EnemyDestroyed;
        Ship.playerDeath += OnPlayerDead;
    }
    private void Update()
    {
        if (level.name == "Level1") 
        {
            timeLevel1 -= Time.deltaTime;
            if (timeLevel1<=0)
            {
                PlayerWin();
            }
        }

        if (level.name == "Level2")
        {
            timeLevel2 -= Time.deltaTime;
            if (timeLevel2 <= 0)
            {
                PlayerWin();
            }
        }
    }

    void AddScore()
    {
        score += enemyPoints;
    }

    void EnemyDestroyed()
    {
        enemiesDestroyed++;
    }

    void OnPlayerDead()
    {
        SceneManager.LoadScene("FinalScene");
        win = false;
    }

    void PlayerWin()
    {
        SceneManager.LoadScene("FinalScene");
        win = true;
    }
}
