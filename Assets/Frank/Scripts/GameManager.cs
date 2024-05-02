using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VInspector;

public class GameManager : MonoBehaviour
{
    public static GameManager current;

    private int enemiesKilled = 0;

    [SerializeField] bool debugMessages;

    // TODO List (* = Complete, + = Complete but somone else has to hook into the event is fired, - = Complete but somone needs to send the event this relies on)

    // show beginning ui *
    // when play pressed start game and set ui *
    // set initial stage +
    // spawn enemies in stage +
    // when all enemies dead in stage move to next stage -
    // repeat
    // once all stages complete win -
    // if player health reaches 0s lose and set ui -
    // when restart button is pressed reset game *

    // NOTE - Inspector Buttons and debug messages have been added to test and show that the stuff that relies on other systems is working properly


    void Start()
    {
        current = this;

        EventManager.current.onGameStart += StartGame;
        EventManager.current.onWin += Win;
        EventManager.current.onLose += Lose;
        EventManager.current.onEnemyKilled += EnemyKilled;
    }

    public void StartGame() // Told By Start Button
    {
        DebugMessage("GameManager - StartGame");

        enemiesKilled = 0;

        EventManager.current.UpdateEnemyKilledUI(enemiesKilled);
        EventManager.current.UpdateHealthUI(100);
        EventManager.current.ChangeWeapon("Pistol");
        EventManager.current.UpdateMaxAmmo(24);
        EventManager.current.UpdateCurrentAmmo(12);

    }

    [Button]
    void NextStage() // Tells Stage Manager
    {
        DebugMessage("GameManager - NextStage");
        EventManager.current.NextStage();
    }

    [Button]
    void SpawnStageEnemies() // Tells Stage Manager
    {
        DebugMessage("GameManager - SpawnStageEnemies");
        EventManager.current.SpawnStageEnemies();
    }

    // when all enemies dead in stage
    // move to next stage

    // repeat

    // if all stages complete win

    [Button]
    void Win() // If All Stages Complete - Told By Stage Manager
    {
        DebugMessage("GameManager - Win");
    }

    [Button]
    void Lose() // If Player Health Reaches 0 or less - Told By Player
    {
        DebugMessage("GameManager - Lose");
    }

    [Button]
    void EnemyKilled() // Told By Enemy System
    {
        DebugMessage("GameManager - EnemyKilled");
        enemiesKilled++;
        EventManager.current.UpdateEnemyKilledUI(enemiesKilled);
    }

    [Button]
    void ResetGame() // Told By Restart Button
    {
        DebugMessage("GameManager - ResetGame");
        EventManager.current.ResetGame();
    }

    void DebugMessage(string message)
    {
        if (debugMessages)
        {
            Debug.Log(message);
        }
    }
}