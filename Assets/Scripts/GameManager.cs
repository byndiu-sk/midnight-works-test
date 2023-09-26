using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private const string PlayerWinsKey = "PlayerWins";
    private const string PlayerLossesKey = "PlayerLosses";


    public static GameManager Instance { get; private set; }

    private int enemiesAlive = 0;
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        // Зчитуємо збережені дані про кількість перемог та поразок гравця
        int playerWins = PlayerPrefs.GetInt(PlayerWinsKey, 0);
        int playerLosses = PlayerPrefs.GetInt(PlayerLossesKey, 0);

        // Виводимо інформацію в консоль
        Debug.Log("Кількість перемог гравця: " + playerWins);
        Debug.Log("Кількість поразок гравця: " + playerLosses);
    }

    public void RegisterEnemy()
    {
        // Функція для реєстрації нового ворога
        enemiesAlive++;
    }

    public void UnregisterEnemy()
    {
        // Функція для видалення ворога після його смерті
        enemiesAlive--;

        // Перевіряємо, чи всі вороги мертві
        if (enemiesAlive <= 0)
        {
            // Викликаємо функцію перемоги, наприклад, виведення луз скріну
            PlayerWon();
        }
    }

    public void PlayerWon()
    {
        // Функція для виклику, коли гравець виграв
        int playerWins = PlayerPrefs.GetInt(PlayerWinsKey, 0);
        playerWins++;
        PlayerPrefs.SetInt(PlayerWinsKey, playerWins);
        PlayerPrefs.Save(); // Зберегти дані
    }

    public void PlayerLost()
    {
        // Функція для виклику, коли гравець програв
        int playerLosses = PlayerPrefs.GetInt(PlayerLossesKey, 0);
        playerLosses++;
        PlayerPrefs.SetInt(PlayerLossesKey, playerLosses);
        PlayerPrefs.Save(); // Зберегти дані
    }
}
