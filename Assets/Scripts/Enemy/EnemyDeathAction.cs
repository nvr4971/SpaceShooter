using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathAction : MonoBehaviour
{
   [SerializeField] private int score;

   public void TriggerEnemyDeathCallBack()
    {
        EnemySpawn.Instance.UpdateActiveEnemyCount();
        ScoreDisplay.Instance.AddScore(score);
        PickupGenerate.Instance.SpawnPickup(transform.position);
    }
}
