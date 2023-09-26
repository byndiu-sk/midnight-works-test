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
        // ������� �������� ��� ��� ������� ������� �� ������� ������
        int playerWins = PlayerPrefs.GetInt(PlayerWinsKey, 0);
        int playerLosses = PlayerPrefs.GetInt(PlayerLossesKey, 0);

        // �������� ���������� � �������
        Debug.Log("ʳ������ ������� ������: " + playerWins);
        Debug.Log("ʳ������ ������� ������: " + playerLosses);
    }

    public void RegisterEnemy()
    {
        // ������� ��� ��������� ������ ������
        enemiesAlive++;
    }

    public void UnregisterEnemy()
    {
        // ������� ��� ��������� ������ ���� ���� �����
        enemiesAlive--;

        // ����������, �� �� ������ �����
        if (enemiesAlive <= 0)
        {
            // ��������� ������� ��������, ���������, ��������� ��� �����
            PlayerWon();
        }
    }

    public void PlayerWon()
    {
        // ������� ��� �������, ���� ������� ������
        int playerWins = PlayerPrefs.GetInt(PlayerWinsKey, 0);
        playerWins++;
        PlayerPrefs.SetInt(PlayerWinsKey, playerWins);
        PlayerPrefs.Save(); // �������� ���
    }

    public void PlayerLost()
    {
        // ������� ��� �������, ���� ������� �������
        int playerLosses = PlayerPrefs.GetInt(PlayerLossesKey, 0);
        playerLosses++;
        PlayerPrefs.SetInt(PlayerLossesKey, playerLosses);
        PlayerPrefs.Save(); // �������� ���
    }
}
