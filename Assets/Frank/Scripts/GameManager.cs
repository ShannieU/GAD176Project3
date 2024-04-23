using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager current;

    private int enemiesKilled;

    void Start()
    {
        current = this;

        // show beginning ui
        // when play pressed start game
        // set initial stage
        // spawn enemies in stage
        // when all enemies dead in stage
        // move to next stage
        // repeat
        // once all stages complete win

        // every 20 enemies player gets new weapon

        // if player health reaches 0
        // lose
        // turn ui off and reset game
    }

    void Update()
    {
        
    }

    // show beginning ui
    void DisplayInitialUI()
    {

    }

    // when play pressed start game
    void StartGame()
    {
        EventManager.current.GameBegin();
    }

    // set initial stage
    void NextStage()
    {

    }

    // spawn enemies in stage
    void SpawnStageEnemies()
    {

    }

    // when all enemies dead in stage
    // move to next stage

    // repeat

    // if all stages complete win
    void Win()
    {

    }

    // every 20 enemies player gets new weapon
    void EnemyKilled()
    {

    }

    void NewWeapon()
    {

    }

    // if player health reaches 0
    // lose
    void Lose()
    {

    }

    // turn ui off and reset game
    void ResetGame()
    {

    }
}