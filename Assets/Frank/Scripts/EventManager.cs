using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VInspector;

public class EventManager : MonoBehaviour
{
    public static EventManager current;
    [SerializeField] bool debugMessages;

    void Start()
    {
        current = this;
    }

    // When the game starts
    public event Action onGameStart;
    [Button]
    public void GameStart()
    {
        DebugMessage("EventManager - GameStart");

        if (onGameStart != null)
        {
            onGameStart();
        }
    }

    // When the game stops
    public event Action onGameStop;
    [Button]
    public void GameStop()
    {
        DebugMessage("EventManager - GameStop");

        if (onGameStop != null)
        {
            onGameStop();
        }
    }

    // Win - All Stages Complete
    public event Action onWin;
    [Button]
    public void Win()
    {
        DebugMessage("EventManager - Win");

        if (onWin != null)
        {
            onWin();
            onGameStop();
        }
    }

    // Lose - Player Health 0
    public event Action onLose;
    [Button]
    public void Lose()
    {
        DebugMessage("EventManager - Lose");

        if (onLose != null)
        {
            onLose();
            onGameStop();
        }
    }

    // Spawn Stage Enemies
    public event Action onSpawnStageEnemies;
    [Button]
    public void SpawnStageEnemies()
    {
        DebugMessage("EventManager - SpawnStageEnemies");

        if (onSpawnStageEnemies != null)
        {
            onSpawnStageEnemies();
        }
    }

    // Enemy Killed
    public event Action onEnemyKilled;
    [Button]
    public void EnemyKilled()
    {
        DebugMessage("EventManager - EnemyKilled");

        if (onEnemyKilled != null)
        {
            onEnemyKilled();
        }
    }

    // Update Enemy KilledUI
    public event Action<int> onUpdateEnemyKilledUI;
    public void UpdateEnemyKilledUI(int enemiesKilled)
    {
        DebugMessage("EventManager - UpdateEnemyKilledUI");

        if (onUpdateEnemyKilledUI != null)
        {
            onUpdateEnemyKilledUI(enemiesKilled);
        }
    }

    public event Action<int> onUpdateHealthUI;
    public void UpdateHealthUI(int health)
    {
        DebugMessage("EventManager - UpdateHealthUI");

        if (onUpdateHealthUI != null)
        {
            onUpdateHealthUI(health);
        }
    }

    public event Action<string> onChangeWeapon;
    public void ChangeWeapon(string weaponName)
    {
        DebugMessage("EventManager - ChangeWeapon");

        if (onChangeWeapon != null)
        {
            onChangeWeapon(weaponName);
        }
    }

    public event Action<int> onUpdateMaxAmmoUI;
    public void UpdateMaxAmmo(int maxAmmo)
    {
        DebugMessage("EventManager - UpdateMaxAmmo");

        if (onUpdateMaxAmmoUI != null)
        {
            onUpdateMaxAmmoUI(maxAmmo);
        }
    }

    public event Action<int> onUpdateCurrentAmmo;
    public void UpdateCurrentAmmo(int currentAmmo)
    {
        DebugMessage("EventManager - UpdateCurrentAmmo");

        if (onUpdateCurrentAmmo != null)
        {
            onUpdateCurrentAmmo(currentAmmo);
        }
    }

    // Stage Complete - When All Enemies Are Dead
    public event Action onStageComplete;
    [Button]
    public void StageComplete()
    {
        DebugMessage("EventManager - StageComplete");

        if (onStageComplete != null)
        {
            onStageComplete();
        }
    }

    // Next Stage
    public event Action onNextStage;
    [Button]
    public void NextStage()
    {
        DebugMessage("EventManager - NextStage");

        if (onNextStage != null)
        {
            onNextStage();
        }
    }

    // Reset Game
    public event Action onResetGame;
    [Button]
    public void ResetGame()
    {
        DebugMessage("EventManager - ResetGame");

        if (onResetGame != null)
        {
            onResetGame();
        }
    }

    // Player Enters Cover
    public event Action onEnterCover;
    [Button]
    public void EnterCover()
    {
        DebugMessage("EventManager - EnterCover");

        if (onEnterCover != null)
        {
            onEnterCover();
        }
    }

    //Player Leaves Cover
    public event Action onExitCover;
    [Button]
    public void ExitCover()
    {
        DebugMessage("EventManager - ExitCover");

        if (onExitCover != null)
        {
            onExitCover();

        }
    }

    void DebugMessage(string message)
    {
        if (debugMessages)
        {
            Debug.Log(message);
        }
    }

    #region Extra Test Methods
    [SerializeField] int testHealth;
    [Button]
    public void UpdateHealthUI()
    {
        DebugMessage("EventManager - UpdateHealthUI");

        if (onUpdateHealthUI != null)
        {
            onUpdateHealthUI(testHealth);
        }
    }

    [SerializeField] string testWeaponName;
    [Button]
    public void ChangeWeapon()
    {
        DebugMessage("EventManager - ChangeWeapon");

        if (onChangeWeapon != null)
        {
            onChangeWeapon(testWeaponName);
        }
    }

    [SerializeField] int testMaxAmmo;
    [Button]
    public void UpdateMaxAmmo()
    {
        DebugMessage("EventManager - UpdateMaxAmmo");

        if (onUpdateMaxAmmoUI != null)
        {
            onUpdateMaxAmmoUI(testMaxAmmo);
        }
    }

    [SerializeField] int testCurrentAmmo;
    [Button]
    public void UpdateCurrentAmmo()
    {
        DebugMessage("EventManager - UpdateCurrentAmmo");

        if (onUpdateCurrentAmmo != null)
        {
            onUpdateCurrentAmmo(testCurrentAmmo);
        }
    }
    #endregion
}