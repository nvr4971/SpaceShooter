using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnDeath : MonoBehaviour
{
    public void TriggerPlayerDeathCallBack()
    {
        SoundManager.Instance.PlaySound(SoundEffect.PlayerDeath);
        PlayerManager.Instance.RespawnHandler();
    }
}
