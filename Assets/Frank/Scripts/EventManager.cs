using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager current;

    void Start()
    {
        current = this;
    }

    // When the game starts
    public event Action onGameStart;
    public void GameStart()
    {
        if (onGameStart != null)
        {
            onGameStart();
        }
    }

    // When the game stops
    public event Action onGameStop;
    public void GameStop()
    {
        if (onGameStop != null)
        {
            onGameStop();
        }
    }

    // Win - All Stages Complete
    public event Action onWin;
    public void Win()
    {
        if (onWin != null)
        {
            onWin();
        }
    }

    // Lose - Player Health 0
    public event Action onLose;
    public void Lose()
    {
        if (onLose != null)
        {
            onLose();
        }
    }

    // Spawn Stage Enemies
    public event Action onSpawnStageEnemies;
    public void SpawnStageEnmies()
    {
        if (onSpawnStageEnemies != null)
        {
            onSpawnStageEnemies();
        }
    }

    // Enemy Killed
    public event Action onEnemyKilled;
    public void EnemyKilled()
    {
        if (onEnemyKilled != null)
        {
            onEnemyKilled();
        }
    }

    // Stage Complete - When All Enemies Are Dead
    public event Action onStageComplete;
    public void StageComplete()
    {
        if (onStageComplete != null)
        {
            onStageComplete();
        }
    }

    // Next Stage
    public event Action onNextStage;
    public void NextStage()
    {
        if (onNextStage != null)
        {
            onNextStage();
        }
    }

    // Reset Game
    public event Action onResetGame;
    public void ResetGame()
    {
        if (onResetGame != null)
        {
            onResetGame();
        }
    }

    // Player Enters Cover
    public event Action onEnterCover;
    public void EnterCover()
    {
        if (onEnterCover != null)
        {
            onEnterCover();
        }
    }

    //Player Leaves Cover
    public event Action onExitCover;
    public void ExitCover()
    {
        if (onExitCover != null)
        {
            onExitCover();

        }
    }
}