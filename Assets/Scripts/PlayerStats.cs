using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    public override void Die()
    {
        GameManager.Instance.PlayerLost();
        ScreenController.Instance.GetScreen<LoseScreen>().Open();
        base.Die();
    }
}
