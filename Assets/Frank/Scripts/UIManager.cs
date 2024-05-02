using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Variables & References
    List<GameObject> startUI = new List<GameObject>();

    [SerializeField] Button startButton;

    List<GameObject> gameUI = new List<GameObject>();

    [SerializeField] TMP_Text healthUI;
    [SerializeField] TMP_Text currentWeaponUI;
    [SerializeField] TMP_Text currentAmmoUI;
    [SerializeField] TMP_Text maxAmmoUI;
    [SerializeField] TMP_Text enemiesKilledUI;

    List<GameObject> endUI = new List<GameObject>();

    [SerializeField] Button restartButton;

    enum UIState
    {
        Start, Game, End
    }

    UIState currentUIState;

    [SerializeField] bool debugMessages;
    #endregion

    void Start()
    {
        // Start UI
        startUI.Add(startButton.gameObject);

        // Game UI
        gameUI.Add(healthUI.gameObject);
        gameUI.Add(currentWeaponUI.gameObject);
        gameUI.Add(currentAmmoUI.gameObject);
        gameUI.Add(maxAmmoUI.gameObject);
        gameUI.Add(enemiesKilledUI.gameObject);

        // End UI
        endUI.Add(restartButton.gameObject);

        // Events
        EventManager.current.onGameStop += StopUI;
        EventManager.current.onResetGame += StartUI;
        EventManager.current.onUpdateEnemyKilledUI += UpdateEnemiesKilledUI;
        EventManager.current.onUpdateHealthUI += UpdateHealth;
        EventManager.current.onChangeWeapon += UpdateCurrentWeapon;
        EventManager.current.onUpdateMaxAmmoUI += UpdateMaxAmmoUI;
        EventManager.current.onUpdateCurrentAmmo += UpdateCurrentAmmoUI;

        StartUI();
    }

    void StartUI()
    {
        DebugMessage("UIManager - StartUI");
        SetUIState(UIState.Start);
    }

    void GameUI()
    {
        DebugMessage("UIManager - GameUI");
        SetUIState(UIState.Game);
    }

    void StopUI()
    {
        DebugMessage("UIManager - StopUI");
        SetUIState(UIState.End);
    }

    public void StartButtonPress()
    {
        DebugMessage("UIManager - StartButtonPress");
        EventManager.current.GameStart();
        GameUI();
    }

    public void RestartButtonPress()
    {
        DebugMessage("UIManager - RestartButtonPress");
        EventManager.current.ResetGame();
        StartUI();
    }

    #region Update Methods
    void UpdateHealth(int health) // When Health Changed
    {
        healthUI.text = "Health: " + health.ToString();
    }

    void UpdateCurrentWeapon(string currentWeaponName) // When Weapon Changed
    {
        currentWeaponUI.text = "Current Weapon: " + currentWeaponName;
    }

    void UpdateCurrentAmmoUI(int currentAmmo) // When Ammo Changed, When Weapon Changed
    {
        currentAmmoUI.text = "Current Ammo: " + currentAmmo.ToString();
    }

    void UpdateMaxAmmoUI(int maxAmmo) // When Weapon Changed
    {
        maxAmmoUI.text = "Max Ammo: " + maxAmmo.ToString();
    }

    void UpdateEnemiesKilledUI(int enemiesKilled) // When Enemy Killed
    {
        enemiesKilledUI.text = "Enemies Killed: " + enemiesKilled.ToString();
    }
    #endregion

    #region UI State Methods
    void SetUIState(UIState UIState)
    {
        DisableUIElements(GetCurrentUIElements());

        switch (UIState)
        {
            case UIState.Start:
                currentUIState = UIState.Start;
                break;

            case UIState.Game:
                currentUIState = UIState.Game;
                break;

            case UIState.End:
                currentUIState = UIState.End;
                break;
        }

        EnableUIElements(GetCurrentUIElements());
    }

    List<GameObject> GetCurrentUIElements()
    {
        switch (currentUIState)
        {
            case UIState.Start:
                return startUI;

            case UIState.Game:
                return gameUI;

            case UIState.End:
                return endUI;

            default:
                return gameUI;
        }
    }

    void DisableUIElements(List<GameObject> UIElements)
    {
        foreach (GameObject UIElement in UIElements)
        {
            UIElement.SetActive(false);
        }
    }
    
    void EnableUIElements(List<GameObject> UIElements)
    {
        foreach (GameObject UIElement in UIElements)
        {
            UIElement.SetActive(true);
        }
    }
    #endregion

    void DebugMessage(string message)
    {
        if (debugMessages)
        {
            Debug.Log(message);
        }
    }
}