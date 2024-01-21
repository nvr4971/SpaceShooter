using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowCount : MonoBehaviour
{
    public int GetRowEnemyCount()
    {
        int enemyCount = 0;

        foreach(Transform enemy in transform)
        {
            enemyCount += enemy.childCount;
        }

        return enemyCount;
    }
}
